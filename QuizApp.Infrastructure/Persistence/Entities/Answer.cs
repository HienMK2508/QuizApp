using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Infrastructure.Persistence.Entities;

[Table("Answer")]
public partial class Answer
{
    [Key]
    public int AnswerId { get; set; }

    public int? UserId { get; set; }

    public int? QuizId { get; set; }

    public int? QuestionId { get; set; }

    public int? SelectedOptionId { get; set; }

    public bool? IsCorrect { get; set; }

    public int? TimeTaken { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("Answers")]
    public virtual Question? Question { get; set; }

    [ForeignKey("QuizId")]
    [InverseProperty("Answers")]
    public virtual Quiz? Quiz { get; set; }

    [ForeignKey("SelectedOptionId")]
    [InverseProperty("Answers")]
    public virtual Option? SelectedOption { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Answers")]
    public virtual User? User { get; set; }
}
