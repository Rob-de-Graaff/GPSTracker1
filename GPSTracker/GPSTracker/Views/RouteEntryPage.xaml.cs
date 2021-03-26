using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSTracker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GPSTracker.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class RouteEntryPage : ContentPage
    {
        public RouteEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Route();
        }

        public string ItemId
        {
            set
            {
                LoadRoute(value);
            }
        }

        private async void LoadRoute(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Route route = await App.Database.GetRouteAsync(id);
                BindingContext = route;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load route.");
            }
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var route = (Route)BindingContext;
            route.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(route.Description))
            {
                await App.Database.SaveRouteAsync(route);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var route = (Route)BindingContext;
            await App.Database.DeleteRouteAsync(route);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}