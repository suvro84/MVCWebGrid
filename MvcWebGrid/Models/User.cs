

using System.Collections.Generic;
using System.Xml.Serialization;
using System;
namespace MvcWebGrid.Models
{
    /// <summary>
    /// Company class contains information that shoudl be shown in table
    /// </summary>
    [Serializable]
    [XmlRoot("RolePrev")]
    public class User
    {


        public User()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        [XmlArray(ElementName = "Previleges")]
        public List<string> Previleges { get; set; }
        [XmlElement(ElementName = "Role")]
        public string Role { get; set; }
    }

}