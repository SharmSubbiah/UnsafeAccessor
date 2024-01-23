
namespace UnsafeAccessor
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    public class BenchMark
    {
        [Benchmark]
        public void UnsafeMethodReflection()
        {
            var unsafeExample = new UnsafeExample();

            var result = typeof(UnsafeExample).GetMethod("UnsafeMethodReflection", BindingFlags.Instance | BindingFlags.NonPublic)?
                .Invoke(unsafeExample, Array.Empty<object>());

        }

        [Benchmark]
        public void UnsafeMethodAccessor()
        {
            var unsafeAccessorExample = new UnsafeExample();

            var result = UnsafeAccessorClass.GetUnsafeName(unsafeAccessorExample);
        }

        [Benchmark]
        public void SafeMethodAccessor()
        {
            var unsafeAccessorExample = new SafeExample();

            var result = unsafeAccessorExample.Name;
        }
    }

    public class UnsafeAccessorClass
    {
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "UnsafeMethod")]
        public static extern string GetUnsafeName(UnsafeExample unsafeExample);
    }

    public class UnsafeExample
    {
        private string Name = "Unsafe Name";
        private string UnsafeMethod()
        {
            return "Unsafe Name";
        }
    }

    public class SafeExample
    {
        public string Name = "Unsafe Name";
        public string UnsafeMethod()
        {
            return "Unsafe Name";
        }
    }
}
