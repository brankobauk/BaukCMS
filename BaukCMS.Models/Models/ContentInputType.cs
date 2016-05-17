using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class ContentInputType
    {
        [Key]
        public int ContentInputTypeId { get; set; }
        public string ContentInputTypeName { get; set; }
    }
}
