using QuizApp.Domain.Entities;

namespace QuizApp.Domain.Interfaces;

public interface IQuizRepository
{
    Task<Quiz?> GetQuizWithQuestionsAsync(int quizId);
}
