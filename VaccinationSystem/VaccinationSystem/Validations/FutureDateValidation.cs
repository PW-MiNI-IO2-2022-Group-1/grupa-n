using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationSystem.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FutureDateValidation : ValidationAttribute
    {
        public int DaysBefore { get; set; }
        public FutureDateValidation(int daysBefore = 0)
        {
            DaysBefore = daysBefore;
        }
        public override bool IsValid(object? value)
        {
            var inputValue = value as DateTime?;
            if (inputValue.HasValue && inputValue >= DateTime.Now.AddDays(DaysBefore))
            {
                return true;
            }
            return false;
        }
    }
}
