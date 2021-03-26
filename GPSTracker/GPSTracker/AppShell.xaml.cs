using Xamarin.Forms;
using GPSTracker.Views;

namespace GPSTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RouteEntryPage), typeof(RouteEntryPage));
        }
    }
}