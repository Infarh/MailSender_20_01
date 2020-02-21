using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
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

            var description_attribute = printer_type.GetCustomAttributes<DescriptionAttribute>().ToArray();

            foreach (var method in printer_type.GetMethods())
            {
                Console.WriteLine("{0} {1}({2})",
                    method.ReturnType.Name,
                    method.Name,
                    string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}")));

                foreach (var parameter in method.GetParameters())
                {
                    var parameter_description = parameter.GetCustomAttributes(typeof(DescriptionAttribute))
                       .OfType<DescriptionAttribute>().ToArray();
                    if (parameter_description.Length == 0) continue;
                    Console.WriteLine("\t{0}", parameter.Name);
                    foreach (var attribute in parameter_description)
                        Console.WriteLine("\t\t{0}", attribute.Description);

                }

            }

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

            description_attribute = internal_printer_type.GetCustomAttributes<DescriptionAttribute>().ToArray();

            description_attribute.ToList().ForEach(a => Console.WriteLine(a.Description));


            var printer2 = Activator.CreateInstance(printer_type, ">>>!!!");

            var print_method = (Action<string>)internal_print_method_info.CreateDelegate(typeof(Action<string>), internal_printer);

            print_method("123qwe");

            var print_method2 = (Action<string>) Delegate.CreateDelegate(typeof(Action<string>), internal_printer, internal_print_method_info);
            print_method2("ASDQWE");

            dynamic dynamic_obj = printer2;

            dynamic_obj.Print("12345677890");

            var str = (string)Add("123", "QWE");

            var Z = (int)Add(5, 7);

            var Q = (Complex)Add(new Complex(5, 7), new Complex(10, -2));

            var values = new object[]
            {
                null,
                "Hello World!",
                3.141592653589793238,
                42,
                true,
            };

            Process(values);

            Console.WriteLine("!!!");
            Console.ReadLine();
        }

        private static dynamic Add(dynamic X, dynamic Y) { return X + Y; }


        public static void Process(object[] values)
        {
            //foreach (var value in values)
            //    switch (value)
            //    {
            //        case string v : ProcessValue(v); break;
            //        case double v : ProcessValue(v); break;
            //        case int v : ProcessValue(v); break;
            //        case bool v : ProcessValue(v); break;
            //    }

            foreach (var value in values)
            {
                dynamic v = value;
                ProcessValue(v);
            }

        }

        public static void ProcessValue(object value) => Console.WriteLine("obj:{0}", value ?? "<null>");
        public static void ProcessValue(string value) => Console.WriteLine("str:{0}", value);
        public static void ProcessValue(double value) => Console.WriteLine("double:{0}", value);
        public static void ProcessValue(int value) => Console.WriteLine("int:{0}", value);
        public static void ProcessValue(bool value) => Console.WriteLine("bool:{0}", value);

    }
}
