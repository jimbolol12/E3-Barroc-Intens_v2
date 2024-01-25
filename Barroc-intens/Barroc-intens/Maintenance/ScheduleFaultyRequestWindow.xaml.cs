using Barroc_intens.Data;
using Barroc_intens.Model;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens.Maintenance
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScheduleFaultyRequestWindow : Window
    {
        private FaultyRequest clickedRequest;
        public ScheduleFaultyRequestWindow(FaultyRequest selectedRequest)
        {
            this.InitializeComponent();
            this.clickedRequest = selectedRequest;
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateRequestAndSaveChanges();
                CloseCurrentWindow();
            }
            catch (FormatException)
            {
                HandleInvalidData("Incorrecte gegevens ingevuld");
            }
            catch (Exception ex)
            {
                HandleGeneralException($"Er is een fout opgetreden: {ex.Message}");
            }
        }

        private void UpdateRequestAndSaveChanges()
        {
            var request = clickedRequest;

            using (var dbContext = new AppDbContext())
            {
                var existingRequest = dbContext.FaultyRequests.Find(clickedRequest.Id);

                if (existingRequest != null)
                {
                    UpdateRequestDetails(existingRequest);
                    dbContext.SaveChanges();
                }
            }
        }

        private void UpdateRequestDetails(FaultyRequest excistingRequest)
        {
            // Convert DateTimeOffset? naar DateTime
            DateTime scheduledAt = cdpScheduledDate.Date.HasValue
                ? cdpScheduledDate.Date.Value.DateTime
                : DateTime.MinValue;

            excistingRequest.ScheduledAt = scheduledAt;
        }

        private void CloseCurrentWindow()
        {
            var plannerWindow = new PlannerMaintenanceWindow();
            plannerWindow.Activate();
            this.Close();
        }

        private void HandleInvalidData(string errorMessage)
        {
            //MessageBox.Text = errorMessage;
        }

        private void HandleGeneralException(string errorMessage)
        {
            //MessageBox.Text = errorMessage;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            var plannerWindow = new PlannerMaintenanceWindow();
            plannerWindow.Activate();
            this.Close();
        }
    }
}
