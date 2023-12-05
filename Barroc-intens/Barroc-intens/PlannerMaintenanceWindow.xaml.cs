using Barroc_intens.Data;
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
    public sealed partial class PlannerMaintenanceWindow : Window
    {
        static ObservableCollection<FaultyRequest> AllCalendarItems = new ObservableCollection<FaultyRequest>();
        public PlannerMaintenanceWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var apointements = db.FaultyRequests.ToList();
            lvApointements.ItemsSource = apointements;
        }

        private void CalendarView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
           
        }

        //Zorgt dat de listview een double tap heeft
        private void lvApointements_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            CalendarDatePicker Calendar_FaultyrequestPlanner = new CalendarDatePicker();
            Calendar_FaultyrequestPlanner.Visibility = Visibility.Visible;
        }

        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            var calendarItemDate = args.Item.Date;
            var relevantCalendarItems = AllCalendarItems.Where(item => item.ScheduledAt.Date == calendarItemDate.Date);

            // De DataContext is vanuit de xaml te benaderen met {Binding}
            args.Item.DataContext = relevantCalendarItems;

            if (relevantCalendarItems.Count() == 0)
            {
                args.Item.IsBlackout = true;
            }
        }
        
        //Laat alles goed zien in de kalender
        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedCalendarItem = (FaultyRequest)e.ClickedItem;

            var dialog = new ContentDialog()
            {
                Title = clickedCalendarItem.ProductId,
                Content = $"Start: {clickedCalendarItem.ScheduledAt}\nLocation: {clickedCalendarItem.UserId}\nDetails: {clickedCalendarItem.Description}",
                CloseButtonText = "Close",
                XamlRoot = this.Content.XamlRoot,
            };

            await dialog.ShowAsync();
        }

        //Toevoegen aan de kalender
        private void Calendar_FaultyrequestPlanner_Click(object sender, RoutedEventArgs e)
        {
            var newCalendarItem = new FaultyRequest()
            {
                ProductId = "New Calendar Item",
                ScheduledAt = DateTime.Now,
                Location = "New Location",
                Description = "New Details"
            };

            AllCalendarItems.Add(newCalendarItem);

            // Refresh page to update calendar view
            this.Close();
            var plannerWindowRefresh = new PlannerMaintenanceWindow();
            plannerWindowRefresh.Activate();
        }
    }
}
