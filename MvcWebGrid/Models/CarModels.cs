using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcWebGrid.Models
{

    #region Models
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Cars
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
    } 
    #endregion

    #region Services
     [Serializable]
    public class CarModels
    {
       
        /// <summary>
        /// Gets a list of sample cars 
        /// </summary>
        /// <returns></returns>
        public List<Cars> getAllCars()
        {
            List<Cars> sample = new List<Cars>();

            //Hardcoded for the article 
            Cars c1 = new Cars();
            c1.Name = "Corlla";
            c1.Manufacturer = "Toyota";
            c1.Type = "Sedan";
            sample.Add(c1);

            Cars c2 = new Cars();
            c2.Name = "Falcon";
            c2.Manufacturer = "Ford";
            c2.Type = "Sedan";
            sample.Add(c2);

            return sample;
        }
    } 
    #endregion
}