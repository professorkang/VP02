// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.Write("숫자를 하나 입력하세요 : ");
      int a = int.Parse(Console.ReadLine());
      Console.Write("숫자를 하나 입력하세요 : ");
      int b = int.Parse(Console.ReadLine());
      Console.Write("숫자를 하나 입력하세요 : ");
      int c = int.Parse(Console.ReadLine());

      Console.WriteLine("{0}, {1}, {2}", a, b, c);
      int max = Larger(Larger(a, b), c);
      Console.WriteLine("최대값 = {0}", max);
    }

    private static int Larger(int a, int b)
    {      
      if (a > b)
        return a;
      else
        return b;     
    }
  }
}


//int l = Larger(a, b);
//int max = Larger(l, c);







