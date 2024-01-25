using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Barroc_intens.Data;
using Barroc_intens.Model;
using Aspose.Pdf.LogicalStructure;
using System.Configuration;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StoringsWindow : Window
    {
        public StoringsWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var products = db.Products.ToList();
            ProductCombobox.ItemsSource = products;
        }

        private void BSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = new AppDbContext();
                //Random functie voor het koppelen van medewerker aan storing
                Random r = new Random();
                var employeeList = new List<User>();
                employeeList = db.Users.Where(u => u.JobFunctionId == 5).ToList();
                int index = r.Next(employeeList.Count);
                User randomEmployee = employeeList[index];
                var product = (Product)ProductCombobox.SelectedItem;
                //Toevoegen aan de database
                db.FaultyRequests.Add(new FaultyRequest
                {
                    ProductId = product.Id,
                    UserId = LoginWindow.LoggedInUser.Id,
                    Employee = randomEmployee,
                    ScheduledAt = DateTime.Now,
                    Location = tbFaultyRequestlocation.Text,
                    Description = tbFaultyRequestdescription.Text,
                    Done = false,
                }
                    );

                db.SaveChanges();
                var klantenWindow = new KlantenWindow(LoginWindow.LoggedInUser);
                klantenWindow.Activate();
                this.Close();
            }
            catch (FormatException)
            {
                // Hier kun je de foutmelding weergeven voor ongeldige gegevens
                /* MessageBox.Show("Ongeldige gegevens. Controleer of de ingevoerde waarden correct zijn.");*/
                MessageBox.Text = "Incorecte gegevens ingevuld";
            }
            //catch (Exception ex)
            //{
            //     Hier kun je een algemene foutmelding weergeven voor andere uitzonderingen
            //    /* MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");*/
            //    MessageBox.Text = "Incorecte gegevens ingevuld";
            //}
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            //var klantWindow = new KlantenWindow();
            //klantWindow.Activate();
            //this.Close();
        }
    }
}
