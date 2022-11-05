using System.Net.WebSockets;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();
//app.Map("/", async context =>
//{
//    if (!context.WebSockets.IsWebSocketRequest)
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//    else
//    {
//        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
//        while (true)
//        {
//            await webSocket.SendAsync(
//                Encoding.ASCII.GetBytes($".NET Rocks -> {DateTime.Now}"),
//                WebSocketMessageType.Text,
//                true, CancellationToken.None);
//            await Task.Delay(1000);
//        }
//    }
//});

//app.Use(async (context, next) =>
//{
//    if (context.Request.Path == "/ws")
//    {
//        if (context.WebSockets.IsWebSocketRequest)
//        {
//            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
//            await Echo(webSocket);
//        }
//        else
//        {
//            context.Response.StatusCode = StatusCodes.Status400BadRequest;
//        }
//    }
//    else
//    {
//        await next(context);
//    }

//});

await app.RunAsync();
