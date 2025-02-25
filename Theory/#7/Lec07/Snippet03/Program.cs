﻿class Program
{
    static void Main()
    {
        HandleAll();
        Console.ReadLine();
    }

#line 100
    public static void HandleAll()
    {
        Action[] methods =
        {
                HandleAndThrowAgain,//throw ex вызывает потерю стека вызовов
                HandleAndThrowWithInnerException,
                HandleAndRethrow,//нет потери стека вызовов
                HandleWithFilter
        };

        foreach (var m in methods)
        {
            try
            {
                m();  // line 114
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"\tInner Exception {ex.InnerException.Message}");
                    Console.WriteLine(ex.InnerException.StackTrace);
                }
                Console.WriteLine();
            }
        }
    }

#line 1000
    public static void HandleWithFilter()
    {
        try
        {
            ThrowAnException("test 4");  // line 1004
        }
        catch (Exception ex) when (Filter(ex))
        {
            Console.WriteLine("block never invoked");
        }
    }

#line 1500
    public static bool Filter(Exception ex)
    {
        Console.WriteLine($"just log {ex.Message}");
        return false;
    }

#line 2000
    public static void HandleAndRethrow()
    {
        try
        {
            ThrowAnException("test 3");//2004
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Log exception {ex.Message} and rethrow");
            throw;  // line 2009
        }
    }

#line 3000
    public static void HandleAndThrowWithInnerException()
    {
        try
        {
            ThrowAnException("test 2");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Log exception {ex.Message} and throw again");
            throw new AnotherCustomException("throw with inner exception", ex);  // line 3009
        }
    }

#line 4000
    public static void HandleAndThrowAgain()
    {
        try
        {
            ThrowAnException("test 1");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Log exception {ex.Message} and throw again");
            throw ex;  // you shouldn't do that - line 4009
        }
    }

#line 8000
    public static void ThrowAnException(string message)
    {
        throw new MyCustomException(message);  // line 8002
    }
}


public class MyCustomException : Exception
{
    public MyCustomException(string message)
        : base(message) { }

    public int ErrorCode { get; set; }
}

public class AnotherCustomException : Exception
{
    public AnotherCustomException(string message, Exception innerException)
        : base(message, innerException) { }
}