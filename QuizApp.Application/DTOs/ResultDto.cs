namespace QuizApp.Application.DTOs;

public class ResultDto
{
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int TotalTime { get; set; }
    public int CorrectAnswers { get; set; }
    public bool Passed { get; set; }
}
