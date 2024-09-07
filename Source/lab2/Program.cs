

public class ClassRoom
{
    //public params Pupil[] pupil;
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
