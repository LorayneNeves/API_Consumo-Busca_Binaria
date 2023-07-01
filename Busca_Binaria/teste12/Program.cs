using System;
using System.Collections.Immutable;

class Program
{
    static int BuscaBinaria(string[] vetor, string valorBuscado)
    {
        int inicio = 0;

        int fim = vetor.Length - 1;

        while (inicio <= fim)
        {
            int meio = (inicio + fim) / 2;

            if (string.Compare(vetor[meio], valorBuscado) == 0)
            {
                return meio;
            }
            else if (String.Compare(vetor[meio], valorBuscado) == -1)
            {
                inicio = meio + 1;
            }
            else
            {
                fim = meio - 1;
            }
        }
        return -1;
    }
    static void Main(string[] args)
    {
        string[] vetor = { "alce", "cachorro", "cavalo", "gaivota", "gato", "papagaio", "peixe", "tartaruga" };
        Console.WriteLine("digite uma palavra para buscar: ");
        string valorBuscado = Console.ReadLine();

        int indice = BuscaBinaria(vetor, valorBuscado);

        if (indice == -1)
        {
            Console.WriteLine("O valor {0} não foi encontrado.", valorBuscado);
        }
        else
        {
            Console.WriteLine($"O valor '{valorBuscado}' foi encontrado na posição {indice}.");
        }
    }
}
