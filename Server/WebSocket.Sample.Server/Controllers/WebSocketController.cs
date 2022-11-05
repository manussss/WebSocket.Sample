using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Net;
using System.Text;

namespace WebSocket.Sample.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WebSocketController : ControllerBase
{
    [HttpGet("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            //await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    [HttpGet("/ws1")]
    public async Task<string> GetMessage()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            while (true)
            {
                await webSocket.SendAsync(Encoding.ASCII.GetBytes($"Web Socket is up and running - {DateTime.Now}"), WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(3000);
            }
        }
        else
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        return "";
    }
}
