class Program
{
    static void Main(string[] args)
    {
        int[] vetor = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };       
    menu:
        Console.WriteLine("Escolha uma das opções: ");
        Console.WriteLine("1 – Inserir no vetor");
        Console.WriteLine("2 – Buscar no vetor por busca binária");
        Console.WriteLine("3 – Buscar no vetor por busca sequencial");
        Console.WriteLine("4 - Sair ");

        int menu = int.Parse(Console.ReadLine());

        switch (menu)
        {
            case 1:
                Console.WriteLine("Digite um valor para inserir no vetor: ");
                int valorInserir =int.Parse(Console.ReadLine());

                int[] novoVetor = new int[vetor.Length + 1];

                for (int i = 0; i < vetor.Length; i++)
                {
                    novoVetor[i] = vetor[i];
                }

                novoVetor[vetor.Length] = valorInserir;

                vetor = novoVetor;

                Console.WriteLine("Vetor atualizado:");
                for (int i = 0; i < vetor.Length; i++)
                {
                    Console.WriteLine(vetor[i]);
                }
        
            goto menu;
            case 2:
                Console.Write("Digite um número para buscar na lista: ");
                int valorBuscado = int.Parse(Console.ReadLine());

                int indice = BuscaBinaria(vetor, valorBuscado);

                if (indice == -1)
                {

                    Console.WriteLine("O valor {0} não foi encontrado.", valorBuscado);

                }

                else
                {

                    Console.WriteLine("O valor {0} foi encontrado na posição {1}.", valorBuscado, indice);

                }
           goto menu;
           case 3:
               Console.Write("Digite um número para buscar na lista: ");
               int valorBusca = int.Parse(Console.ReadLine());

                indice = BuscaSequencial(vetor, valorBusca);

               if (indice != -1)
                   Console.WriteLine($"O valor {valorBusca} foi encontrado na posição {indice} da lista.");
               else
                   Console.WriteLine($"O valor {valorBusca} não foi encontrado na lista.");              
           goto menu;

           case 4: break; 
        }
    }
    static int BuscaBinaria(int[] vetor, int valorBuscado)
    {

        int inicio = 0;

        int fim = vetor.Length - 1;

        while (inicio <= fim)
        {

            int meio = (inicio + fim) / 2;

            if (vetor[meio] == valorBuscado)
            {

                return meio;

            }

            else if (vetor[meio] < valorBuscado)
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

    static int BuscaSequencial(int[] vetor, int valor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] == valor)
                return i; 
        }
        return -1; 
    }

}