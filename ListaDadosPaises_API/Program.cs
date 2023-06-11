using System;
using System.Diagnostics.Metrics;
using API_ListaDadosPaises;

Menu:
Console.WriteLine("1 - Procurar por moeda: ");
Console.WriteLine("2 - Procurar por Continente");
Console.WriteLine("3 - Sair");
int menu = int.Parse(Console.ReadLine());

DadosPais dados = new DadosPais();

switch (menu)
{
    case 1:
        Console.WriteLine("Digite a moeda para consulta dos países:");
        dados.recebeMoeda = Console.ReadLine();
        Console.WriteLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://restcountries.com/v3.1/currency/{dados.recebeMoeda}?fields=name,capital";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON
                List<DadosPais> dadosPaises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DadosPais>>(responseBody);
                
                // Exibindo os dados dos paises                             
                foreach (var item in dadosPaises)
                {
                    if (dados.recebeMoeda == "euro" || dados.recebeMoeda == "EURO")
                    {
                        Console.WriteLine("Nome nativo oficial do pais: " + item.name.nativeName.cat.official);
                        Console.WriteLine("Nome nativo do pais: " + item.name.nativeName.cat.common);
                    }
                    else if (dados.recebeMoeda == "dollar" || dados.recebeMoeda == "DOLLAR")
                    {
                        Console.WriteLine("Nome nativo oficial do pais: " + item.name.nativeName.cal.official);
                        Console.WriteLine("Nome nativo do pais: " + item.name.nativeName.cal.common);
                    }
                    else if (dados.recebeMoeda == "real" || dados.recebeMoeda == "REAL")
                    {
                        Console.WriteLine("Nome nativo oficial do pais: " + item.name.nativeName.por.official);
                        Console.WriteLine("Nome nativo do pais: " + item.name.nativeName.por.common);
                    }
                    break;
                }
                foreach (var item in dadosPaises)
                {
                    Console.WriteLine("Nome do pais : " + item.name.common);
                    Console.WriteLine("Nome oficial: " + item.name.official);
                    Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                }
                Console.WriteLine();
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
        Console.WriteLine("Enter..");
        Console.ReadLine();
        goto Menu;
    case 2:
        Console.WriteLine("Digite o continente para consultar os países e suas moedas:");
        dados.recebeRegiao = Console.ReadLine();
        Console.WriteLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://restcountries.com/v3.1/region/{dados.recebeRegiao}? fields=currencies";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<DadosPais> dadosContinente = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DadosPais>>(responseBody);

                foreach (var item in dadosContinente)
                {
                    if (dados.recebeRegiao == "america" || dados.recebeRegiao == "America")
                    {
                        Console.WriteLine(item.currencies.BBD.name + ": " + item.currencies.BBD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "oceania" || dados.recebeRegiao == "Oceania")
                    {
                        Console.WriteLine(item.currencies.USD.name + " " + item.currencies.USD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "africa" || dados.recebeRegiao == "Africa")
                    {
                        Console.WriteLine(item.currencies.MWK.name + " " + item.currencies.MWK.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "asia" || dados.recebeRegiao == "Asia")
                    {
                        Console.WriteLine(item.currencies.JOD.name + " " + item.currencies.JOD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "europe" || dados.recebeRegiao == "Europe")
                    {
                        Console.WriteLine(item.currencies.RSD.name + " " + item.currencies.RSD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    continue;
                }
                Console.WriteLine();
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
        Console.WriteLine("Enter..");
        Console.ReadLine();
        goto Menu;
    case 3:
    default:
        break;
}