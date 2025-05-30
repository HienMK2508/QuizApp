namespace QuizApp.Application.DTOs;

public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<QuestionDto> Questions { get; set; } = new();
}
