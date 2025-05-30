using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuizApp.Infrastructure.Persistence.Entities;

namespace QuizApp.Infrastructure.Persistence;

public partial class QuizDbContext : DbContext
{
    public QuizDbContext()
    {
    }

    public QuizDbContext(DbContextOptions<QuizDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-UVSOJ04\\MSSQLSERVERMK;uid=sa;pwd=sa;database=QuizApp;Encrypt=false;TrustServerCertificate=True;Trusted_Connection=SSPI");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string ConnectionStr = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(ConnectionStr);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__Answer__D4825004E203EED6");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers).HasConstraintName("FK__Answer__Question__4316F928");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Answers).HasConstraintName("FK__Answer__QuizId__4222D4EF");

            entity.HasOne(d => d.SelectedOption).WithMany(p => p.Answers).HasConstraintName("FK__Answer__Selected__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Answers).HasConstraintName("FK__Answer__UserId__412EB0B6");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Option__92C7A1FFCE3D29F0");

            entity.HasOne(d => d.Question).WithMany(p => p.Options).HasConstraintName("FK__Option__Question__3E52440B");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC6CC8B4F2");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions).HasConstraintName("FK__Question__QuizId__3B75D760");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__8B42AE8E35D553A7");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Result__9769020857F81D36");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Results).HasConstraintName("FK__Result__QuizId__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Results).HasConstraintName("FK__Result__UserId__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C43268A3F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
