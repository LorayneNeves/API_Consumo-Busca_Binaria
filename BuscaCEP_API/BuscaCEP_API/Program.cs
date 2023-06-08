using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using BuscaCEP_API;

DadosCEP dados = new DadosCEP();
Console.WriteLine("Digite o CEP :");
dados.recebeCEP = Console.ReadLine();

using (HttpClient client = new HttpClient())
{
    try
    {
        DadosCEP dados1 = new DadosCEP();

        string url = "https://ipapi.co/" + dados1.recebeCEP + "/json/";

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        // Fazendo o parsing da resposta JSON

        DadosCEP DadosIP = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosCEP>(responseBody);

        // Exibindo os dados do dados do CEP
        Console.WriteLine($"IP: {dados.cep}");
        Console.WriteLine($"REDE: {dados.logradouro}");
        Console.WriteLine($"VERSÃO: {dados.complemento}");
        Console.WriteLine($"CIDADE: {dados.bairro}");
        Console.WriteLine($"REGIÃO: {dados.localidade}");
        Console.WriteLine($"CODIGO REGIÃO: {dados.uf}");
        Console.WriteLine($"PAIS: {dados.ibge}");
        Console.WriteLine($"NOME PAIS: {dados.ddd}");
        Console.WriteLine($"NOME CODIGO: {dados.siafi}");
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
