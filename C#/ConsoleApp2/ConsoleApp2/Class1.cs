using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Class1
    {
        private string model;
        private readonly int _id;
        private const int corner = 4;
        public static int nextID = 0;
        public Class1(string model1 , bool isfast1) {
            _id = nextID++;
            Isfast = isfast1;
            Model = model1;
            Console.WriteLine(Model);
        }

        public string Model {
            get
            {
                if (Isfast)
                {
                    return model + " very fast";
                }
                return model;
            }
            
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Empty");
                    model = "NULL";
                }
                else
                {
                    model = value;
                }
            } }

        public bool Isfast { get; set; }

        public string compprop { get
            {
                return Model + "is good";
            } }

        public int Id => _id;
    }
}
