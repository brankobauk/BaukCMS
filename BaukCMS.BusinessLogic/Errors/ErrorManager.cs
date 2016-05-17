using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;

namespace BaukCMS.BusinessLogic.Errors
{
    public class ErrorManager
    {
        private readonly ErrorRepository _errorRepository = new ErrorRepository();
        public void Log(Error ex)
        {
            _errorRepository.Log(ex);
        }
    }
}
