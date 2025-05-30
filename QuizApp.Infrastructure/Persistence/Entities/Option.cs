using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Infrastructure.Persistence.Entities;

[Table("Option")]
public partial class Option
{
    [Key]
    public int OptionId { get; set; }

    public int? QuestionId { get; set; }

    [StringLength(500)]
    public string? Text { get; set; }

    public bool? IsCorrect { get; set; }

    [InverseProperty("SelectedOption")]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    [ForeignKey("QuestionId")]
    [InverseProperty("Options")]
    public virtual Question? Question { get; set; }
}
