using QuizApp.Application.DTOs;
using QuizApp.Application.Interfaces;
using QuizApp.Domain.Interfaces;

namespace QuizApp.Application.Services;

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;

    public QuizService(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<QuizDto?> GetQuizWithQuestionsAsync(int quizId)
    {
        var quiz = await _quizRepository.GetQuizWithQuestionsAsync(quizId);
        if (quiz == null) return null;

        return new QuizDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Questions = quiz.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Text = q.Text,
                Options = q.Options.Select(o => new OptionDto
                {
                    Id = o.Id,
                    Text = o.Text
                }).ToList()
            }).ToList()
        };
    }
}
