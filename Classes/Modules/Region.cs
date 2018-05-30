using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Modules
{
    [Serializable]
    public class Region
    {

        public string NameRegion { get; set; }

        [NonSerialized]
        public List<Service> service = new List<Service>();

        public Service[] services;
        public void FilService()
        {
            services = service.ToArray();
        }
    }
}