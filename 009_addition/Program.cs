using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.Write("정수 입력 : ");
      int n = int.Parse(Console.ReadLine());
      Console.WriteLine("1~n까지의 합 : {0}", Add(n));
    }

    private static int Add(int n)
    {
      if (n == 1)
        return 1;
      else
        return Add(n - 1) + n;
    }
  }
}