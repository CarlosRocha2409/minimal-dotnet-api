var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Index sin parametros
app.MapGet("/", () => "Hello World from dotnet!");

// Pagina "hola", requiere de la variable "nombre" en la URL para funcionar, sino devuelve BadHttpRequestException
// Ejemplo de URL a utilizar https://localhost:7228/hola?nombre=Jarov
app.MapGet("/hola", (string nombre) => $"Hi {nombre}, nice to meet you!");

// Pagina "hola" con parametros en URL, puede ser uno o varios parametros
// Ejemplo de URL a utilizar https://localhost:7228/hola2/Jarov/Davila
app.MapGet("/hola2/{nombre}/{apellido}", (string nombre, string apellido) => $"Hi {nombre} {apellido}, how you doing?");

// Usando metodos asincronicos para obtener y devolver una respuesta JSON
// Ejemplo de URL a utilizar https://localhost:7228/response
app.MapGet("/response", async () =>
{
    HttpClient client = new();
    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");

    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();
    return responseBody;
});

app.Run();
