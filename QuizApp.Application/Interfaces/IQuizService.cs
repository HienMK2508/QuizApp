using QuizApp.Application.DTOs;

namespace QuizApp.Application.Interfaces;

public interface IQuizService
{
    Task<QuizDto?> GetQuizWithQuestionsAsync(int quizId);
}
