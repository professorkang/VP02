// See https://aka.ms/new-console-template for more information
// 10개의 랜덤숫자를 배열에 저장하고 출력하세요

int[] a = new int[10];
Random r = new Random();

for (int i = 0; i < a.Length; i++)
  a[i] = r.Next(1000);

for (int i = 0; i < a.Length; i++)
  Console.WriteLine(a[i]);

// 정렬(버블정렬)
for(int i = 0; i < a.Length-1; i++)
  for (int j = i+1; j < a.Length; j++)
  {
    // 두 숫자를 swap 하는 코딩
    if(a[i] > a[j])
    {
      int t =a[i];
      a[i] = a[j];
      a[j] = t;
    }
  }

Console.WriteLine("정렬 후:");
for (int i = 0; i < a.Length; i++)
  Console.WriteLine(a[i]);