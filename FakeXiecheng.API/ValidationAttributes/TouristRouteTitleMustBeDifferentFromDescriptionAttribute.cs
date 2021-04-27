using System;
using System.ComponentModel.DataAnnotations;
using FakeXiecheng.API.Controllers;

namespace FakeXiecheng.API.ValidationAttributes
{
    public class TouristRouteTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var touristRouteDto = (TouristRouteForCreationDto)validationContext.ObjectInstance;
            if (touristRouteDto.Title == touristRouteDto.Description)
            {
                return new ValidationResult(
                    "路线名称必须与路线描述不同",
                    new[] { "TouristRouteForCreationDto" });
            }
            return ValidationResult.Success;
        }
    }
}
