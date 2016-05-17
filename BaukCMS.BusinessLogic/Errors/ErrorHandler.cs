using System;
using BaukCMS.Models.Models;

namespace BaukCMS.BusinessLogic.Errors
{
    public class ErrorHandler
    {
        private readonly ErrorManager _errorManager = new ErrorManager();
        public void Log(Error ex)
        {
            _errorManager.Log(ex);
        }
    }
}
