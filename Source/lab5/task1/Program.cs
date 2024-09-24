using System.Numerics;



class MyMatrix
{
    public int[,] mx;
    public int Stolbec, Stroka;
    public Random rnd;

    public MyMatrix(int stolbec, int stroka, int minValue, int maxValue)
    {
        Stolbec = stolbec;
        Stroka = stroka;
        mx = new int[Stolbec, Stroka];
        rnd = new Random();

        for (int i = 0; i < Stroka; i++)
        {
            for (int j = 0; j < Stolbec; j++)
            {
                mx[i, j] = rnd.Next(minValue, maxValue + 1);
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
    public void ChangeSize(int stolbec, int stroka)
    {
        int[,] newMX = new int[stolbec, stroka];
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
                newMX[i, j] = rnd.Next();
                ++j;
            }
            ++i;
        }
        while (i < stroka)
        {
            j = 0;
            while (j < stolbec)
            {
                newMX[i, j] = rnd.Next();
                ++j;
            }
            ++i;
        }
        //(mx, newMX) = (newMX, mx);
        mx = newMX;
    }
    public void ShowPartialy(int beginStolbec, int beginStroka, int endStolbec, int endStroka)
    {
        for (int i = beginStroka - 1; i < endStroka; ++i)
        {
            for (int j = beginStolbec - 1; j < endStolbec; ++j)
            {
                System.Console.Write(mx[i, j] + ' ');
            }
            System.Console.WriteLine();
        }
    }
    public void Show()
    {
        ShowPartialy(1, 1, Stolbec, Stroka);
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
