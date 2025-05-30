using QuizApp.Domain.Entities;
using QuizApp.Domain.Interfaces;
using QuizApp.Infrastructure.Persistence;
using QuizApp.Infrastructure.Persistence.Entities;
using DomainResult = QuizApp.Domain.Entities.Result;
using EfResult = QuizApp.Infrastructure.Persistence.Entities.Result;


namespace QuizApp.Infrastructure.Repositories;

public class ResultRepository : IResultRepository
{
    private readonly QuizDbContext _context;

    public ResultRepository(QuizDbContext context)
    {
        _context = context;
    }

    public async Task SaveResultAsync(DomainResult result)
    {
        var efResult = new EfResult
        {
            UserId = result.UserId,
            QuizId = result.QuizId,
            TotalTime = result.TotalTime,
            CorrectAnswers = result.CorrectAnswers,
            Passed = result.Passed
        };

        _context.Results.Add(efResult);
        await _context.SaveChangesAsync();
    }

}
