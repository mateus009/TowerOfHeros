using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    class JsonConverter
    {
        public static void WriteJson <T>(string path, T Object) where T : new()
        {
            string teste = JsonConvert.SerializeObject(Object);
            using(StreamWriter file = new StreamWriter(path))
            {
                file.Write(teste);
            }
        }
    }
}
