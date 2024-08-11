using System;
using System.Collections.Generic;
using System.Linq;

public class DeliveryProblem
{
    private int[,] costMatrix; // Ma trận chi phí
    private int n; // Số lượng địa điểm
    private int start; // Điểm bắt đầu
    public static void Main()
    {
        int[,] cost = {
            {0, 18, 10, 20},
            {10, 0, 32, 0},
            {25, 37, 0, 30},
            {20, 25, 30, 0}
        };
        int startCity = 0;
        DeliveryProblem dp = new DeliveryProblem(cost, startCity);
        dp.Solve();
        Console.ReadKey();
    }
    public DeliveryProblem(int[,] costMatrix, int start)
    {
        this.costMatrix = costMatrix;
        this.n = costMatrix.GetLength(0);
        this.start = start;
    }
    public (int, List<int>) FindMinCost(HashSet<int> visited, int current)
    {
        // Nếu đã đi qua tất cả các địa điểm, quay về điểm bắt đầu
        if (visited.Count == n)
        {
            return (costMatrix[current, start], new List<int> { start });
        }

        int minCost = int.MaxValue;
        List<int> minPath = null;
        for (int i = 0; i < n; i++)
        {
            if (!visited.Contains(i))
            {
                visited.Add(i);
                (int newCost, List<int> newPath) = FindMinCost(visited, i);
                newPath.Insert(0, i); // Thêm điểm hiện tại vào đầu đường đi
                newCost += costMatrix[current, i];
                if (newCost < minCost)
                {
                    minCost = newCost;
                    minPath = newPath;
                }
                visited.Remove(i);
            }
        }
        return (minCost, minPath);
    }
    public void Solve()
    {
        HashSet<int> visited = new HashSet<int>();
        visited.Add(start);
        (int minCost, List<int> minPath) = FindMinCost(visited, start);
        minPath.Insert(0, start); // Thêm điểm bắt đầu vào đầu đường đi
        Console.WriteLine("Chi phi toi thieu: " + minCost);
        Console.WriteLine("Duong di: " + string.Join(" -> ", minPath));
    }
}
