using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Reader {

        public enum TypeReader
        {
            Children,
            Adult
        }
        private string firstName;
        private string lastName;
        private TypeReader typeReader;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public TypeReader Type { get => typeReader; set => typeReader = value; }
        public Reader(string first_name, string last_name , Reader.TypeReader typ)
        {
            this.firstName = first_name;
            this.lastName = last_name;
            this.typeReader = typ;
        }

    }
}
