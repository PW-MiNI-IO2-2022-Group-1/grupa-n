namespace VaccinationSystem.Data
{
    public enum Diseases
    {
        Covid19, Covid21, Flu, Chickenpox, Smallpox, Measles, Mumps, Polio
    };

    public class DiseaseDto
    {
        public Diseases Diseases { get; set; }
    }
}
