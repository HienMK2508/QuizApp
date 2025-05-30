using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Interfaces;
using QuizApp.Infrastructure.Persistence;
using DomainAnswer = QuizApp.Domain.Entities.Answer;

namespace QuizApp.Infrastructure.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly QuizDbContext _context;

    public AnswerRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task SaveAnswerAsync(Answer answer)
    {
        // Map từ domain Answer sang EF entity
        var efAnswer = new Persistence.Entities.Answer
        {
            UserId = answer.UserId,
            QuizId = answer.QuizId,
            QuestionId = answer.QuestionId,
            SelectedOptionId = answer.SelectedOptionId,
            TimeTaken = answer.TimeTakenSeconds,
            IsCorrect = answer.IsCorrect
        };

        _context.Answers.Add(efAnswer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Answer>> GetAnswersByUserAndQuizAsync(int userId, int quizId)
    {
        var answers = await _context.Answers
            .Where(a => a.UserId == userId && a.QuizId == quizId)
            .ToListAsync();

        return answers.Select(a => new DomainAnswer
        {
            Id = (int)a.AnswerId,  
            UserId = a.UserId ?? 0,
            QuizId = a.QuizId ?? 0,
            QuestionId = a.QuestionId ?? 0,
            SelectedOptionId = a.SelectedOptionId ?? 0,
            TimeTakenSeconds = a.TimeTaken ?? 0,
            IsCorrect = a.IsCorrect ?? false
        }).ToList();

    }
}
