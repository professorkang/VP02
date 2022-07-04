// See https://aka.ms/new-console-template for more information

//Console.Write("정수 하나를 입력하세요: ");
//int n = int.Parse(Console.ReadLine());

//Console.WriteLine("결과는 {0}", Fact(n));

//int Fact(int n)
//{
//  if (n == 1)
//    return 1;
//  else
//    return Fact(n - 1) * n;
//}

using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.Write("정수 하나를 입력하세요: ");
      int n = int.Parse(Console.ReadLine());

      Console.WriteLine("결과는 {0}", Fact(n));
    }

    private static int Fact(int n)
    {
      if (n == 1)
        return 1;
      else
        return Fact(n - 1) * n;
    }
  }
}