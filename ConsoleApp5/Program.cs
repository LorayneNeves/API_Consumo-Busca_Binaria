using ConsoleApp5;
using System.ComponentModel.Design;
using System.Text;

Menu:
Console.WriteLine("Digite uma das opções:");
Console.WriteLine("1- cadastrar produto:");
Console.WriteLine("2 - atualizar produto:");
Console.WriteLine("3 - remover produto:");
Console.WriteLine("4- listar produto:");
Console.WriteLine("5- Exportar para csv:");
Console.WriteLine("6- sair:");
int menu =int.Parse( Console.ReadLine());

switch (menu)
{
    case 1:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Criar um objeto para representar os dados a serem enviados na requisição
                Console.WriteLine("Digite ID, nome, descrição e preço para cadastrar: ");
                var data = new { nome = Console.ReadLine(), descricao = Console.ReadLine(), preco = int.Parse(Console.ReadLine()) };



                // Converter o objeto para JSON

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);



                // Criar um conteúdo HTTP com o JSON

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");



                // Fazer a requisição POST para a URL da API

                HttpResponseMessage response = await client.DeleteAsync("http://localhost:3000/produtos", content);

                // Verificar se a requisição foi bem - sucedida

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
    case 2:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Criar um objeto para representar os dados a serem enviados na requisição
                Console.WriteLine("Digite nome, descrição e preço para atualizar: ");
                var data = new { nome = Console.ReadLine(), descricao = Console.ReadLine(), preco = int.Parse(Console.ReadLine()) };



                // Converter o objeto para JSON

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);



                // Criar um conteúdo HTTP com o JSON

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");



                // Fazer a requisição POST para a URL da API

                HttpResponseMessage response = await client.PutAsync("http://localhost:3000/produtos", content);

                // Verificar se a requisição foi bem - sucedida

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
    case 3:
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Fazer a requisição GET para a URL da API
                HttpResponseMessage response = await client.DeleteAsync("http://localhost:3000/produtos");
                // Verificar se a requisição foi bem-sucedida
                Console.WriteLine("Digite id e nome para deletar: ");
                var data = new { id = Console.ReadLine(), nome = Console.ReadLine() };
                if (response.IsSuccessStatusCode)
                {
                    // Ler a resposta como uma string

                    string responseBody = await response.Content.ReadAsStringAsync();



                    // Fazer algo com os dados obtidos da API

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
    case 4:
        using (HttpClient client = new HttpClient())
        {
            try
            {

                string url = "http://localhost:3000/produtos";

                HttpResponseMessage response = await client.GetAsync(url); response.EnsureSuccessStatusCode();

                response.EnsureSuccessStatusCode();



                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                List<Root> root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(responseBody);



                // Exibindo os dados do CEP
                foreach (var item in root)
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
         
        
break;
    case 5: 
        
    break;
    case 6: 
        
    break;
}
        