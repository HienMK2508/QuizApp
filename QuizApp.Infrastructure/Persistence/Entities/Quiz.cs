using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Infrastructure.Persistence.Entities;

[Table("Quiz")]
public partial class Quiz
{
    [Key]
    public int QuizId { get; set; }

    [StringLength(255)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [InverseProperty("Quiz")]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    [InverseProperty("Quiz")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [InverseProperty("Quiz")]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
