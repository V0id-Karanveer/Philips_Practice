using System;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO
            Person p = new Person("John", 30);
            p.greet();

        }
    }

    public class Person
    {
        // TODO
        private string _name;
        private int _age;

        public string Name
        {
            get{
                return _name;
            }
            set{
                _name = value;
            }
        }

        public int Age
        {
            get{
                return _age;
            }
            set{
                if (value > 0)
                {
                    _age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void greet()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }
}
