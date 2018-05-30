using Classes.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;

namespace Classes
{
    public class Generate
    {
        public string path = @"MasterPolice.soap";

        private Random r = new Random();

        private static Country country = new Country();

        public Country GenerContent()
        {
            country.CountryName = "   Kazakhstan";

            for (int i = 0; i < r.Next(1, 5); i++)
            {
                country.city.Add(GenerCity());
            }

            country.FilCities();

            return country;
        }

        public City GenerCity()
        {

            City cities = new City();
            cities.CityName = "City" + (r.Next(1, 1000)).ToString();

            for (int i = 0; i < r.Next(1, 5); i++)
            {
                cities.region.Add(GenerRegions());
            }

            cities.FilRegions();
            return cities;
        }

        public Region GenerRegions()
        {
            Region reg = new Region();
            reg.NameRegion = "Region" + (r.Next(1, 1000)).ToString();

            for (int i = 0; i < r.Next(1, 5); i++)
            {
                reg.service.Add(GenerSerice());
            }

            reg.FilService();
            return reg;
        }

        public Service GenerSerice()
        {
            Service serv = new Service();
            serv.Name = (r.Next(1, 1000)).ToString();
            serv.Code = r.Next(101, 105);
            serv.Address = (r.Next(1000, 5000)).ToString();
            serv.Phone = (r.Next(7000000, 8000000)).ToString();
            serv.CountPeolpe = r.Next(1, 30);
            return serv;
        }

        public void PrintNah(Country countryIn = null)
        {
            Country c = new Country();
            if (countryIn != null)
                c = countryIn;
            else
                c = country;

            Console.WriteLine(c.CountryName + " ->");

            foreach (City item in c.cities)
            {
                Console.WriteLine("\t" + item.CityName + " -->");
                Console.WriteLine("   ================================================");
                foreach (Region item2 in item.regions)
                {
                    Console.WriteLine("\t   " + item2.NameRegion + " --->");
                    Console.WriteLine("   ================================================");
                    foreach (Service item3 in item2.services)
                    {
                        Console.WriteLine("\n\t\tКод орг-ции: {0}\n\t\tНазвание орг-ции {1}\n\t\t" +
                           "Адрес: {2}\n\t\tТелефон: {3}\n\t\tКол-во сотрудников: {4}\n\n", item3.Code, item3.Name, item3.Address, item3.Phone, item3.CountPeolpe);
                        // Console.WriteLine("   ================================================");

                    }
                }
            }
        }

        public static void SoapSerialize()
        {
            SoapFormatter formater = new SoapFormatter();

            using (FileStream fs = new FileStream("MasterPolice.soap", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, country);
                Console.WriteLine("Serial OK!");
            }
        }

        public static Country SoapDeserialize() // object = Person
        {
            Country country = new Country();
            SoapFormatter formater = new SoapFormatter();                                  // 2

            using (FileStream fs = new FileStream("MasterPolice.soap", FileMode.OpenOrCreate))
            {
                country = (Country)formater.Deserialize(fs);
                Console.WriteLine("DeSerial OK!");
            }
            return country;
        }

    }
}
