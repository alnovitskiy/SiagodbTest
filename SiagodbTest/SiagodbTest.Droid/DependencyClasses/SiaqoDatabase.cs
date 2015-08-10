using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SiagodbTest.DependencyInterfaces;
using SiagodbTest.Droid.DependencyClasses;
using Sqo;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(SiaqoDatabase))]
namespace SiagodbTest.Droid.DependencyClasses
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