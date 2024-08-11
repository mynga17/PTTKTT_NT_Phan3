using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKTT_BTL3
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 2;
            int n = 4;
            int result = TinhToHop_DP_CaiTien(n, k);
            Console.WriteLine($"To hop chap {k} cua {n} phan tu la {result}");
            Console.ReadKey();
        }

        static int TinhToHop_DP_CaiTien(int n, int k)
        {
            int[] V = new int [n + 1] ;
            int p1, p2;
            V[0] = 1;
            V[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                p1 = V[0];
                for (int j = 1; j < i; j++)
                {
                    p2 = V[j];
                    V[j] = p1 + p2;
                    p1 = p2;
                }
                V[i] = 1;
            }
            return V[k];
        }
    }
}
