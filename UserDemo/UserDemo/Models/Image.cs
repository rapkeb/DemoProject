﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDemo.Models
{
    public class Image
    {
            public int Id { get; set; }
            public string ImageTitle { get; set; }
            public byte[] ImageData { get; set; }
    }
}
