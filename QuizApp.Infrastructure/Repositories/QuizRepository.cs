using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Interfaces;
using QuizApp.Infrastructure.Persistence;
using DomainQuiz = QuizApp.Domain.Entities.Quiz;


namespace QuizApp.Infrastructure.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly QuizDbContext _context;

    public QuizRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task<DomainQuiz?> GetQuizWithQuestionsAsync(int quizId)
    {
        var efQuiz = await _context.Quizzes
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .FirstOrDefaultAsync(q => q.QuizId == quizId);  

        if (efQuiz == null) return null;

        return new DomainQuiz
        {
            Id = efQuiz.QuizId,   
            Title = efQuiz.Title,
            Description = efQuiz.Description,
            Questions = efQuiz.Questions.Select(q => new Domain.Entities.Question
            {
                Id = q.QuestionId,
                QuizId = (int)q.QuizId,
                Text = q.Text,
                Options = q.Options.Select(o => new Domain.Entities.Option
                {
                    Id = o.OptionId,
                    QuestionId = (int)o.QuestionId,
                    Text = o.Text,
                    IsCorrect = o.IsCorrect ?? false
                }).ToList()
            }).ToList()
        };
    }

}
