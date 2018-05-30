using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Modules
{
    [Serializable]
    public class Country
    {
        public string CountryName { get; set; }

        [NonSerialized]
        public List<City> city = new List<City>();

        public City[] cities;
        public void FilCities()
        {
            cities = city.ToArray();
        }
    }


}
