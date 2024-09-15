#region First Task
Console.WriteLine("Первое задание");
Vector v1 = new Vector(1, 1, 1);
Vector v2 = new Vector(2, 2, 2);

Vector sum = v1 + v2;
double scalar = v1 * v2;
Vector v1_1 = v1 * 2;

Console.WriteLine($"Сумма векторов: {sum.x}, {sum.y}, {sum.z}");
Console.WriteLine($"Скалярное произведение: {scalar}");
Console.WriteLine($"Умножение вектора на число: {v1_1.x}, {v1_1.y}, {v1_1.z}");
Console.WriteLine($"v1 > v2: {v1 > v2}");
Console.WriteLine($"v1 < v2: {v1 < v2}");
Console.WriteLine($"v1 == v2: {v1 == v2}");
Console.WriteLine($"v1 !== v2: {v1 != v2}");
#endregion

#region Second Task
Console.WriteLine();
Console.WriteLine("Второе задание");
CarsCatalog catalog = new CarsCatalog();

catalog.AddCar(new Car ("Car_1", "Engine_1", 1));
catalog.AddCar(new Car ("Car_2", "Engine_2", 2));
catalog.AddCar(new Car ("Car_3", "Engine_3", 3));

for (int i = 0; i < catalog.Cars.Count; i++)
{
    Console.WriteLine(catalog.Cars[i].Name);
}
for (int i = 0; i < catalog.Cars.Count; i++)
{
    Console.WriteLine(catalog[0]);
}
#endregion

#region Third Task
Console.WriteLine();
Console.WriteLine("Третье задание");
Console.WriteLine("Введите курс USD -> RUB");
double USDtoRUB = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите курс EUR -> RUB");
double EURtoRUB = Convert.ToDouble(Console.ReadLine());

CurrencyUSD.USDtoRUBExchange = USDtoRUB;
CurrencyEUR.EURtoRUBExchange = EURtoRUB;

CurrencyUSD dollars = new CurrencyUSD(100);
CurrencyEUR euros = new CurrencyEUR(100);
CurrencyRUB rubles = new CurrencyRUB(100);

// преобразование
CurrencyEUR USD_to_EUR = dollars;
CurrencyRUB USD_to_RUB = dollars;
CurrencyUSD EUR_to_USD = euros;
CurrencyEUR RUB_to_EUR = rubles;

Console.WriteLine($"100 USD -> EUR: {USD_to_EUR.Value}");
Console.WriteLine($"100 USD -> RUB: {USD_to_RUB.Value}");
Console.WriteLine($"100 EUR -> USD: {EUR_to_USD.Value}");
Console.WriteLine($"100 RUB -> EUR: {RUB_to_EUR.Value}");
#endregion

//First Task Struct
public struct Vector
{
    public double x, y, z;

    public Vector (double x, double y, double z)
    {
        this.x = x; this.y = y; this.z = z;
    }

    public readonly double Length
    {
        get { return Math.Sqrt(x * x + y * y + z * z); }
    }

    public static Vector operator +(Vector lhs, Vector rhs)
    {
        return new Vector(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
    }
    public static double operator *(Vector lhs, Vector rhs)
    {
        return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
    }
    public static Vector operator *(double lambda, Vector vec)
    {
        return new Vector(lambda*vec.x, lambda * vec.y, lambda * vec.z);
    }
    public static Vector operator *(Vector vec, double lambda)
    {
        return lambda * vec;
    }

    public static bool operator <(Vector lhs, Vector rhs)
    {
        return lhs.Length < rhs.Length;
    }
    public static bool operator >(Vector lhs, Vector rhs)
    {
        return lhs.Length > rhs.Length;
    }
    public static bool operator <=(Vector lhs, Vector rhs)
    {
        return lhs.Length <= rhs.Length;
    }
    public static bool operator >=(Vector lhs, Vector rhs)
    {
        return lhs.Length >= rhs.Length;
    }
    public static bool operator ==(Vector lhs, Vector rhs)
    {
        return lhs.Length == rhs.Length;
    }
    public static bool operator !=(Vector lhs, Vector rhs)
    {
        return lhs.Length != rhs.Length;
    }
}

#region Second Task Class
public class Car : IEquatable<Car>
{
    public string Name { get; private set; }
    public string Engine {  get; private set; }
    public double MaxSpeed { get; private set; }

    public Car(string name, string engine, double maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if(ReferenceEquals(null, other)) return false;
        return other.Name == Name;
    }
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj) || obj.GetType() != GetType()) return false;
        return Equals((Car)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Engine, MaxSpeed);
    }
}

public class CarsCatalog
{
    public List<Car> Cars = new List<Car>();

    public string this[int index]
    {
        get
        {
            Car car = Cars[index];
            return $"{car.Name} - {car.Engine}";
        }
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
    }
}
#endregion

#region Third Task class
class Currency
{
    public double Value { get; set; }
}
// ................................................................USD
class CurrencyUSD : Currency
{
    public static double USDtoRUBExchange { get; set; }
    public CurrencyUSD(double value) { Value = value; }
    public CurrencyUSD() { }

    //USD -> EUR
    public static implicit operator CurrencyEUR(CurrencyUSD currencyUSD)
    {
        return new CurrencyEUR
        {
            Value = currencyUSD.Value * USDtoRUBExchange / CurrencyEUR.EURtoRUBExchange
        };
    }

    // USD -> RUB
    public static implicit operator CurrencyRUB(CurrencyUSD currencyUSD)
    {
        return new CurrencyRUB
        {
            Value = currencyUSD.Value * USDtoRUBExchange
        };
    }
}
// ................................................................EUR
class CurrencyEUR : Currency
{
    public static double EURtoRUBExchange { get; set; }
    public CurrencyEUR(double value) { Value = value; }
    public CurrencyEUR() { }

    // EUR -> USD
    public static implicit operator CurrencyUSD(CurrencyEUR currencyEUR)
    {
        return new CurrencyUSD
        {
            Value = currencyEUR.Value * EURtoRUBExchange / CurrencyUSD.USDtoRUBExchange
        };
    }

    // EUR => RUB
    public static implicit operator CurrencyRUB(CurrencyEUR currencyEUR)
    {
        return new CurrencyRUB
        {
            Value = currencyEUR.Value * EURtoRUBExchange
        };
    }
}
// ................................................................RUB
class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) { Value = value; }
    public CurrencyRUB() { }

    // RUB -> EUR
    public static implicit operator CurrencyEUR(CurrencyRUB currencyRUB)
    {
        return new CurrencyEUR
        {
            Value = currencyRUB.Value / CurrencyEUR.EURtoRUBExchange
        };
    }

    // RUB -> USD
    public static implicit operator CurrencyUSD(CurrencyRUB currencyRUB)
    {
        return new CurrencyUSD
        {
            Value = currencyRUB.Value / CurrencyUSD.USDtoRUBExchange
        };
    }
}
#endregion
