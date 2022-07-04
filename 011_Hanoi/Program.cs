using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Hanoi(5, 'A', 'B', 'C');
    }

    // n개의 원반을 f에서 v를 거쳐 t로 보내는 함수(메소드)
    private static void Hanoi(int n, char f, char v, char t)
    {
      if(n == 1)
        Console.WriteLine("{0}=>{1}", f, t);
      else
      {
        Hanoi(n - 1, f, t, v);
        Console.WriteLine("{0}=>{1}", f, t);
        Hanoi(n - 1, v, f, t);
      }
    }
  }
}
