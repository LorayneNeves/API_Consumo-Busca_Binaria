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

        using (HttpClient client = new HttpClient())
        {
            try
            {
                DadosPais dados1 = new DadosPais();

                string url = "https://restcountries.com/v3.1/currency/" + dados.recebeMoeda + "?fields=name,capital";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                List<DadosPais> dadosPaises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DadosPais>>(responseBody);
                // Exibindo os dados dos paises

                foreach (var item in dadosPaises)
                {
                    Console.WriteLine("Nome do pais : " + item.name.common);
                    Console.WriteLine("Nome oficial: " + item.name.official);
                    //Console.WriteLine("Nome nativo do pais: " + item.name.nativeName.por.common);
                    //Console.WriteLine("Nome nativo do pais: " + item.name.nativeName.por.official);
                    Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
                Console.WriteLine("Tente novamente...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                Console.WriteLine("Tente novamente...");
            }
        }
        goto Menu;
    case 2:
        Console.WriteLine("Digite o continente para consultar os países e suas moedas:");
        dados.recebeRegiao = Console.ReadLine();

        using (HttpClient client = new HttpClient())
        {
            try
            {
                DadosPais dados1 = new DadosPais();

                string url = "https://restcountries.com/v3.1/region/" + dados.recebeRegiao + "? fields=currencies";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON

                List<DadosPais> dadosContinente = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DadosPais>>(responseBody);


                foreach (var item in dadosContinente)
                {
                    if (dados.recebeRegiao == "america")
                    {
                        Console.WriteLine(item.currencies.BBD.name + ": " + item.currencies.BBD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "oceania")
                    {
                        Console.WriteLine(item.currencies.USD.name + " " + item.currencies.USD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "africa")
                    {
                        Console.WriteLine(item.currencies.MWK.name + " " + item.currencies.MWK.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "asia")
                    {
                        Console.WriteLine(item.currencies.JOD.name + " " + item.currencies.JOD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.recebeRegiao == "europe")
                    {
                        Console.WriteLine(item.currencies.RSD.name + " " + item.currencies.RSD.symbol);
                        Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    }
                }
            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
                Console.WriteLine("Tente novamente...");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                Console.WriteLine("Tente novamente...");
            }
        }
        goto Menu;
    case 3:
    default:
        break;
}