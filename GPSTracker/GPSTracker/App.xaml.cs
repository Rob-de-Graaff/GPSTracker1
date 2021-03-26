using System;
using System.IO;
using GPSTracker.Data;
using Xamarin.Forms;

namespace GPSTracker
{
    public partial class App : Application
    {
        private static RouteDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        // Create the database connection as a singleton.
        public static RouteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RouteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GPSTracker.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}