﻿using System.Reflection;
using System.Text;
using WhatsNewAttributes;

StringBuilder outputText = new(1000);
DateTime backDateTo = new(2019, 2, 1);

Assembly theAssembly = Assembly.Load(new AssemblyName("Snippet05"));
Attribute? supportsAttribute = theAssembly.GetCustomAttribute(typeof(SupportsWhatsNewAttribute));

AddToOutput($"Assembly: {theAssembly.FullName}");

if (supportsAttribute is null)
{
    Console.WriteLine("This assembly does not support WhatsNew attributes");
    return;
}
else
{
    AddToOutput("Defined Types:");
}

foreach (Type definedType in theAssembly.ExportedTypes)
{
    DisplayTypeInfo(definedType);
}

Console.WriteLine($"What's New since {backDateTo:D}");
Console.WriteLine(outputText.ToString());

Console.ReadLine();

void AddToOutput(string text) =>
    outputText.Append($"{Environment.NewLine}{text}");

void DisplayTypeInfo(Type type)
{
    if (!type.GetTypeInfo().IsClass)
    {
        return;
    }

    AddToOutput($"{Environment.NewLine}class {type.Name}");

    IEnumerable<LastModifiedAttribute> lastModifiedAttributes = type.GetTypeInfo().GetCustomAttributes().OfType<LastModifiedAttribute>().Where(a => a.DateModified >= backDateTo).ToArray();
    if (lastModifiedAttributes.Count() == 0)
    {
        AddToOutput($"\tNo changes to the class {type.Name}{Environment.NewLine}");
    }
    else
    {
        foreach (LastModifiedAttribute attribute in lastModifiedAttributes)
        {
            WriteAttributeInfo(attribute);
        }
    }

    AddToOutput("changes to methods of this class:");

    foreach (MethodInfo method in type.GetTypeInfo().DeclaredMembers.OfType<MethodInfo>())
    {
        IEnumerable<LastModifiedAttribute> attributesToMethods = method.GetCustomAttributes()
            .OfType<LastModifiedAttribute>().Where(a => a.DateModified >= backDateTo).ToArray();

        if (attributesToMethods.Count() > 0)
        {
            AddToOutput($"{method.ReturnType} {method.Name}()");

            foreach (Attribute attribute in attributesToMethods)
            {
                WriteAttributeInfo(attribute);
            }
        }
    }
}

void WriteAttributeInfo(Attribute attribute)
{
    if (attribute is LastModifiedAttribute lastModifiedAttribute)
    {
        AddToOutput($"\tmodified: {lastModifiedAttribute.DateModified:D}: {lastModifiedAttribute.Changes}");

        if (lastModifiedAttribute.Issues != null)
        {
            AddToOutput($"\tOutstanding issues: {lastModifiedAttribute.Issues}");
        }
    }
}