using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JsonLibrary
{
    public static class JsonHelper
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public static T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }

    public class ExampleClass
    {
        public int IntProperty { get; set; }
        public string StringProperty { get; set; }
        public List<double> ListProperty { get; set; }
        public Dictionary<string, bool> DictionaryProperty { get; set; }
        public NestedClass NestedClassProperty { get; set; }
        public NestedStruct NestedStructProperty { get; set; }
    }

    public class NestedClass
    {
        public string NestedProperty { get; set; }
    }

    public struct NestedStruct
    {
        public int NestedProperty { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExampleClass obj = new ExampleClass
            {
                IntProperty = 42,
                StringProperty = "ПОЙДЕМТЕ В ДОТКУ",
                ListProperty = new List<double> { 228, 1337, 404 },
                DictionaryProperty = new Dictionary<string, bool> { { "Ключик1", true }, { "Ключик2", false } },
                NestedClassProperty = new NestedClass { NestedProperty = "Вложенное значение" },
                NestedStructProperty = new NestedStruct { NestedProperty = 10 }
            };

            string jsonString = JsonHelper.Serialize(obj);
            Console.WriteLine(jsonString);

            ExampleClass deserializedObj = JsonHelper.Deserialize<ExampleClass>(jsonString);

            Console.WriteLine(deserializedObj.IntProperty);
            Console.WriteLine(deserializedObj.StringProperty);
            Console.WriteLine(string.Join(", ", deserializedObj.ListProperty));
            foreach (var kvp in deserializedObj.DictionaryProperty)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine(deserializedObj.NestedClassProperty.NestedProperty);
            Console.WriteLine(deserializedObj.NestedStructProperty.NestedProperty);
        }
    }
}
