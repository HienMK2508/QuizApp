using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Interfaces;

namespace QuizApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResultController : ControllerBase
{
    private readonly IResultService _resultService;

    public ResultController(IResultService resultService)
    {
        _resultService = resultService;
    }

    // POST: api/result/submit
    [HttpPost("submit")]
    public async Task<IActionResult> SubmitQuiz([FromQuery] int userId, [FromQuery] int quizId)
    {
        var result = await _resultService.SubmitQuizAsync(userId, quizId);
        return Ok(result);
    }
}
