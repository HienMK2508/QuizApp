using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Interfaces;
using QuizApp.Application.DTOs;

namespace QuizApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    // GET: api/quiz/1/questions
    [HttpGet("{quizId}/questions")]
    public async Task<IActionResult> GetQuizWithQuestions(int quizId)
    {
        var result = await _quizService.GetQuizWithQuestionsAsync(quizId);
        if (result == null)
            return NotFound($"Quiz {quizId} not found.");

        return Ok(result);
    }
}
