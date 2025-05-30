using QuizApp.Application.DTOs;

namespace QuizApp.Application.Interfaces;

public interface IResultService
{
    Task<ResultDto> SubmitQuizAsync(int userId, int quizId);
}
