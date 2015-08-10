using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SiagodbTest.DependencyInterfaces;
using SiagodbTest.iOS.WrapperClasses;
using Sqo;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SiaqoDatabase))]
namespace SiagodbTest.iOS.WrapperClasses
{
    public class SiaqoDatabase : ISiaqoDatabase
    {
        public ISiaqodb GetInstant()
        {
            var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return new Siaqodb(dbPath);
        }
    }

}