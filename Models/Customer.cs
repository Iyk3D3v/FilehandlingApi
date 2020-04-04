﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileHandlingApi.Models
{
    public class Customer
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
