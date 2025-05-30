using QuizApp.Application.DTOs;

namespace QuizApp.Application.Interfaces;

public interface IAnswerService
{
    Task<bool> SubmitAnswerAsync(AnswerDto answerDto);
}
