﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Udemy.App.Entities
{
    public class ProvidedServices : BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } 
    }
}
