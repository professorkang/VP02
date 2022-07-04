// See https://aka.ms/new-console-template for more information
Pyramid(5);
Pyramid(7);
Pyramid(15);

void Pyramid(int n)
{
  for (int i = 1; i <= n; i++)
  {
    for (int j = 0; j < n - i; j++)
    {
      Console.Write(" ");
    }
    for (int j = 0; j < 2 * i - 1; j++)
    {
      Console.Write("*");
    }
    Console.WriteLine();
  }
}



for (int i = 1; i <= 5; i++)
{
  for (int j = 0; j < i; j++)
  {
    Console.Write("*");
  }
  Console.WriteLine();
}

for (int i = 1; i <= 5; i++)
{
  for (int j = 0; j < 5-i; j++)
  {
    Console.Write(" ");
  }
  for (int j = 0; j < i; j++)
  {
    Console.Write("*");
  }
  Console.WriteLine();
}