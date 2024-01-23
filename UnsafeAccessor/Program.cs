// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Running;
using UnsafeAccessor;

BenchmarkRunner.Run<BenchMark>();

var unsafeExample = new UnsafeAccessorExample();

var unsafeAccessorMethod = UnsafeAccessorClass.GetUnsafeStaticField(unsafeExample);

UnsafeAccessorClass.GetUnsafeStaticField(unsafeExample) = Guid.NewGuid();
Console.WriteLine(unsafeAccessorMethod);

public class UnsafeAccessorClass
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "UnsafeMethod")]
    public static extern string GetUnsafeMethod(UnsafeAccessorExample unsafeExample);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "Id")]
    public static extern ref Guid GetUnsafeField(UnsafeAccessorExample unsafeExample);

    [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "StaticId")]
    public static extern ref Guid GetUnsafeStaticField(UnsafeAccessorExample unsafeExample);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Number")]
    public static extern int GetUnsafeProperty(UnsafeAccessorExample unsafeExample);

}

public class UnsafeAccessorExample
{
    

    private static readonly Guid StaticId = Guid.Empty;

    private Guid Id = Guid.Empty;
    private string UnsafeMethod()
    {
        return "Unsafe Name";
    }
}