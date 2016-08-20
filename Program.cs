using System;
using System.Collections.Generic;
using System.Text;

namespace MaxWeight
{
    class Program
    {
        static int[] Path(int[,] array)
        {
            int size = array.GetLength(1);
            int[,] temp = new int[size, size];
            temp[0, 0] = array[0, 0];
            for(int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (temp[i + 1, j] < temp[i, j] + array[i + 1, j])
                        temp[i + 1, j] = temp[i, j] + array[i + 1, j];
                    temp[i + 1, j + 1] = temp[i, j] + array[i + 1, j + 1];
                }
            }
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write("{0,4}",temp[i, j]);
                Console.WriteLine();
            }
            int[] ans = new int[size];
            int count = 0; 
            int maxId = 0;
            for (int j = 0; j < size; j++)
                if (temp[size - 1, maxId] < temp[size - 1, j]) maxId = j;
            ans[count++] = array[size - 1, maxId];
            for (int i = size - 2; i >=0; i--)
            {
                if (maxId == 0) { }
                else if (maxId > i) maxId--;
                else
                    if (temp[i, maxId - 1] > temp[i, maxId]) maxId--;
                    else { }               
                ans[count++] = array[i, maxId];
            }
            return ans;
        }
        static void Main(string[] args)
        {
            string[] s = System.IO.File.ReadAllLines("D:/triangle.txt");
            int[,] baseArr = new int[s.Length,s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                string[] ss = s[i].Split(' ');
                for (int j = 0; j < ss.Length; j++)
                    baseArr[i, j] = Convert.ToInt32(ss[j]);
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                    Console.Write("{0,4}",baseArr[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
            int[] arr = Path(baseArr);
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " + ");
                count += arr[i];
            }
            Console.WriteLine();
            Console.Write(" = " + count);
            Console.ReadKey();
        }
    }
}
