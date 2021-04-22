using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace BSSceneToHotKey
{
    static class ModCommon
    {
        public static bool XmlSave<T>(this T t ,string directry)
        {
            try
            {
                if (!System.IO.Directory.Exists(directry))
                    System.IO.Directory.CreateDirectory(directry);

                Type type = t.GetType();
                string fileName = directry + "\\" + type.Name + ".xml";

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                serializer.Serialize(fs, t);
                fs.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T XmlLoad<T>(this T t, string directry) 
        {
            try
            {
                if (!System.IO.Directory.Exists(directry))
                    return default(T);

                Type type = t.GetType();
                string fileName = directry + "\\" + type.Name + ".xml";

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                t = (T)System.Convert.ChangeType(serializer.Deserialize(fs), type);
                fs.Close();

                return t;

            }
            catch
            {
                return default(T);
            }
        }
    }
}
