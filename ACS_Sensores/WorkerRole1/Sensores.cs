using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerRole1
{
    public class Wind
    {
        public decimal speed { get; set; }
        public decimal deg { get; set; }
    }
    public class Coord
    {
        public decimal lon { get; set; }
        public decimal lat { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }

    public class Weather
    {
        public string id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {

        public int temp { get; set; }
        public int pressure { get; set; }
        public int humidty { get; set; }
    }

    public class Sensores
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
    }
}
