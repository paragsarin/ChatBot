using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKernel().AddAzureOpenAIChatCompletion(builder.Configuration["OpenAI:deploymentname"], builder.Configuration["OpenAI:endpoint"], builder.Configuration["OpenAI:key"], null,null,null);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/ask", (string question, Kernel kernel) =>
{
    return kernel.InvokePromptStreamingAsync<string>(question);
});


app.Run();


