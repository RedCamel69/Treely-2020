using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treely_2020.Models.API
{
    public record UKCity
    {


    public string City { get; }
    public float Lat { get; }

    public float Lng { get; }

    public string Country { get; }

    public string ISO2 { get; }

    public string Admin_Name { get; }

    public string Capital { get; }

    public int Population { get; }

    public int Population_Proper { get; }

    // public Person(string first, string last) => (FirstName, LastName) = (first, last);

}
       
   
}
