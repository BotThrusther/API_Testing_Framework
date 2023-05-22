using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodeIOService.DataHandling
{

    public class DigimonArray
    {
        public Digimon[] Digimon { get; set; }
    }

    public class Digimon
    {
        public string name { get; set; }
        public string img { get; set; }
        public string level { get; set; }
    }

}
