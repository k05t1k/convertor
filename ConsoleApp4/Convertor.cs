using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp4
{
    internal class Convertor
    {
        public static void TextToXml(Menu menu) 
        {
            List<Surface> surfaces = new List<Surface>();

            string[] lines_on_file = File.ReadAllLines(menu.m_strConvertPath);

            Surface surface1 = new Surface(lines_on_file[0], int.Parse(lines_on_file[1]), int.Parse(lines_on_file[2]));
            Surface surface2 = new Surface(lines_on_file[3], int.Parse(lines_on_file[4]), int.Parse(lines_on_file[5]));
            Surface surface3 = new Surface(lines_on_file[6], int.Parse(lines_on_file[7]), int.Parse(lines_on_file[8]));

            surfaces.Add(surface1);
            surfaces.Add(surface2);
            surfaces.Add(surface3);

            File.WriteAllText(menu.m_strSavePath, File.ReadAllText(menu.m_strConvertPath));

            XmlSerializer xml = new XmlSerializer(typeof(List<Surface>));
            using (FileStream fs = new FileStream(menu.m_strSavePath, FileMode.OpenOrCreate))
                xml.Serialize(fs, surfaces);
        }
        public static void TextToJson(Menu menu)
        {
            List<Surface> surfaces = new List<Surface>();

            string[] lines_on_file = File.ReadAllLines(menu.m_strConvertPath);

            Surface surface1 = new Surface(lines_on_file[0], int.Parse(lines_on_file[1]), int.Parse(lines_on_file[2]));
            Surface surface2 = new Surface(lines_on_file[3], int.Parse(lines_on_file[4]), int.Parse(lines_on_file[5]));
            Surface surface3 = new Surface(lines_on_file[6], int.Parse(lines_on_file[7]), int.Parse(lines_on_file[8]));

            surfaces.Add(surface1);
            surfaces.Add(surface2);
            surfaces.Add(surface3);

            string json = JsonConvert.SerializeObject(surfaces);
            File.WriteAllText(menu.m_strSavePath, json);
        }
        public static void JsonToText(Menu menu)
        {
            string text = File.ReadAllText(menu.m_strConvertPath);
            List<Surface> surfaces = JsonConvert.DeserializeObject<List<Surface>>(text);

            string result = "";
            
            for (int i = 0; i < surfaces.Count; i++) 
                result += $"{surfaces[i].Name}\n{surfaces[i].Width}\n{surfaces[i].Height}\n";
            
            File.WriteAllText(menu.m_strSavePath, result);
        }
        public static void XmlToText(Menu menu)
        {
            List<Surface> surfaces = new List<Surface>();

            string result = "";

            XmlSerializer xml = new XmlSerializer(typeof(List<Surface>));
            using (FileStream fs = new FileStream(menu.m_strConvertPath, FileMode.Open))
                surfaces = (List<Surface>)xml.Deserialize(fs);

            for (int i = 0; i < surfaces.Count; i++)
                result += $"{surfaces[i].Name}\n{surfaces[i].Width}\n{surfaces[i].Height}\n";

            File.WriteAllText(menu.m_strSavePath, result);
        }
        public void Init(Menu menu)
        {
            if (!menu.m_bCheck)
            {
                switch (menu.m_iPos)
                {
                    case 2:
                        TextToJson(menu);
                        break;
                    case 3:
                        TextToXml(menu);
                        break;
                }
            }
            else
            {
                switch(menu.m_iPos)
                {
                    case 1:
                        JsonToText(menu);
                        break;
                    case 2:
                        XmlToText(menu);
                        break;
                }
            }
        }
    }
}
