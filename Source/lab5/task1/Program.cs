Console.Write("Введите количество строк: ");
int stroka = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов: ");
int stolbec = int.Parse(Console.ReadLine());

Console.Write("Введите минимальное значение элемента: ");
int minValue = int.Parse(Console.ReadLine());

Console.Write("Введите максимальное значение элемента: ");
int maxValue = int.Parse(Console.ReadLine());

MyMatrix matrix = new MyMatrix(stroka, stolbec, minValue, maxValue);

Console.WriteLine("Исходная матрица:");
matrix.Show();

Console.WriteLine("\nИзменение размера матрицы...");
matrix.ChangeSize(4, 6);
Console.WriteLine("Измененная матрица:");
matrix.Show();

Console.WriteLine("\nЧасть матрицы:");
matrix.ShowPartialy(2, 4, 3, 5);

Console.WriteLine("\nУстановка значения в матрице:");
matrix[0, 0] = 95;
matrix.Show();

class MyMatrix
{
    private int[,] mx;
    public int Stolbec, Stroka;
    private Random rnd;
    private int MinValue, MaxValue;

    public MyMatrix(int stroka, int stolbec, int minValue, int maxValue)
    {
        Stolbec = stolbec;
        Stroka = stroka;
        mx = new int[Stroka, Stolbec];
        rnd = new Random();
        MinValue = minValue; MaxValue = maxValue;
        for (int i = 0; i < Stroka; i++)
        {
            for (int j = 0; j < Stolbec; j++)
            {
                mx[i, j] = rnd.Next(MinValue, MaxValue + 1);
            }
        }
    }

    public void Fill()
    {
        for (int i = 0; i < Stroka; i++)
        {
            for (int j = 0; j < Stolbec; j++)
            {
                mx[i, j] = rnd.Next();
            }
        }
    }
    public void ChangeSize(int stroka, int stolbec)
    {
        int[,] newMX = new int[stroka, stolbec];
        int i = 0, j = 0;
        int minStolbec = Math.Min(Stolbec, stolbec), minStroka = Math.Min(Stroka, stroka);
        rnd = new Random();

        while (i < minStroka)
        {
            j = 0;
            while (j < minStolbec)
            {
                newMX[i, j] = mx[i, j];
                ++j;
            }
            while (j < stolbec)
            {
                newMX[i, j] = rnd.Next(MinValue, MaxValue + 1);
                ++j;
            }
            ++i;
        }
        while (i < stroka)
        {
            j = 0;
            while (j < stolbec)
            {
                newMX[i, j] = rnd.Next(MinValue, MaxValue + 1);
                ++j;
            }
            ++i;
        }
        //(mx, newMX) = (newMX, mx);
        mx = newMX;
        (Stroka, Stolbec) = (stroka, stolbec);
    }
    public void ShowPartialy(int beginStroka, int beginStolbec, int endStroka, int endStolbec)
    {
        for (int i = beginStroka - 1; i < endStroka; ++i)
        {
            for (int j = beginStolbec - 1; j < endStolbec; ++j)
            {
                Console.Write("{0, 3}", mx[i, j]);
            }
            Console.WriteLine();
        }
    }
    public void Show()
    {
        ShowPartialy(1, 1, Stroka, Stolbec);
    }

    public int this[int i, int j]
    {
        get { return mx[i, j]; }
        set { mx[i, j] = value; }
    }

    public static MyMatrix operator +(MyMatrix lhs, MyMatrix rhs)
    {
        if ((lhs.Stroka != rhs.Stroka) || (lhs.Stolbec != rhs.Stolbec))
        {
            throw new ArgumentException("Размеры матриц должны быть одинаковыми");
        }

        MyMatrix rez = new MyMatrix(lhs.Stroka, lhs.Stolbec, 0, 0);
        for (int i = 0; i < lhs.Stroka; i++)
        {
            for (int j = 0; j < rhs.Stolbec; j++)
            {
                rez[i, j] = lhs[i, j] + rhs[i, j];
            }
        }
        return rez;
    }
    public static MyMatrix operator -(MyMatrix lhs, MyMatrix rhs)
    {
        if ((lhs.Stroka != rhs.Stroka) || (lhs.Stolbec != rhs.Stolbec))
        {
            throw new ArgumentException("Размеры матриц должны быть одинаковыми");
        }

        MyMatrix rez = new MyMatrix(lhs.Stroka, lhs.Stolbec, 0, 0);
        for (int i = 0; i < lhs.Stroka; i++)
        {
            for (int j = 0; j < rhs.Stolbec; j++)
            {
                rez[i, j] = lhs[i, j] - rhs[i, j];
            }
        }
        return rez;
    }
    public static MyMatrix operator *(MyMatrix lhs, MyMatrix rhs)
    {
        if (lhs.Stolbec != rhs.Stroka)
        {
            throw new ArgumentException("Кол-во столбцов первой матрицы должно быть равно кол-ву строк второй матрицы");
        }

        MyMatrix rez = new MyMatrix(lhs.Stroka, rhs.Stolbec, 0, 0);
        for (int i = 0; i < lhs.Stroka; i++)
        {
            for (int j = 0; j < rhs.Stolbec; j++)
            {
                for (int k = 0; k < lhs.Stolbec; k++)
                {
                    rez[i, j] += lhs[i, k] * rhs[k, j];
                }
            }
        }
        return rez;
    }
    public static MyMatrix operator *(MyMatrix lhs, int lambda)
    {
        MyMatrix rez = new MyMatrix(lhs.Stroka, lhs.Stolbec, 0, 0);

        for (int i = 0; i < lhs.Stroka; i++)
        {
            for (int j = 0; j < lhs.Stolbec; j++)
            {
                rez[i, j] = lhs[i, j] * lambda;
            }
        }
        return rez;
    }
    public static MyMatrix operator *(int lambda, MyMatrix rhs)
    {
        return rhs * lambda;
    }
    public static MyMatrix operator /(MyMatrix lhs, int lambda)
    {
        if (lambda == 0)
        {
            throw new DivideByZeroException("Деление на ноль");
        }

        MyMatrix rez = new MyMatrix(lhs.Stroka, lhs.Stolbec, 0, 0);
        for (int i = 0; i < lhs.Stroka; i++)
        {
            for (int j = 0; j < lhs.Stolbec; j++)
            {
                rez[i, j] = lhs[i, j] / lambda;
            }
        }
        return rez;
    }

    public override string ToString()
    {
        string rez = "";
        for (int i = 0; i < Stroka; i++)
        {
            for (int j = 0; j < Stolbec; j++)
            {
                rez += mx[i, j] + " ";
            }
            rez += "\n";
        }
        return rez;
    }
}
