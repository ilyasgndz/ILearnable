using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NetXmlSerializer
{
    class Program
    {
        static string xml = "";
        static void Main(string[] args)
        {
            var dog1 = new Dog { Type = "Bulldog", Name = "Doggy", Age = 2, NumberOfLegs = 4 };
            Save<Dog>(dog1);
            Save(dog1);

            Read<Dog>();           
            Console.ReadKey();
        }

        static void Save<T>(T animal) where T : Animal
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                new XmlTextWriter(ms, Encoding.Unicode);
                serializer.Serialize(ms, animal);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
                Console.WriteLine(xml.ToString());
            }
        }

        static void Save(Animal animal)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using (var ms = new MemoryStream())
            {
                new XmlTextWriter(ms, Encoding.Unicode);
                serializer.Serialize(ms, animal);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
                Console.WriteLine(xml.ToString());
            }
        }

        static void Read<T>() where T : Animal
        {
            var serializer = new XmlSerializer(typeof(T));
            T animal;

            using (TextReader reader = new StringReader(xml))
            {
                animal = (T)serializer.Deserialize(reader);
            }

            Console.WriteLine(animal.Name);
        }    
    }
}

[XmlInclude(typeof(Dog))]
[Serializable]
public abstract class Animal
{
    public int Age { get; set; }
    public string Name { get; set; }
    public int NumberOfLegs { get; set; }
    public string Type { get; set; }
}


[Serializable]
public class Bird : Animal
{

}

[Serializable]
public class Dog : Animal
{

}

