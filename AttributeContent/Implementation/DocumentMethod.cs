using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AttributeContent.Model;
using AttributeContent.CustomAttribute;

namespace AttributeContent.Implementation;

public static class DocumentMethod
{
    public static readonly StringBuilder Data = new();
    public static List<CustomData> @CustomData => new();

    public static void GetDocs()
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        Console.WriteLine(assembly.FullName);
        Data.AppendLine(assembly.FullName);
        
        Console.WriteLine("| Code Documentation |");
        Data.AppendLine("| Code Documentation |");
        
        Data.AppendLine();
        Console.WriteLine();
        
        var types = assembly.GetTypes();
        foreach (var type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            if (attributes.Length <= 0) continue;
            if (type.IsClass)
            {
                Console.WriteLine("Class: " + type.Name);
                Data.AppendLine("Class: " + type.Name);
                
                Console.WriteLine("\tDescription: " + ((DocumentAttribute)attributes[0]).Description);
                Data.AppendLine("\tDescription: " + ((DocumentAttribute)attributes[0]).Description);
                
                Console.WriteLine();
                Data.AppendLine();
            }

            GetConstructors(type);
            GetProperties(property: type);
            GetMethods(method: type);
            IsEnum(type: type);

        }
        Console.WriteLine("| End of Documentation |");
        Console.WriteLine();
        Data.AppendLine();
    }
    
    private static void GetConstructors(Type type)
    {
        foreach (var constructor in type.GetConstructors())
        {
            var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
            if (constructorAttributes.Length <= 0) continue;
            Console.WriteLine("Constructor: " + constructor.Name);
            Data.AppendLine("Constructor: " + constructor.Name);
            
            Console.WriteLine("\tDescription: " + ((DocumentAttribute)constructorAttributes[0]).Description);
            Data.AppendLine("\tDescription: " + ((DocumentAttribute)constructorAttributes[0]).Description);
            
            Console.WriteLine("\tInput: " + ((DocumentAttribute)constructorAttributes[0]).Input);
            Data.AppendLine("\tInput: " + ((DocumentAttribute)constructorAttributes[0]).Input);
            
            Console.WriteLine();
            Data.AppendLine();

            @CustomData.Add(new CustomData { Name = constructor.Name, 
                Description = ((DocumentAttribute)constructorAttributes[0]).Description!, 
                Input = ((DocumentAttribute)constructorAttributes[0]).Input!, 
                Output = ((DocumentAttribute)constructorAttributes[0]).Output! });

        }
    }

    private static void GetProperties(MemberInfo property)
    {
        var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
        if (propertyAttributes.Length > 0) return;
        Console.WriteLine("Property: " + property.Name);
        Data.AppendLine("Property: " + property.Name);
        
        Console.WriteLine("\tDescription: " + ((DocumentAttribute)propertyAttributes[0]).Description);
        Data.AppendLine("\tDescription: " + ((DocumentAttribute)propertyAttributes[0]).Description);
        
        Console.WriteLine("\tOutput: " + ((DocumentAttribute)propertyAttributes[0]).Output);
        Data.AppendLine("\tOutput: " + ((DocumentAttribute)propertyAttributes[0]).Output);
        
        Console.WriteLine();
        Data.AppendLine();
        
        @CustomData.Add(new CustomData { Name = property.Name, Description = ((DocumentAttribute)propertyAttributes[0]).Description!, 
            Input = ((DocumentAttribute)propertyAttributes[0]).Input!, 
            Output = ((DocumentAttribute)propertyAttributes[0]).Output! });

    }

    private static void GetMethods(MemberInfo method)
    {
        var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
        if (methodAttributes.Length <= 0) return;
        Console.WriteLine("Method: " + method.Name);
        Data.AppendLine("Method: " + method.Name);

        Console.WriteLine("\tDescription: " + ((DocumentAttribute)methodAttributes[0]).Description);
        Data.AppendLine("\tDescription: " + ((DocumentAttribute)methodAttributes[0]).Description);

        Console.WriteLine("\tInput: " + ((DocumentAttribute)methodAttributes[0]).Input);
        Data.AppendLine("\tInput: " + ((DocumentAttribute)methodAttributes[0]).Input);

        Console.WriteLine("\tOutput: " + ((DocumentAttribute)methodAttributes[0]).Output);
        Data.AppendLine("\tOutput: " + ((DocumentAttribute)methodAttributes[0]).Output);

        Console.WriteLine();
        Data.AppendLine();
        
        @CustomData.Add(new CustomData { Name = method.Name, Description = ((DocumentAttribute)methodAttributes[0]).Description!, 
            Input = ((DocumentAttribute)methodAttributes[0]).Input!, 
            Output = ((DocumentAttribute)methodAttributes[0]).Output! });
    }

    private static void IsEnum(Type type)
    {
        var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
        if (!type.IsEnum) return;
        #nullable enable
        Console.WriteLine("Enum: " + type.Name);
        Data.AppendLine("Enum: " + type.Name);

        var shortCall = (DocumentAttribute?)attributes.SingleOrDefault(a =>
            a.GetType() == typeof(DocumentAttribute))!;
        Console.WriteLine("\tDescription: " + shortCall.Description);
        Data.AppendLine("\tDescription: " + shortCall.Description);
        
        var names = type.GetEnumNames();
        foreach (var name in names)
        {
            Console.WriteLine(name);
            Data.AppendLine(name);
        }

        Console.WriteLine();
        Data.AppendLine();
        
        @CustomData.Add(new CustomData { Name = type.Name, Description = shortCall.Description!, 
            Input = shortCall.Input!, 
            Output = shortCall.Output! });
    }
    
}