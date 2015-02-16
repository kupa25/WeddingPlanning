using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WeddingPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEvent : Page
    {
        public AddEvent()
        {
            this.InitializeComponent();

            //Get the location in the background
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            //Retrieve the location of the event
            while (App.Longitude == null || App.Latitude == null)
	        {
                 //just wait
	        }

            //Store the information in Azure mobile service
            var WeddingEvent = new Wedding
            {
                Title = txtTitle.Text,
                CoordinatorName = txtCoordinator.Text,
                CoordinatorPhone = txtCoordinatorPhone.Text,
                EmailAddress = txtEmail.Text,
                Lattitude = App.Latitude.Value,
                Longitude = App.Longitude.Value,
                JoinCode = new Guid().ToString().Substring(0, 5)
            };

            App.ShaadiTimeClient.GetTable<Wedding>().InsertAsync(WeddingEvent);

            //Display and email the join code for guests
            //Navigate to the wedding page
        }
    }
}
