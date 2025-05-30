namespace QuizApp.Application.DTOs;

public class AnswerDto
{
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedOptionId { get; set; }
    public int TimeTakenSeconds { get; set; }
}
