using QuizApp.Application.DTOs;
using QuizApp.Application.Interfaces;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Interfaces;

namespace QuizApp.Application.Services;

public class ResultService : IResultService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IResultRepository _resultRepository;

    public ResultService(IAnswerRepository answerRepository, IResultRepository resultRepository)
    {
        _answerRepository = answerRepository;
        _resultRepository = resultRepository;
    }

    public async Task<ResultDto> SubmitQuizAsync(int userId, int quizId)
    {
        var answers = await _answerRepository.GetAnswersByUserAndQuizAsync(userId, quizId);

        int totalTime = answers.Sum(a => a.TimeTakenSeconds);
        int correctCount = answers.Count(a => a.IsCorrect);
        bool passed = correctCount >= 5; 

        var result = new Result
        {
            UserId = userId,
            QuizId = quizId,
            TotalTime = totalTime,
            CorrectAnswers = correctCount,
            Passed = passed
        };

        await _resultRepository.SaveResultAsync(result);

        return new ResultDto
        {
            UserId = userId,
            QuizId = quizId,
            TotalTime = totalTime,
            CorrectAnswers = correctCount,
            Passed = passed
        };
    }
}
