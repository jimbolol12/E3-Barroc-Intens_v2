using ABI.Windows.UI;
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
        private FaultyRequest _clickedRequest;

        static ObservableCollection<FaultyRequest> AllCalendarItems = new ObservableCollection<FaultyRequest>();
        public PlannerMaintenanceWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var apointements = db.FaultyRequests.ToList();
            lvApointements.ItemsSource = apointements;
            var apointements2 = db.MaintenanceAppointments.ToList();
            lvApointements2.ItemsSource = apointements2;
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
            var plannerWindowRefresh = new PlannerMaintenanceWindow();
            plannerWindowRefresh.Activate();
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

        private void bCreateRoutineVisit_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateRoutineVisitWindow();
            createWindow.Activate();
            this.Close();
        }

        private void lvApointements_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.DataContext is FaultyRequest clickedRequest)
            {
                var scheduleTime = new ScheduleFaultyRequestWindow(clickedRequest);
                scheduleTime.Activate();
                this.Close();
            }
        }

        private void lvApointements2_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var clickedApointement = (MaintenanceAppointment)lvApointements2.SelectedItem;
            using var db = new AppDbContext();
            var newCalendarItem = new FaultyRequest()
            {
                ProductId = clickedApointement.ProductId,
                ScheduledAt = clickedApointement.ScheduledAt,
                Location = clickedApointement.Location,
                Description = clickedApointement.Description,
            };

            AllCalendarItems.Add(newCalendarItem);

            // Refresh page to update calendar view
            var plannerWindowRefresh = new PlannerMaintenanceWindow();
            plannerWindowRefresh.Activate();
            this.Close();
        }

        private void lvApointements2_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.DataContext is FaultyRequest clickedRequest)
            {
                var scheduleTime = new ScheduleFaultyRequestWindow(clickedRequest);
                scheduleTime.Activate();
                this.Close();
            }
        }
    }
}
