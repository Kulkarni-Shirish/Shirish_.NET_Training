using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace UserProfileMvc.Models
{
    // Custom validation attribute to ensure date is within a specific range
    public class DateInRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateInRangeAttribute(string minDate, string maxDate)
        {
            // Parse min and max dates using InvariantCulture to avoid format issues
            _minDate = DateTime.ParseExact(minDate, "M/d/yyyy", CultureInfo.InvariantCulture);
            _maxDate = DateTime.ParseExact(maxDate, "M/d/yyyy", CultureInfo.InvariantCulture);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Check if the input value is a DateTime and within the specified range
            if (value is DateTime dateValue)
            {
                if (dateValue < _minDate || dateValue > _maxDate)
                {
                    return new ValidationResult(ErrorMessage ?? $"Date must be between {_minDate:d} and {_maxDate:d}");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class UserProfile
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty; // Stores user name and avoids null issues

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DateInRange("1/1/1900", "1/1/2090", ErrorMessage = "Date must be between 1/1/1900 and 1/1/2090")]
        public DateTime Date { get; set; } = DateTime.Today; // Ensures date is valid and defaults to today

        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country preference is required")]
        public string CountryPreferred { get; set; } = string.Empty;

        [Required(ErrorMessage = "Skill sets are required")]
        public string SkillSets { get; set; } = string.Empty;
    }
}
