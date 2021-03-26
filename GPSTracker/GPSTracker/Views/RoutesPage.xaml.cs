using GPSTracker.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace GPSTracker.Views
{
    public partial class RoutesPage : ContentPage
    {
        public RoutesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetRoutesAsync();
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage.
            await Shell.Current.GoToAsync(nameof(RouteEntryPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Route route = (Route)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(RouteEntryPage)}?{nameof(RouteEntryPage.ItemId)}={route.ID.ToString()}");
            }
        }
    }
}