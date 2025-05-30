using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Infrastructure.Persistence.Entities;

[Table("User")]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    [InverseProperty("User")]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
