using QuizApp.Domain.Entities;

namespace QuizApp.Domain.Interfaces;

public interface IResultRepository
{
    Task SaveResultAsync(Result result);
}
