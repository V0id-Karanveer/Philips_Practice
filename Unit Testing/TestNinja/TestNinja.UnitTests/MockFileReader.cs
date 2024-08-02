using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    class MockFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
