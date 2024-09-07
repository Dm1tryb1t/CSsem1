
Person firstPerson = new ("Ivan", "Trofimov", 20);
Person secondPerson = new("Piter", "Grigoriev", 19, "Moscow");
Person thirdPerson = new("Dmitry", "Egorov");

firstPerson.PrintPerson();
secondPerson.PrintPerson();
thirdPerson.PrintPerson();

firstPerson.Adress = "newAdress";
secondPerson.LastName = "Bojich";
thirdPerson.Age = 20;

Console.WriteLine();
firstPerson.PrintPerson();
secondPerson.PrintPerson();
thirdPerson.PrintPerson();

//firstPerson.FirstName = ""; No way to do this
Console.WriteLine();
Console.WriteLine(firstPerson.FirstName);

class Person
{
    #region Поля
    private string _firstName;
    private string _lastName;
    private int _age;
    #endregion

    #region Свойства
    public string FirstName => _firstName;
    public string LastName { get => _lastName; set => _lastName = value; }
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }
    public string Adress { get; set; }
    #endregion

    #region Конструктор
    public Person(string firstName, string lastName, int age, string adress)
    {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
        Adress = adress;
    }
    public Person(string firstName, string lastName, int age)
    {
        (_firstName, _lastName, _age, Adress) = (firstName, lastName, age, "");
    }
    public Person(string firstName, string lastName) : this(firstName, lastName, 0)
    {

    }
    #endregion

    #region Метод
    public void PrintPerson()
    {
        Console.WriteLine($"Person with LastName:{LastName} FirstName:{FirstName} Age:{Age} Adress:{Adress}");
    }
    #endregion
}
