using System;
using Newtonsoft.Json;

namespace JAMK.IT
{
    public class Train
    {
        public string TrainNumber { get; set; }
        [JsonProperty("canceled")]
        public bool IsCancelled { get; set; }
        [JsonProperty("departureDate")]
        public DateTime DepDate { get; set; }
        public string TargetStation { get; set; }

    }
    public class Station
    {
    public string Name { get; set; }
    public string Code { get; set; }
    public Station (string koodi, string ap)
        {
            this.Code = koodi; //asemapaikka JY = JKL
            this.Name = ap; // asemapaikan nimi
        }
    }
}
