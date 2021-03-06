﻿using System.Collections.Generic;

using MyExpenses.Helpers;
using MyExpenses.Services;
using MyExpenses.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyExpenses.DataStores;
using MyExpenses.Models;
using MyExpenses.DataStores;
using System;
using Expenses.WPF.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyExpenses
{
	public partial class App : Application
	{
        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
        public static string DefaultEmployeeAlias = "nanil";
        public static string EmployeeId = null;

        // public static string AzureMobileAppUrl = "https://myexpenses-si.azurewebsites.net";
        public static string AzureMobileAppUrl = "https://myexpensesappus.azurewebsites.net";

        public static IDictionary<string, string> LoginParameters => null;

 
        public App()
		{
			InitializeComponent();
            RegisterLegacyWpfServices();

            SetMainPage();
		}

        private void RegisterLegacyWpfServices()
        {
            DependencyService.Register<CurrentIdentityService>();
            DependencyService.Register<NavigationService>();
            DependencyService.Register<RepositoryService>();
            DependencyService.Register<ViewService>();
            DependencyService.Register<ServiceFactoryImpl>();
        }

        public static void SetMainPage()
		{
            if (!Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
		}

        public static void GoToMainPage()
        {
            Current.MainPage = new MainPage();
        }
	}
}
