using QuizApp.Application.DTOs;
using QuizApp.Application.Interfaces;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Interfaces;

namespace QuizApp.Application.Services;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public async Task<bool> SubmitAnswerAsync(AnswerDto answerDto)
    {
        // Mapping DTO to domain model
        var answer = new Answer
        {
            UserId = answerDto.UserId,
            QuizId = answerDto.QuizId,
            QuestionId = answerDto.QuestionId,
            SelectedOptionId = answerDto.SelectedOptionId,
            TimeTakenSeconds = answerDto.TimeTakenSeconds,
            IsCorrect = false
        };

        await _answerRepository.SaveAnswerAsync(answer);
        return true;
    }
}
