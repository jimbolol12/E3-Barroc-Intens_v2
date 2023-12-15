using Barroc_intens.Data;
using Barroc_intens.Maintenance;
using Barroc_intens.Model;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaintenanceWindow : Window
    { 
        static ObservableCollection<FaultyRequest> AllCalendarItems = new ObservableCollection<FaultyRequest>();
        public MaintenanceWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var appointments = db.FaultyRequests
                    .Where(appointment => appointment.EmployeeId == LoginWindow.LoggedInUser.Id)
                    .ToList();
            lvApointements.ItemsSource = appointments;
        }

        private void CalendarView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }

        //Toevoegen aan de kalender
        private void lvApointements_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var clickedRequest = (FaultyRequest)lvApointements.SelectedItem;
            using var db = new AppDbContext();
            var newCalendarItem = new FaultyRequest()
            {
                ProductId = clickedRequest.ProductId,
                ScheduledAt = clickedRequest.ScheduledAt,
                Location = clickedRequest.Location,
                Description = clickedRequest.Description,
            };

            AllCalendarItems.Add(newCalendarItem);

            // Refresh page to update calendar view
            var maintenanceWindow = new MaintenanceWindow();
            maintenanceWindow.Activate();
            this.Close();
        }

        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            var calendarItemDate = args.Item.Date;
            var relevantCalendarItems = AllCalendarItems.Where(item => item.ScheduledAt.Date == calendarItemDate.Date);

            // De DataContext is vanuit de xaml te benaderen met {Binding}
            args.Item.DataContext = relevantCalendarItems;
        }

        //Laat alles goed zien in de kalender
        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedCalendarItem = (FaultyRequest)e.ClickedItem;

            var dialog = new ContentDialog()
            {
                Title = "!",
                Content = $"Start: {clickedCalendarItem.ScheduledAt}\nLocation: {clickedCalendarItem.Location}\nDetails: {clickedCalendarItem.Description}",
                CloseButtonText = "Close",
                XamlRoot = this.Content.XamlRoot,
            };

            await dialog.ShowAsync();
        }
    }
}
