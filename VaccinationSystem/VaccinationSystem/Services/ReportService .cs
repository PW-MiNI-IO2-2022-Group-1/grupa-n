using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.Repositories;

namespace VaccinationSystem.Services
{
    public class ReportService : GenericRepository<Visit>, IReportService
    {
        public ReportService(ApplicationDbContext context) : base(context)
        {

        }

        private class VaccinationEntity
        {
            public string VaccineName { get; set; }
            public string DiseaseName { get; set; }
        }

        public byte[] GetReport()
        {
            List<VaccinationEntity> vaccinations = GetVaccinationData();
            var vaccinationsPerDisease = vaccinations
                .GroupBy(x => x.DiseaseName)
                .Select(group => new
                {
                    DiseaseName = group.Key,
                    Count = group.Count()
                })
                .ToList();
            var vaccinationsPerVaccine = vaccinations
                .GroupBy(x => x.VaccineName)
                .Select(group => new
                {
                    DiseaseName = group.First().DiseaseName,
                    VaccineName = group.First().VaccineName,
                    Count = group.Count()
                })
                .ToList();

            using var memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph date = new Paragraph(DateTime.Now.ToString())
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(10);
            document.Add(date);

            Paragraph header = new Paragraph("Report")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);
            document.Add(header);

            Paragraph firstSubHeader = new Paragraph("Vaccinations per disease")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(14);
            document.Add(firstSubHeader);

            var vaxPerDiseaseTable = new Table(numColumns: 2, largeTable: false);
            vaxPerDiseaseTable.AddCell(CellWithText("Disease"));
            vaxPerDiseaseTable.AddCell(CellWithText("Count").SetTextAlignment(TextAlignment.CENTER));
            foreach (var disease in vaccinationsPerDisease)
            {
                vaxPerDiseaseTable.AddCell(CellWithText(disease.DiseaseName));
                vaxPerDiseaseTable.AddCell(CellWithText(disease.Count.ToString())
                    .SetTextAlignment(TextAlignment.CENTER));
            }
            document.Add(vaxPerDiseaseTable);

            Paragraph secondSubHeader = new Paragraph("Vaccinations per vaccine")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(14);
            document.Add(secondSubHeader);

            var secondTable = new Table(numColumns: 3, largeTable: false);
            secondTable.AddCell(CellWithText("Vaccine"));
            secondTable.AddCell(CellWithText("Disease"));
            secondTable.AddCell(CellWithText("Count").SetTextAlignment(TextAlignment.CENTER));
            foreach (var vaccine in vaccinationsPerVaccine)
            {
                secondTable.AddCell(CellWithText(vaccine.VaccineName));
                secondTable.AddCell(CellWithText(vaccine.DiseaseName));
                secondTable.AddCell(CellWithText(vaccine.Count.ToString())
                    .SetTextAlignment(TextAlignment.CENTER));
            }
            document.Add(secondTable);

            document.Close();
            return memoryStream.ToArray();
        }

        private List<VaccinationEntity> GetVaccinationData()
        {
            return context.Visits
                .Where(visit => visit.Status == VaccinationStatus.Completed)
                .Include(visit => visit.Vaccine)
                .Include(visit => visit.Vaccine.Disease)
                .Select(visit => new VaccinationEntity
                {
                    VaccineName = visit.Vaccine.Name,
                    DiseaseName = visit.Vaccine.Disease.Name
                })
                .ToList();
        }

        private Cell CellWithText(string text)
        {
            return new Cell().SetPadding(5).Add(new Paragraph(text));
        }
    }
}
