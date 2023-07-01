using ConsoleApp5;
using System.ComponentModel.Design;
using System.Net;
using System.Text;

Menu:
Console.WriteLine("Digite uma das opções");
Console.WriteLine("1 - Cadastrar produto");
Console.WriteLine("2 - Atualizar produto");
Console.WriteLine("3 - Remover produto");
Console.WriteLine("4 - Listar produto");
Console.WriteLine("5 - Exportar para csv");
Console.WriteLine("6 - Sair");
int menu = int.Parse( Console.ReadLine());
Root root = new Root();
switch (menu)
{
    case 1:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.WriteLine("Digite nome, descrição e preço para cadastrar: ");
                var data = new { nome = Console.ReadLine(), descricao = Console.ReadLine(), preco = int.Parse(Console.ReadLine()) };

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://192.168.1.9:3000/produtos", content);

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
        goto Menu;
    case 2:
        Console.WriteLine("Digite o id do produto para atualizar:");
        root.recebeid = int.Parse( Console.ReadLine());

        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.WriteLine("Digite nome, descrição e preço para cadastrar: ");

                var data = new { nome = Console.ReadLine(), descricao = Console.ReadLine(), preco = int.Parse(Console.ReadLine())};
                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                string url = $"http://192.168.1.9:3000/produtos/{root.recebeid}";

                HttpResponseMessage response = await client.PutAsync($"http://192.168.1.9:3000/produtos/{root.recebeid}", content);

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
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
        goto Menu;
    case 3:
        Console.WriteLine("Digite o id do produto para deletar:");
        root.recebeid = int.Parse(Console.ReadLine());
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"http://192.168.1.9:3000/produtos/{root.recebeid}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Root root1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseBody);

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(url);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
        goto Menu;
    case 4:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "http://192.168.1.9:3000/produtos";

                HttpResponseMessage response = await client.GetAsync(url); response.EnsureSuccessStatusCode();

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<Root> root1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(responseBody);

                foreach (var item in root1)
                {
                    Console.WriteLine($"ID: {item.id}");

                    Console.WriteLine($"NOME: {item.nome}");

                    Console.WriteLine($"DESCRIÇÃO: {item.descricao}");

                    Console.WriteLine($"PREÇO: {item.preco}");
                }
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
        goto Menu;
    case 5:      
        string apiUrl = "http://192.168.1.9:3000/produtos";
        string csvFilePath = "C:\\Users\\loray\\Documents\\atividadeGrupo\\Desafio\\aplication\\arquivo.csv";
        try
        {
            string apiResponse = SendApiRequest(apiUrl);
            using (StreamWriter writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
            {
                writer.Write(apiResponse);
            }
            Console.WriteLine("Dados exportados para o arquivo CSV com sucesso.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
        string SendApiRequest(string url)
        {
            using (WebClient client = new WebClient())
            {          
                return client.DownloadString(url);
            }
        }
        goto Menu;
    case 6:
        Console.ReadKey();
    break;
}
        
