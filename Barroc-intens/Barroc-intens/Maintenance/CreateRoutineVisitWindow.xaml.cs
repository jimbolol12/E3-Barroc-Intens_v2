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
    public sealed partial class CreateRoutineVisitWindow : Window
    {
        public CreateRoutineVisitWindow()
        {
            this.InitializeComponent();

            using var db = new AppDbContext();

            var userList = db.Users.Where(user => user.JobFunctionId == 5 || user.JobFunctionId == 6).ToList();
            cbEmployee.ItemsSource = userList;
        }

        private void bCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFaultyRequestToDatabase();
                CloseCurrentWindow();
            }
            catch (FormatException ex)
            {
                HandleInvalidData("Incorrecte gegevens ingevuld");
            }
            catch (Exception ex)
            {
                HandleGeneralException($"Er is een fout opgetreden: {ex.Message}");
            }
        }

        private void SaveFaultyRequestToDatabase()
        {
            using (var db = new AppDbContext())
            {
                var newMaintenanceApointement = CreateMaintenanceApointementFromInputs();
                db.MaintenanceAppointments.Add(newMaintenanceApointement);
                db.SaveChanges();
            }
        }

        private MaintenanceAppointment CreateMaintenanceApointementFromInputs()
        {
            // Haal de geselecteerde gebruiker uit de combobox
            User selectedUser = (User)cbEmployee.SelectedItem;

            // controleer of de user geselecteerd is
            if (selectedUser != null)
            {
                // Convert DateTimeOffset? naar DateTime
                DateTime scheduledAt = cdpVisitDate.Date.HasValue
                    ? cdpVisitDate.Date.Value.DateTime
                    : DateTime.MinValue;

                return new MaintenanceAppointment
                {
                    Location = tbUserlocation.Text,
                    ScheduledAt = scheduledAt,
                    EmployeeId = selectedUser.Id,
                    Description = tbDescription.Text,
                };
            }
            else
            {
                return null;
            }
        }

        private void CloseCurrentWindow()
        {
            var plannerWindow = new PlannerMaintenanceWindow();
            plannerWindow.Activate();
            this.Close();
        }

        private void HandleInvalidData(string errorMessage)
        {
            MessageBox.Text = errorMessage;
        }

        private void HandleGeneralException(string errorMessage)
        {
            MessageBox.Text = errorMessage;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            var plannerWindow = new PlannerMaintenanceWindow();
            plannerWindow.Activate();
            this.Close();
        }
    }
}
