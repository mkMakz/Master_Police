using Classes.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Modules
{
    [Serializable]
    public class City
    {
        public string CityName { get; set; }

        [NonSerialized]
        public List<Region> region = new List<Region>();

        public Region[] regions;
        public void FilRegions()
        {
            regions = region.ToArray();
        }
    }   
}