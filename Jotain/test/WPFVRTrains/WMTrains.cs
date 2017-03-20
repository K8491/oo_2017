using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JAMK.IT
{
    public class TrainsVM
    {
        public static List<Train> GetTrainsAt(string station)
        {
            try
            {

                List<Train> trains = new List<Train>();
                if (station == "testi" || station == "")
                {

                    // Vaihe 1: Placebo palauttaa oikea muotoisen datan
                    //keksitaan muutama juna
                    Train tr = new Train();
                    tr.TrainNumber = "666";
                    tr.DepDate = new DateTime(2017, 3, 21);
                    tr.TargetStation = "Highway To Hell";
                    trains.Add(tr);
                }
                else
                {
                    string tmp = API.GetJsonFromLiikenneVirasto(station);
                    trains = JsonConvert.DeserializeObject<List<Train>>(tmp);

                }
                return trains;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        }
    }

