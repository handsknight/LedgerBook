using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LedgerBook.DAL;

using Xamarin.Forms;

namespace LedgerBook
{
	public partial class App : Application
	{
        //create a static database connection
        static DatabaseManager dbConn;

        public App ()
		{
			InitializeComponent();
           
           
            MainPage = new LedgerBook.MainPage();
		}

        public static DatabaseManager dbManager
        {
            get
            {
                if (dbConn == null)
                {
                    dbConn = new DatabaseManager();
                    
                }
                return dbConn;
            }
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
