class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um numero:");
        int n = int.Parse(Console.ReadLine());
        int resultado = DuploFatorial(n);
        Console.WriteLine($"Resultado: {resultado}");
    }
    static int DuploFatorial(int n)
    {
        if ((n == 1) || (n==0) ){ return 1; }
        return n * DuploFatorial(n - 2);      
    }
}