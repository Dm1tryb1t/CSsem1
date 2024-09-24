
using System.Collections;

class MyDictionary<Tkey, Tvalue> : IEnumerable
{
    private Tkey[] keys;
    private Tvalue[] values;

    public MyDictionary(params (Tkey, Tvalue)[] elems)
    {
        keys = new Tkey[elems.Length];
        values = new Tvalue[elems.Length];
        for (int i = 0; i < elems.Length; i++)
        {
            keys[i] = elems[i].Item1;
            values[i] = elems[i].Item2;
        }
    }
    public void Add(Tkey key, Tvalue value)
    {
        if (keys.Contains(key))
        {
            return;
        }
        keys.Append(key);
        values.Append(value);
    }
    public Tvalue this[Tkey key]
    {
        get
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (key.Equals(keys[i]))
                {
                    return values[i];
                }
            }
            return default;
        }
        set
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (key.Equals(keys[i]))
                {
                    values[i] = value;
                    return;
                }
            }
            Add(key, value);
        }
    }
    public int Size => keys.Length;

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
    }
}
