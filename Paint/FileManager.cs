using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Paint
{
    public abstract class FileManager
    {
        public static List<ChartData> LoadFromFile(string path)
        {
            List<ChartData> items = new List<ChartData>();
            if (File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<ChartData>>(json);
                }
            }
            return items;
        }

        public static void SaveToFile(string path, List<ChartData> datas)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, datas);
            }
        }
    }
}