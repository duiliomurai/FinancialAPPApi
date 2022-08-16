﻿using System.ComponentModel.DataAnnotations;

namespace FinancialAppAPI.Data.Dtos.Income
{
    public class ReadIncomeDto
    {
        [Key]
        [Required]
        public int IncomeId { get; set; }
        [Required(ErrorMessage = "Income must have a description")]
        [StringLength(30, ErrorMessage = "Income's description has more than 30 characters")]
        public string IncomeName { get; set; }
        [Required(ErrorMessage = "Income must have a certain amount")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public double IncomeAmount { get; set; }
        [Required(ErrorMessage = "Income must have a date")]
        public DateTime IncomeDate { get; set; }
    }
}
