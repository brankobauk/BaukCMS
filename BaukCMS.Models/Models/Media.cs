﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.Models.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }
        public int SiteId { get; set; }
        public int MediaCategoryId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public virtual Site Site { get; set; }
        public virtual MediaCategory MediaCategory { get; set; }
    }
}