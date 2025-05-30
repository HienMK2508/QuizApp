using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using QuizApp.Application.DTOs;
using Xunit;
using Xunit.Abstractions;

namespace QuizApp.Api.Tests;

public class QuizFlowTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public QuizFlowTests(WebApplicationFactory<Program> factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    [Fact]
    public async Task FullQuizFlow_ShouldReturnResult()
    {
        int userId = 1;
        int quizId = 1;

        _output.WriteLine("🔍 Step 1: Fetching quiz questions...");
        var quizResponse = await _client.GetFromJsonAsync<QuizDto>($"/api/quiz/{quizId}/questions");

        Assert.NotNull(quizResponse);
        Assert.NotEmpty(quizResponse.Questions);

        _output.WriteLine($"✅ Quiz: {quizResponse.Title} - {quizResponse.Questions.Count} questions.");

        int qIndex = 1;
        foreach (var question in quizResponse.Questions)
        {
            var selectedOption = question.Options.First();
            _output.WriteLine($"➡️ Q{qIndex}: {question.Text} → Option: {selectedOption.Text}");

            var answerDto = new AnswerDto
            {
                UserId = userId,
                QuizId = quizId,
                QuestionId = question.Id,
                SelectedOptionId = selectedOption.Id,
                TimeTakenSeconds = 3
            };

            var response = await _client.PostAsJsonAsync("/api/answer", answerDto);
            response.EnsureSuccessStatusCode();
            _output.WriteLine($"✅ Answered Q{qIndex}");
            qIndex++;
        }

        _output.WriteLine("📨 Submitting quiz...");
        var resultResponse = await _client.PostAsync($"/api/result/submit?userId={userId}&quizId={quizId}", null);
        resultResponse.EnsureSuccessStatusCode();

        var result = await resultResponse.Content.ReadFromJsonAsync<ResultDto>();

        _output.WriteLine("🎯 Quiz Result:");
        _output.WriteLine($"✔️ Correct: {result?.CorrectAnswers}");
        _output.WriteLine($"⏱ Time: {result?.TotalTime} seconds");
        _output.WriteLine($"🏁 Passed: {(result?.Passed == true ? "✅ YES" : "❌ NO")}");
    }
}
