// See https://aka.ms/new-console-template for more information

// int a[10];
int[] a = new int[10];
Random r = new Random();

for (int i = 0; i < 10; i++)
{
  a[i] = r.Next(100);
}

for (int i = 0; i < 10; i++)
{
  Console.WriteLine(a[i]);
}

Console.WriteLine();

foreach (var item in a)
{
  Console.WriteLine(item);
}

int min = a[0];
int max = a[0];
int sum = 0;

foreach (var item in a)
{
  if(item > max)
    max = item;
  if(item < min)
    min = item;
  sum += item;
}

Console.WriteLine("min = " + min);
Console.WriteLine("max = {0}", max);
Console.WriteLine("평균 = {0}", sum / 10.0); ;


