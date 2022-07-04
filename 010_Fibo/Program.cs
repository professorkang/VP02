using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.Write("n항까지의 피보나치 수열 : ");
      int n=int.Parse(Console.ReadLine());
      //Console.WriteLine("Fibonacci 수열의 n 항 = {0}",
      //  Fibo(n));
      for (int i = 1; i <= n; i++)
      {
        Console.WriteLine("Fibo({0}) = {1}", i,Fibo(i));
      }
    }

    private static int Fibo(int n)
    {
      if (n == 1 || n == 2)
        return 1;
      else
        return Fibo(n - 1) + Fibo(n - 2);
    }
  }
}