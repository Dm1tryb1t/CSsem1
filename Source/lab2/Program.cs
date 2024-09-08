
#region First task
Pupil badPupil = new BadPupil();
Pupil goodPupil = new GoodPupil();
Pupil excelentPupil = new ExcelentPupil();

ClassRoom room = new ClassRoom(badPupil, goodPupil, excelentPupil);
room.PrintInfo();
#endregion

#region Second Task
Car car = new Car(0, 0, 1_000_000, 200, 2013);
Plane plane = new Plane(1, 1, 1, 100_000_000, 400, 2020, 500);
Ship ship = new Ship(2, 2, 50_000_000, 100, 2020, 500, "New Moscow port");

Vehicle[] vehicles = new Vehicle[] { car, plane, ship };
foreach (Vehicle vehicle in vehicles)
{
    vehicle.PrintInfo();
}
#endregion

#region Third Task
const string expertKey = "exp";
const string proKey = "pro";
DocumentWorker documentWorker;
Console.WriteLine();
Console.WriteLine("Enter your key here and press ENTER. If you haven't one than just press ENTER");
string userKey = Console.ReadLine();
if (userKey == expertKey)
{
    documentWorker = new ExpertDocumentWorker();
}
else if (userKey == proKey)
{
    documentWorker = new ProDocumentWorker();
}
else
{
    documentWorker = new DocumentWorker();
}
documentWorker.OpenDocument();
documentWorker.EditDocument();
documentWorker.SaveDocument();
#endregion

#region First task class
public class ClassRoom
{
    //public params Pupil[] pupil;
    private Pupil[] pupils;

    public ClassRoom(params Pupil[] newPupils)
    {
        pupils = newPupils;
    }

    public void PrintInfo()
    {
        int i = 0;
        foreach (var pupil in pupils)
        {
            //if (pupil == null) continue;
            Console.WriteLine($"Pupil {i + 1}:");
            pupil.Study();
            pupil.Read();
            pupil.Write();
            pupil.Relax();
            Console.WriteLine();
            ++i;
        }
    }
}

public class BadPupil : Pupil
{
    public override void Study() => Console.WriteLine("Bad Studying");
    public override void Read() => Console.WriteLine("Bad Reading");
    public override void Write() => Console.WriteLine("Bad Writing");
    public override void Relax() => Console.WriteLine("Bad Relaxing");
}
public class GoodPupil : Pupil
{
    public override void Study() => Console.WriteLine("Good Studying");
    public override void Read() => Console.WriteLine("Good Reading");
    public override void Write() => Console.WriteLine("Good Writing");
    public override void Relax() => Console.WriteLine("Good Relaxing");
}
public class ExcelentPupil : Pupil
{
    public override void Study() => Console.WriteLine("Excelent Studying");
    public override void Read() => Console.WriteLine("Excelent Reading");
    public override void Write() => Console.WriteLine("Excelent Writing");
    public override void Relax() => Console.WriteLine("Excelent Relaxing");
} 
public class Pupil
{
    public virtual void Study() => Console.WriteLine("Studying");
    public virtual void Read() => Console.WriteLine("Reading");
    public virtual void Write() => Console.WriteLine("Writing");
    public virtual void Relax() => Console.WriteLine("Relaxing");
}
#endregion

#region Second task class
public class Plane : Vehicle
{
    private double z;
    private int passengersCount;

    public Plane(double x, double y, int z, double price, double speed, int issueYear, int passengersCount) : base(x, y, price, speed, issueYear)
    {
        this.z = z;
        this.passengersCount = passengersCount;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Plane:\tCoordinates: ({x}, {y}, {z}), it  costs {price} rubles, it can move with {speed} km per hour, it was made in {issueYear}, it can place {passengersCount} passengers in it");
    }
}
public class Car : Vehicle
{
    public Car(double x, double y, double price, double speed, int issueYear) : base(x, y, price, speed, issueYear) { }

    public override void PrintInfo()
    {
        Console.WriteLine($"Car:\tCoordinates: ({x}, {y}), it  costs {price} rubles, it can move with {speed} km per hour, it was made in {issueYear}");
    }
}
public class Ship : Vehicle
{
    private int passengersCount;
    private string homePort;

    public Ship(double x, double y, double price, double speed, int issueYear, int passengersCount, string homePort) : base(x, y, price, speed, issueYear)
    {
        this.passengersCount = passengersCount;
        this.homePort = homePort;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Ship:\tCoordinates: ({x}, {y}), it  costs {price} rubles, it can move with {speed} km per hour, it was made in {issueYear}, it can place {passengersCount} passengers in it, it's home port is {homePort}");
    }
}

public class Vehicle
{
    protected double x;
    protected double y;
    protected double price;
    protected double speed;
    protected int issueYear;

    public Vehicle(double x, double y, double price, double speed, int issueYear)
    {
        this.x = x;
        this.y = y;
        this.price = price;
        this.speed = speed;
        this.issueYear = issueYear;
    }

    public virtual void PrintInfo() { }
}
#endregion

#region Third task class:
public class ProDocumentWorker : DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Документ отредактирован");
    }
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
    }
}
public class ExpertDocumentWorker : ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате");
    }
}

public class DocumentWorker
{
    public virtual void OpenDocument()
    {
        Console.WriteLine("Документ открыт");
    }
    public virtual void EditDocument()
    {
        Console.WriteLine("Редактирование документа доступно в версии Pro");
    }
    public virtual void SaveDocument()
    {
        Console.WriteLine("Сохранение документа доступно в версии Pro");
    }
}
#endregion
