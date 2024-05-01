using System.Net.Http.Json;

using var client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7166");
while (true)
{

    Console.Write("Question: "); 
    var question = Console.ReadLine();
    await foreach (var item in client.GetFromJsonAsAsyncEnumerable<string>($"/ask?question={question}"))
    { 
        Console.Write(item);
        await Task.Delay(250);
    
    }
    Console.WriteLine();

}


