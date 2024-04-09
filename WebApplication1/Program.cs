using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o => o.FlattenSchema = true);


var app = builder.Build();

app.UseFastEndpoints(config => config.Endpoints.RoutePrefix = "api");
app.UseSwaggerGen();

app.Run();

public class RequestDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
}

public class ResponseDTO
{
    public string Status { get; set; }
    public string Message { get; set; }
}


[HttpPost("/organizations/fetch-all")]
public class PostHandler : GetHandler { }

[HttpGet("/organizations")]
public class GetHandler : Endpoint<RequestDTO, ResponseDTO>
{
    public override Task<ResponseDTO> HandleAsync(RequestDTO request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ResponseDTO
        {
            Status = "Success",
            Message = "Your message has been sent successfully"
        });
    }
}