using System;
using System.ComponentModel.DataAnnotations;

namespace UserProfileMvc.Validations
{
    public class DateInRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateInRangeAttribute(string minDate, string maxDate)
        {
            _minDate = DateTime.Parse(minDate);
            _maxDate = DateTime.Parse(maxDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
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
}
