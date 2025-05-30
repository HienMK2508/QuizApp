﻿namespace QuizApp.Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; } = string.Empty;

    public List<Option> Options { get; set; } = new();
}
