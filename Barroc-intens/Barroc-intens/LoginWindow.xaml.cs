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
using Barroc_intens.Model;
using Barroc_intens.Data;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string enteredUsername = UsernameTextBox.Text;
            string enteredPassword = PasswordBox.Password;

            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(u => u.Username == enteredUsername && u.Password == enteredPassword);

            if (user != null)
            {
                if (user.JobFunction == "Klant")
                {
                    var klantWindow = new KlantenWindow();
                    klantWindow.Activate();
                }

                if (user.JobFunction == "Finance")
                {
                    var financeWindow = new FinanceWindow();
                    financeWindow.Activate();
                }

                if (user.JobFunction == "Inkoop")
                {
                    var inkoopWindow = new InkoopWindow();
                    inkoopWindow.Activate();
                }

                if (user.JobFunction == "Sales")
                {
                    var salesWindow = new SalesWindow();
                    salesWindow.Activate();
                }

                if (user.JobFunction == "HoofdmedewerkerMaintenance")
                {
                    var hoofdmedewerkerWindow = new HoofdmedewerkerMaintenanceWindow();
                    hoofdmedewerkerWindow.Activate();
                }

                if (user.JobFunction == "Planner")
                {
                    var plannerWindow = new PlannerMaintenanceWindow();
                    plannerWindow.Activate();
                }

                if (user.JobFunction == "Maintenance")
                {
                    var maintenanceWindow = new MaintenanceWindow();
                    maintenanceWindow.Activate();
                }

            }
            else
            {
                ErrorTextBlock.Text = "Ongeldige inloggegevens";
            }
        }
    }
    
}

