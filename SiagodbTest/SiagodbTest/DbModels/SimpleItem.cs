using System;
using System.Collections.Generic;
using System.Text;

namespace SiagodbTest.DbModels
{
    public class SimpleItem
    {
        string property1 = "0";
        public string Property1 {
            get { return property1; }
            set { property1 = value; }
        }
        public string Property2 { get; set; }
    }
}
