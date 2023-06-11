using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using BuscaCEP_API;

using (HttpClient client = new HttpClient())
{
    try
    {
        DadosCEP dados = new DadosCEP();

        Console.WriteLine("Digite o CEP :");
        dados.recebeCEP = Console.ReadLine();
        string url = "https://ipapi.co/" + dados.recebeCEP + "/json/";

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        DadosCEP DadosIP = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosCEP>(responseBody);

        Console.WriteLine($"CEP: {dados.cep}");
        Console.WriteLine($"Logradouro: {dados.logradouro}");
        Console.WriteLine($"complemento: {dados.complemento}");
        Console.WriteLine($"bairro: {dados.bairro}");
        Console.WriteLine($"localidade: {dados.localidade}");
        Console.WriteLine($"UF: {dados.uf}");
        Console.WriteLine($"IBGE: {dados.ibge}");
        Console.WriteLine($"DDD: {dados.ddd}");
        Console.WriteLine($"SIAFI: {dados.siafi}");
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
