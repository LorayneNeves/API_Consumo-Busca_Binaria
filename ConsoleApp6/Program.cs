using System.Text;
using ConsoleApp6;

menu:
Console.WriteLine("1 - Para ver lista de alunos");
Console.WriteLine("2 - Para adicionar a lista de alunos");
int menu = int.Parse(Console.ReadLine());

switch (menu)
{
    case 1:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Fazer a requisição GET para a URL da API

                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/ALUNOS");

                // Verificar se a requisição foi bem-sucedida

                if (response.IsSuccessStatusCode)
                {
                    // Ler a resposta como uma string

                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine("A requisição não foi bem-sucedida. Código de status: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
        goto menu;
    case 2:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Criar um objeto para representar os dados a serem enviados na requisição
                Console.WriteLine("Digite RA");
                Console.WriteLine("Digite  nome");
                Console.WriteLine("Digite idade do aluno");
                var data = new { ra = Console.ReadLine(), nome = Console.ReadLine(), idade = Console.ReadLine() };

                // Converter o objeto para JSON

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:3000/ALUNOS", content);

                // Verificar se a requisição foi bem-sucedida

                if (response.IsSuccessStatusCode)
                {
                    // Ler a resposta como uma string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Fazer algo com a resposta da API
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine("A requisição não foi bem-sucedida. Código de status: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
        break;
}
