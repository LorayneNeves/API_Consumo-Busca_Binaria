using System.Text;
using CriandoAPI_Prova;
menu:
Console.WriteLine("1 - Para ver lista de Paises");
Console.WriteLine("2 - Para adicionar Pais a lista");
Console.WriteLine("3 - Sair");
int menu = int.Parse(Console.ReadLine());

switch (menu)
{
    case 1:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/paises");

                if (response.IsSuccessStatusCode)
                {
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
            Console.WriteLine();
        }
        goto menu;
    case 2:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.WriteLine("Digite nome");
                Console.WriteLine("Digite participações em copa");
                Console.WriteLine("Digite titulos da copa");
                var data = new { nome = Console.ReadLine(), participacoes = Console.ReadLine(), titulos = Console.ReadLine() };

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:3000/paises", content);

                if (response.IsSuccessStatusCode)
                {
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
    case 3:
        break;
}