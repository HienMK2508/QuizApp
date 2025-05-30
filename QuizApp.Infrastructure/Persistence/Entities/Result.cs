using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Infrastructure.Persistence.Entities;

[Table("Result")]
public partial class Result
{
    [Key]
    public int ResultId { get; set; }

    public int? UserId { get; set; }

    public int? QuizId { get; set; }

    public int? TotalTime { get; set; }

    public int? CorrectAnswers { get; set; }

    public bool? Passed { get; set; }

    [ForeignKey("QuizId")]
    [InverseProperty("Results")]
    public virtual Quiz? Quiz { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Results")]
    public virtual User? User { get; set; }
}
