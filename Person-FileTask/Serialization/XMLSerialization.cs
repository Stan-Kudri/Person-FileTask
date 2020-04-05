using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Person_FileTask
{
    

    class XMLSerialization:ISerialization
    {
        XmlSerializer xMLSerializer = new XmlSerializer(typeof(Person[]));

        public void Serialize(Stream stream, Person[] person)
        {
            
            try
            {                
                xMLSerializer.Serialize(stream, person);
            }
            catch
            {

            }
        }

        public Person[] Desserialize(Stream stream)
        {
            
            try
            {                
                return (Person[])xMLSerializer.Deserialize(stream);
            }
            catch
            {
                return null;
            }
        }

    }
}
