namespace QuizApp.Domain.Entities;

public class Answer
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public int QuestionId { get; set; }
    public int SelectedOptionId { get; set; }
    public int UserId { get; set; }

    public bool IsCorrect { get; set; }
    public int TimeTakenSeconds { get; set; }
}
