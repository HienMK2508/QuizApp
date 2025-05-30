using QuizApp.Domain.Entities;


namespace QuizApp.Domain.Interfaces;

public interface IAnswerRepository
{
    Task SaveAnswerAsync(Answer answer);
    Task<List<Answer>> GetAnswersByUserAndQuizAsync(int userId, int quizId);
}
