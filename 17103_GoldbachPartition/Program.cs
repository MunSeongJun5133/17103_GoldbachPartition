using System;
using System.Text;

namespace _17103_GoldbachPartition
{
    internal class Program
    {
        /*static void Main(string[] args)
        {
            Int32 t = Int32.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for(Int32 i = 0; i < t; i++)
            {
                Int32 n = Int32.Parse(Console.ReadLine());
                if (n % 2 != 0)
                    return;
                
                sb.AppendLine(CountGP(n).ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        static Int32 CountGP(Int32 n)
        {
            Int32 count = 0;

            Boolean[] check = new Boolean[n + 1];

            for(Int32 i = 2; i <= n ; i++)
            {
                if(isPrime(i) && isPrime(n - i))
                {
                    if (check[i] && check[n - i])
                        continue;
                    check[i] = true;
                    check[n - i] = true;    
                    count++;
                }
            }

            return count;
        }

        static Boolean isPrime(Int32 n)
        {
            if(n < 2)
                return false;
            if (n % 2 == 0)
                return false;
            if(n == 2)
                return true;

            for(Int32 i = 3; i <= (Int32)Math.Sqrt(n) + 1 ; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }*/ //에라토스테네스의 체를 사용하지 않아 시간초과됨

        static void Main(string[] args)
        {
            Int32 t = Int32.Parse(Console.ReadLine());
            Boolean[] isPrime = new Boolean[1000001];

            //에라토스테네스의 체를 이용하여 소수 찾기
            for(Int32 i = 2; i < isPrime.Length; i++)
                isPrime[i] = true;

            for(Int32 i = 2; i * i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    for (Int32 j = i * i; j < isPrime.Length; j += i)
                        isPrime[j] = false;
                }
            }

            StringBuilder sb = new StringBuilder();

            for(Int32 i = 0; i < t; i++)
            {
                Int32 count = 0;

                Int32 n = Int32.Parse(Console.ReadLine());

                for(Int32 j = 2; j <= n / 2; j++)
                    if (isPrime[j] && isPrime[n - j])
                        count++;

                sb.AppendLine(count.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
