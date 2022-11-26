using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.Write("s vector length: ");
        int[] s = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < s.Length; i++)
        {
            s[i] = i;

        }
        Console.Write("k vector: ");
        string key = Console.ReadLine();
        int[] k = new int[key.Split(' ').Length];
        for (int i = 0; i < k.Length; i++)
        {
            k[i] = int.Parse(key.Split(' ')[i]);
        }
        Console.Write("p vector: ");
        string text = Console.ReadLine();
        int[] p = new int[text.Split(' ').Length];
        for (int i = 0; i < p.Length; i++)
        {
            p[i] = int.Parse(text.Split(' ')[i]);
        }
        int[] t = new int[s.Length];
        int num = 0;
        for (int i = 0; i < t.Length; i++)
        {
            if (num == k.Length)
            {
                num = 0;
            }
            t[i] = k[num++];
        }
        Console.WriteLine("==========");
        printNewVector('P', p);
        printNewVector('K', k);
        printNewVector('S', s);
        printNewVector('T', t);
        Console.WriteLine();
        Console.WriteLine("==========");
        Console.WriteLine("S-Vector Initial Permutation");
        SInitPermutation(s, t);
        Console.WriteLine("==========");
        Console.WriteLine("Stream Generation");
        StreamGen(p, s);
        Console.ReadKey();
    }

    private static void printNewVector(char n, int[] v)
    {
        Console.Write(n + "=[");
        for (int i = 0; i < v.Length; i++)
        {
            if (i == v.Length - 1)
            {
                Console.Write(v[i]);
                Console.Write("]");
            }
            else
            {
                Console.Write(v[i] + " ");
            }
        }
        Console.WriteLine();
    }

    private static void SInitPermutation(int[] s, int[] t)
    {
        int j = 0;
        for (int i = 0; i < s.Length; i++)
        {
            j = (j + s[i] + t[i]) % s.Length;
            Console.WriteLine("i= " + i + " , j=" + j);
            int num2 = s[i];
            s[i] = s[j];
            s[j] = num2;
            printNewVector('S', s);
        }
    }

    private static void StreamGen(int[] p, int[] s)
    {
        int j = 0;
        int t = 0;
        int k = 0;
        int i = 0;
        int[] c = new int[p.Length];
        for (int m = 0; m < p.Length; m++)
        {
            i = (i + 1) % s.Length;
            j = (j + s[i]) % s.Length;
            Console.WriteLine("i= " + i + " , j=" + j);
            int num2 = s[i];
            s[i] = s[j];
            s[j] = num2;
            printNewVector('S', s);
            t = (s[i] + s[j]) % s.Length;
            Console.WriteLine("t= " + t);
            k = s[t];
            Console.WriteLine(k + " XOR " + p[m]);
            Console.WriteLine();
            c[m] = k ^ p[m];
        }
        printNewVector('C', c);
    }

}