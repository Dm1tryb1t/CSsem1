MyList<int> List_One = new MyList<int>(32131, 2232, 3122, 321314, 3213215);
Console.WriteLine("Список List_One: ");
List_One.PrintList();


List_One.Add(5764);
Console.WriteLine("Список List_One, с добавленным элементом: ");
List_One.PrintList();

MyList<string> List_Two = new MyList<string>("bmw", "lamborgini", "mersedes", "toyota");
Console.WriteLine("Список List_Two: ");
List_Two.PrintList();


List_Two.Add("renault");
Console.WriteLine("Список List_Two, с добавленным элементом: ");
List_Two.PrintList();


class MyList<T>
{
    private T[] arr;

    public MyList(params T[] values)
    {
        arr = values;
    }
    public MyList(int sz)
    {
        arr = new T[sz];
    }

    public void Add(T element)
    {
        Array.Resize(ref arr, arr.Length + 1);
        arr[arr.Length - 1] = element;
    }
    public T this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }
    public int Size()
    {
        return arr.Length;
    }

    public void PrintList()
    {

        Console.WriteLine(Size());
        foreach (T element in arr)
        {
            // CancellationToken ct = new CancellationToken();
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}

