using System;
using System.Collections.Generic;
using System.Text;
using Sqo.Attributes;

namespace SiagodbTest.DbModels
{
    public class SimpleModel
    {
        //[MaxLength(300)]
        //public string StringField { get; set; }
        public List<SimpleItem> Items { get; set; }
    }
}
