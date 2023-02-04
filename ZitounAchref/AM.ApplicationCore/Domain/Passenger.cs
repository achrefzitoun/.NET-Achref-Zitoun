using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime birthDate { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string emailAdress { get; set; }
        public string telNumber { get; set; }
        public string passportNumber { get; set; }
        public List<Flight> flights { get; set; }

        public override string ToString()
        {
            return birthDate + " " + firstName + " " + lastName + " " +  emailAdress + " " + telNumber + " " + passportNumber + " " + flights;
        }

        /*
        public bool CheckProfile(string fName, string lName)
        {
            return fName == firstName && lName == lastName;
        }

        public bool CheckProfile(string fName, string lName, string email)
        {
            return fName == firstName && lName == lastName && email == emailAdress;
        }

        */

        public bool CheckProfile(string fName, string lName, string email)
        {
            if (fName == firstName && lName == lastName)
                return true;
            else if(fName == firstName && lName == lastName && email == emailAdress)
                return true;

            return false;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger");
        }

    }
}
