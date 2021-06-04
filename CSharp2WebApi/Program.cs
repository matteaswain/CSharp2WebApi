using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharp2WebApi
{
    class Program
    {
 // instance method can access static methods/variables and instance methods/variables
        async Task Run()
        {
  // HttpClient : key class that gives us the ability to call our api controller & other websites
            var http = new HttpClient();
            // Initilizes class json 
// this opens up options to communicate 
            var jsonSerizerOptions = new JsonSerializerOptions()
            {
           // telling api case does not matter when calling our properties 
                PropertyNameCaseInsensitive = true,

                // this will leave the format as is. 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase

            };
            var url = "http://localhost:36720/api/employees";

            var newEmpl = new Employee()
            {
                Id = 0,
                Firstname = "Noah",
                Lastname = "Phence",
                Login = "nphence1",
                Password = "password",
                IsManager = false
            };
            var json = JsonSerializer.Serialize<Employee>(newEmpl, jsonSerizerOptions);
            var httpContent2 = new StringContent(json, System.Text.Encoding.UTF8,"application/json");
            var httpMessageResponse2 = await http.PostAsync(url, httpContent2);


            var httpMessageResponse = await http.GetAsync(url);
            var httpContent = await httpMessageResponse.Content.ReadAsStringAsync();
     // jsonserializer translates json to csharp => csharp to json
            var employees = JsonSerializer.Deserialize<Employee[]>(httpContent, jsonSerizerOptions);

            foreach(var e in employees)
            {
                Console.WriteLine($"{e.Id} | {e.Lastname}");
            }

        }

  // static methods can not access instance methods or instance variables
       async static Task Main(string[] args)
        {
            var pgm = new Program();
            await pgm.Run();

        }
    }
}
