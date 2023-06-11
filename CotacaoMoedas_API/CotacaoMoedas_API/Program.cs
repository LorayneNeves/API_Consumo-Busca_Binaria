using CotacaoMoedas_API;
using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;
Menu:
Console.WriteLine("1 - Procurar por moeda: ");
Console.WriteLine("2 - Procurar por moeda e quantidade");
Console.WriteLine("3 - Procurar por moeda e data");
Console.WriteLine("4 - Sair");
int menu = int.Parse(Console.ReadLine());

Root dados = new Root();

switch (menu)
{
    case 1:
        Console.WriteLine("Digite as moedas que deseja consultar: ");
        Console.WriteLine("Primeira moeda: ");
        dados.moeda1 = Console.ReadLine();
        Console.WriteLine("Segunda moeda");
        dados.moeda2 = Console.ReadLine();
        Console.WriteLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://economia.awesomeapi.com.br/last/{dados.moeda1}-{dados.moeda2}";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseBody);

                if (dados.moeda1 == "USD" || dados.moeda1 == "usd" && dados.moeda2 == "BRL" || dados.moeda2 == "brl")
                {
                    Console.WriteLine($"code: {root.USDBRL.code}");
                    Console.WriteLine($"code in: {root.USDBRL.codein}");
                    Console.WriteLine($"nome: {root.USDBRL.name}");
                    Console.WriteLine($"high: {root.USDBRL.high}");
                    Console.WriteLine($"low: {root.USDBRL.low}");
                    Console.WriteLine($"varBid: {root.USDBRL.varBid}");
                    Console.WriteLine($"pctChange: {root.USDBRL.pctChange}");
                    Console.WriteLine($"bid: {root.USDBRL.bid}");
                    Console.WriteLine($"ask: {root.USDBRL.ask}");
                    Console.WriteLine($"date: {root.USDBRL.create_date}");
                    Console.WriteLine();
                }
                else if (dados.moeda1 == "EUR" || dados.moeda1 == "eur" && dados.moeda2 == "BRL" || dados.moeda2 == "brl")
                {
                    Console.WriteLine($"code: {root.EURBRL.code}");
                    Console.WriteLine($"code in: {root.EURBRL.codein}");
                    Console.WriteLine($"nome: {root.EURBRL.name}");
                    Console.WriteLine($"high: {root.EURBRL.high}");
                    Console.WriteLine($"low: {root.EURBRL.low}");
                    Console.WriteLine($"varBid: {root.EURBRL.varBid}");
                    Console.WriteLine($"pctChange: {root.EURBRL.pctChange}");
                    Console.WriteLine($"bid: {root.EURBRL.bid}");
                    Console.WriteLine($"ask: {root.EURBRL.ask}");
                    Console.WriteLine($"date: {root.EURBRL.create_date}");
                    Console.WriteLine();
                }
                else if(dados.moeda1 == "BTC" || dados.moeda1 == "btc" && dados.moeda2 == "BRL" || dados.moeda2 == "brl")
                {
                    Console.WriteLine($"code: {root.BTCBRL.code}");
                    Console.WriteLine($"code in: {root.BTCBRL.codein}");
                    Console.WriteLine($"nome: {root.BTCBRL.name}");
                    Console.WriteLine($"high: {root.BTCBRL.high}");
                    Console.WriteLine($"low: {root.BTCBRL.low}");
                    Console.WriteLine($"varBid: {root.BTCBRL.varBid}");
                    Console.WriteLine($"pctChange: {root.BTCBRL.pctChange}");
                    Console.WriteLine($"bid: {root.BTCBRL.bid}");
                    Console.WriteLine($"ask: {root.BTCBRL.ask}");
                    Console.WriteLine($"date: {root.BTCBRL.create_date}");
                    Console.WriteLine();
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
            Console.Write("Enter...");
            Console.ReadLine();
        }
        goto Menu;
    case 2:
        Console.WriteLine("Digite as moedas que deseja consultar: ");
        Console.WriteLine("Primeira moeda: ");
        dados.moeda1 = Console.ReadLine();
        Console.WriteLine("Segunda moeda");
        dados.moeda2 = Console.ReadLine();
        Console.WriteLine("Digite a quantidade de numeros para retornar");
        dados.quantidade = int.Parse(Console.ReadLine());
        Console.WriteLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://economia.awesomeapi.com.br/json/daily/{dados.moeda1}-{dados.moeda2}/{dados.quantidade}";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<Root> root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(responseBody);
             
                foreach (var item in root)
                {
                    Console.WriteLine($"nome: {item.name}");
                    Console.WriteLine($"alto: {item.high}");
                    Console.WriteLine($"baixo: {item.low}");
                    Console.WriteLine($"code: {item.code}");
                    Console.WriteLine($"codin: {item.codein}");
                    Console.WriteLine($"data criada: {item.create_date}");
                    Console.WriteLine($"varBid: {item.varBid}");
                    Console.WriteLine($"pctChange: {item.pctChange}");
                    Console.WriteLine($"bid: {item.bid}");
                    Console.WriteLine($"ask: {item.ask}");
                    Console.WriteLine($"times tamp: {item.timestamp}");
                    Console.WriteLine();
                    break;
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
            Console.Write("Enter...");
            Console.ReadLine();
        }
        goto Menu;
        case 3:
        Console.WriteLine("Digite as moedas que deseja consultar: ");
        Console.WriteLine("Primeira moeda: ");
        dados.moeda1 = Console.ReadLine();
        Console.WriteLine("Segunda moeda");
        dados.moeda2 = Console.ReadLine();
        Console.WriteLine("Digite a data inicial, exemplo: 20230501");
        dados.startDate = Console.ReadLine();
        Console.WriteLine("Digite a data final, exemplo: 20230530");
        Console.WriteLine();
        dados.endDate = Console.ReadLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://economia.awesomeapi.com.br/json/daily/{dados.moeda1}-{dados.moeda2}/?start_date={dados.startDate}&end_date={dados.endDate}";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                List<Root> root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(responseBody);

                // Exibindo os dados do dados do IP
                
                foreach(var item in root)
                {                  
                    Console.WriteLine($"nome: {item.name}");
                    Console.WriteLine($"alto: {item.high}");
                    Console.WriteLine($"baixo: {item.low}");
                    Console.WriteLine($"code: {item.code}");
                    Console.WriteLine($"codigo: {item.codein}");
                    Console.WriteLine($"data criada: {item.create_date}");
                    Console.WriteLine($"varBid: {item.varBid}");
                    Console.WriteLine($"pctChange: {item.pctChange}");
                    Console.WriteLine($"bid: {item.bid}");
                    Console.WriteLine($"ask: {item.ask}");
                    Console.WriteLine($"times tamp: {item.timestamp}");
                    Console.WriteLine();
                    break;
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
            Console.Write("Enter...");
            Console.ReadLine();
        }
        goto Menu;
    case 4:
    default:
    break;
}