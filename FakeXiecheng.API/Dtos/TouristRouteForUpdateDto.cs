using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FakeXiecheng.API.Controllers;

namespace FakeXiecheng.API.Dtos
{
    public class TouristRouteForUpdateDto : TouristRouteForManipulationDto
    {
        [Required(ErrorMessage = "更新必备")]
        [MaxLength(1500)]
        public override string Description { get; set; }
    }
}
