using Barroc_intens.Data;
using Barroc_intens.Model;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class MaintenanceEditWerkbonWindow : Window
    {
        private MaintenanceAppointment clickedAppointment;
        public MaintenanceEditWerkbonWindow(MaintenanceAppointment selectedAppointment)
        {
            this.InitializeComponent();

            this.clickedAppointment = selectedAppointment;

            using (var db = new AppDbContext())
            {
                var companies = db.Companies.ToList();

                TbRemark.Text = selectedAppointment.Description;
                AppointmentCompanyCombobox.ItemsSource = companies;
                DatePickerDateAdded.Date = selectedAppointment.ScheduledAt.Date;
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (clickedAppointment != null && TbRemark.Text != "" && AppointmentCompanyCombobox.SelectedItem as Company != null)
            {
                var appointment = clickedAppointment;

                using var dbContext = new AppDbContext();

                var clickAppointment = dbContext.MaintenanceAppointments.Find(clickedAppointment.Id);
                var comboboxSelectedCompany = AppointmentCompanyCombobox.SelectedItem as Company;

                clickAppointment.Description = TbRemark.Text;
                clickAppointment.CompanyId = comboboxSelectedCompany.Id;
                clickAppointment.ScheduledAt = DatePickerDateAdded.Date.Date;

                dbContext.SaveChanges();
                var werkbonnenWindow = new MaintenanceWerkbonnen();
                werkbonnenWindow.Activate();
                this.Close();
            }
            else
            {
                MessageBox.Text = "Ongeldige gegevens ingevuld!";
            }


        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}