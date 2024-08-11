using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKTT_BTL3
{
    struct Item
    {
        public string Ten;
        public int Trong_luong;
        public int Gia_tri;
        public int Phuong_an;
    }
    class Bai2
    {
        static void Main(string[] args)
        {
            // Nhập dữ liệu
            Console.Write("Nhap so luong do vat: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap trong tai cua ba lo: ");
            int W = int.Parse(Console.ReadLine());
            // Khởi tạo mảng các đồ vật
            Item[] items = new Item[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin do vat {i + 1}:");
                Console.Write("Ten: ");

                items[i].Ten = Console.ReadLine();
                Console.Write("Trong luong: ");
                items[i].Trong_luong = int.Parse(Console.ReadLine());
                
                Console.Write("Gia tri: ");
                items[i].Gia_tri = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
            }
            // Tính toán bảng quy hoạch động
            int[,] F = new int[n + 1, W + 1];
            int[,] X = new int[n + 1, W + 1];

            for (int k = 1; k <= n; k++)
            {
                for (int v = 1; v <= W; v++)
                {
                    if (items[k - 1].Trong_luong > v)
                    {
                        F[k, v] = F[k - 1, v];
                        X[k, v] = 0;
                    }
                    else
                    {
                        int opt1 = F[k - 1, v];
                        int opt2 = items[k - 1].Gia_tri + F[k - 1, v - items[k - 1].Trong_luong];
                        if (opt1 >= opt2)
                        {
                            F[k, v] = opt1;
                            X[k, v] = 0;
                        }
                        else
                        {
                            F[k, v] = opt2;
                            X[k, v] = 1;
                        }
                    }
                }
            }
            Console.WriteLine($"Gia tri toi da: {F[n, W]}");
            int remaining_weight = W;
            for (int k = n; k >= 1; k--)
            {
                if (X[k, remaining_weight] == 1)
                {
                    items[k - 1].Phuong_an = 1;
                    remaining_weight -= items[k - 1].Trong_luong;
                }
                else
                {
                    items[k - 1].Phuong_an = 0;
                }
            }
            Console.WriteLine("Cac do vat duoc chon trong phuong an toi uu:");
            for (int i = 0; i < n; i++)
            {
                if (items[i].Phuong_an == 1)
                {
                    Console.WriteLine($"- {items[i].Ten} (Trong luong: {items[i].Trong_luong}, Gia tri: {items[i].Gia_tri})");
                }
            }

            Console.ReadKey();
        }
    }
}
