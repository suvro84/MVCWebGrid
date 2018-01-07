using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebGrid.Models;

namespace MvcWebGrid.Models
{
    public class ModelServices : IDisposable
    {
        //private readonly Entities entities = new Entities();
        private readonly employeeEntities entities = new employeeEntities();
        
        public IEnumerable<Person> GetPeople()
        {
            return entities.People.ToList();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}