using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.DTOs;
using QuizApp.Application.Interfaces;

namespace QuizApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    // POST: api/answer
    [HttpPost]
    public async Task<IActionResult> SubmitAnswer([FromBody] AnswerDto answerDto)
    {
        var success = await _answerService.SubmitAnswerAsync(answerDto);
        if (!success)
            return BadRequest("Failed to submit answer.");

        return Ok("Answer submitted.");
    }
}
