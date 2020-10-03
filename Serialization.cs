using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using ConsoleApp;

namespace ConsoleApp

{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class Serialization
    {
        static void Main(string[] args)
        {
            binaryExamp();
            Console.ReadKey();
        }

        private static void binaryExamp()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializing();
            else
                serializing();

        }

        private static void deserializing()
        {
            try
            {
                FileStream fs = new FileStream("test.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter fm = new BinaryFormatter();
                Student s = fm.Deserialize(fs) as Student;
                Console.WriteLine(s.Name);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializing()
        {

            Student s = new Student { Address = "Mysore", Name = "Pratheeksha", Phone = 271133 };
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("test.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, s);
            fs.Close();
        }
    }
}

        