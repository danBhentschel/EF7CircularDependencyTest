﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Parent
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
        public Child FavoriteChild { get; set; }
    }
}
