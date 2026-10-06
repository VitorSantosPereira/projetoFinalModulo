using System.Text.Json;

namespace DeskFlowAPI.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        {
            await TratarErro(
                context,
                StatusCodes.Status400BadRequest,
                ex.Message
            );
        }
        catch (InvalidOperationException ex)
        {
            await TratarErro(
                context,
                StatusCodes.Status409Conflict,
                ex.Message
            );
        }
        catch (Exception)
        {
            await TratarErro(
                context,
                StatusCodes.Status500InternalServerError,
                "Ocorreu um erro interno no servidor."
            );
        }
    }

    private static async Task TratarErro(
        HttpContext context,
        int statusCode,
        string mensagem)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var resposta = new
        {
            erro = mensagem
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(resposta)
        );
    }
}