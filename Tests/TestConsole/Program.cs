using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var domain = AppDomain.CreateDomain("TestDomain");
            //domain.ExecuteAssembly(Assembly.GetEntryAssembly().Location);

            //Assembly
            //AssemblyName
            //Module

            //Type

            //MemberInfo
            ////FieldInfo
            ////PropertyInfo
            ////ConstructorInfo
            ////EventInfo
            ////MethodInfo
            //////ParameterInfo

            var lib_file = new FileInfo("TestLib.dll");

            var lib = Assembly.LoadFile(lib_file.FullName);

            var printer_type = lib.GetType("TestLib.Printer");

            //foreach (var method in printer_type.GetMethods())
            //{
            //    Console.WriteLine("{0} {1}({2})",
            //        method.ReturnType.Name,
            //        method.Name,
            //        string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}")));
            //}

            var printer_ctor = printer_type.GetConstructor(new[] { typeof(string) });

            var printer = printer_ctor.Invoke(new object[] { ">>>>>" });

            var print_method_info = printer_type.GetMethod("Print", BindingFlags.Instance | BindingFlags.Public);

            print_method_info.Invoke(printer, new object[] { "Hello World!" });

            var printer_prefix = printer_type.GetField("_Prefix", BindingFlags.Instance | BindingFlags.NonPublic);

            var prefix_value = (string) printer_prefix.GetValue(printer);
            prefix_value += "|||||";

            printer_prefix.SetValue(printer, prefix_value);

            var internal_printer_type = lib.GetType("TestLib.InternalPrinter");

            var internal_printer_ctor = internal_printer_type.GetConstructor(Array.Empty<Type>());

            var internal_printer = internal_printer_ctor.Invoke(Array.Empty<object>());

            var internal_print_method_info = internal_printer_type.GetMethod("Print", BindingFlags.Instance | BindingFlags.Public);

            internal_print_method_info.Invoke(internal_printer, new object[] { "Hello World!" });

            

            Console.WriteLine("!!!");
            Console.ReadLine();
        }
    }
}
