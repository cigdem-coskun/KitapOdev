﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Records.Bases
{
 public abstract class RecordBase//Entity class
    {
        public int Id { get; set; }
        public string Guid { get; set; }

    }
}
