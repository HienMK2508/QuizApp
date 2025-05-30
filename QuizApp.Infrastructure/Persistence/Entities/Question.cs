using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Infrastructure.Persistence.Entities;

[Table("Question")]
public partial class Question
{
    [Key]
    public int QuestionId { get; set; }

    public int? QuizId { get; set; }

    [StringLength(1000)]
    public string? Text { get; set; }

    [InverseProperty("Question")]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    [InverseProperty("Question")]
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    [ForeignKey("QuizId")]
    [InverseProperty("Questions")]
    public virtual Quiz? Quiz { get; set; }
}
