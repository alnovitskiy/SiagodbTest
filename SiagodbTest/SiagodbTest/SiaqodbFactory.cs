using System;
using System.Collections.Generic;
using System.Text;
using SiagodbTest.DependencyInterfaces;
using Sqo;
using Xamarin.Forms;

namespace SiagodbTest
{
    public class SiaqodbFactory
    {
        private static ISiaqodb instance;
        public static ISiaqodb GetInstance()
        {
            return instance ?? (instance = DependencyService.Get<ISiaqoDatabase>().GetInstant());
        }
    }
}
