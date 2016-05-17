using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;

namespace BaukCMS.DataLayer.Repositories
{
    public class ErrorRepository
    {
        private readonly BaukCMSContext _db = new BaukCMSContext();
        public void Log(Error error)
        {
            _db.Error.Add(error);
            _db.SaveChanges();
        }
    }
}
