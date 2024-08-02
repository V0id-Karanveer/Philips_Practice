using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Contact(int ID, string name, string email)
        {
            this.ID = ID;
            this.Name = name;
            this.Email = email;
        }

        public override string ToString() {
            return $"{ID} - {Name} - {Email}";
        }
    }
}
