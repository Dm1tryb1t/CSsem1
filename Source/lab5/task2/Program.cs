
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
        arr.Append(element);
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
}

