using CotacaoMoedas_API;
using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using CotacaoMoedas_API;
using System.Reflection.Metadata.Ecma335;
Menu:
Console.WriteLine("1 - Procurar por moeda: ");
Console.WriteLine("2 - Procurar por moeda e quantidade");
Console.WriteLine("3 - Procurar por moeda e data");
int menu = int.Parse(Console.ReadLine());

Root dados = new Root();

switch (menu)
{
    case 1:
        Console.WriteLine("Digite a moeda separa por traço: ex EUR-BRL");
        dados.moeda = Console.ReadLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "https://economia.awesomeapi.com.br/last/" + dados.moeda;

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseBody);

                // Exibindo os dados do dados do IP
                if (dados.moeda == "USD-BRL")
                {
                    Console.WriteLine($"code: {root.USDBRL.code}");
                    Console.WriteLine($"code in: {root.USDBRL.codein}");
                    Console.WriteLine($"nome: {root.USDBRL.name}");
                    Console.WriteLine($"ask: {root.USDBRL.ask}");
                    Console.WriteLine($"date: {root.USDBRL.create_date}");
                }
                else if (dados.moeda == "EUR-BRL")
                {
                    Console.WriteLine($"code:{root.EURBRL.code}");
                    Console.WriteLine($"code: {root.EURBRL.codein}");
                    Console.WriteLine($"nome: {root.EURBRL.name}");
                    Console.WriteLine($"ask: {root.EURBRL.ask}");
                    Console.WriteLine($"date: {root.EURBRL.create_date}");

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            Console.ReadLine();
        }
        goto Menu;
    case 2:
        Console.WriteLine("Digite a moeda separa por traço: ex EUR-BRL");
        dados.moeda = Console.ReadLine();
        Console.WriteLine("Digite a moeda separa por traço: ex EUR-BRL");
        dados.quantidade = int.Parse(Console.ReadLine());
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "https://economia.awesomeapi.com.br/json/daily/" + dados.moeda + "/" + dados.quantidade;

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                List<Root> root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(responseBody);

                // Exibindo os dados do dados do IP

                foreach (var item in root)
                {


                    Console.WriteLine($"REGIÃO: {item.name}");
                    Console.WriteLine($"REGIÃO: {item.high}");
                    Console.WriteLine($"REGIÃO: {item.low}");
                    Console.WriteLine($"REGIÃO: {item.create_date}");



                }




            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            Console.ReadLine();
        }
        goto Menu;
        case 3:
        Console.WriteLine("Digite a moeda separa por traço: ex EUR-BRL");
        dados.moeda = Console.ReadLine();
        Console.WriteLine("Digite a moeda separa por traço: ex EUR-BRL");
        dados.startDate = Console.ReadLine();
        Console.WriteLine("Digite a moeda separa por traço: ex EUR-BRL");
        dados.endDate = Console.ReadLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "https://economia.awesomeapi.com.br/json/daily/" + dados.moeda + "/?start_date=" + dados.startDate + "&end_date=" + dados.endDate;

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                List<Root> root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(responseBody);

                // Exibindo os dados do dados do IP
                foreach(var item in root)
                {

                    
                        Console.WriteLine($"REGIÃO: {item.name}");
                        Console.WriteLine($"REGIÃO: {item.high}");
                        Console.WriteLine($"REGIÃO: {item.low}");
                        Console.WriteLine($"REGIÃO: {item.create_date}");
                             

                }
                

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            Console.ReadLine();
        }
        goto Menu;
}