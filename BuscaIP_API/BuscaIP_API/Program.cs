using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using BuscaIP_API;

DadosIP dados = new DadosIP();
Console.WriteLine("Digite o IP:");
dados.recebeIP = Console.ReadLine();

using (HttpClient client = new HttpClient())
{
    try
    {
        DadosIP dados1 = new DadosIP();

        string url = $"https://ipapi.co/{dados1.recebeIP}/json/";

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        // Fazendo o parsing da resposta JSON

        DadosIP DadosIP = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosIP>(responseBody);

        // Exibindo os dados do dados do IP
        Console.WriteLine($"IP: {dados.ip}");
        Console.WriteLine($"REDE: {dados.network}");
        Console.WriteLine($"VERSÃO: {dados.version}");
        Console.WriteLine($"CIDADE: {dados.city}");
        Console.WriteLine($"REGIÃO: {dados.region}");
        Console.WriteLine($"CODIGO REGIÃO: {dados.region_code}");
        Console.WriteLine($"PAIS: {dados.country}");
        Console.WriteLine($"NOME PAIS: {dados.country_name}");
        Console.WriteLine($"NOME CODIGO: {dados.country_code}");
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
