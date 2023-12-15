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
        public static User LoggedInUser { get; private set; }
        public LoginWindow()
        {
            this.InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = UsernameTextBox.Text;
            string enteredPassword = PasswordBox.Password;

            var user = AuthenticateUser(enteredUsername, enteredPassword);
            LoggedInUser = user;

            if (user != null)
            {
                OpenWindowBasedOnRole(user);
            }
            else
            {
                DisplayInvalidCredentialsError();
            }
        }

        private User AuthenticateUser(string enteredUsername, string enteredPassword)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == enteredUsername && u.Password == enteredPassword);
            }
        }

        private void OpenWindowBasedOnRole(User user)
        {
            Window window = null;

            switch (user.JobFunctionId)
            {
                case 1:
                    window = new KlantenWindow();
                    break;

                case 2:
                    window = new FinanceWindow();
                    break;

                case 3:
                    window = new SalesWindow();
                    break;

                case 4:
                    window = new InkoopWindow();
                    break;

                case 5:
                    window = new MaintenanceWindow();
                    break;

                case 6:
                    window = new HoofdmedewerkerMaintenanceWindow();
                    break;

                case 7:
                    window = new PlannerMaintenanceWindow();
                    break;
            }

            if (window != null)
            {
                window.Activate();
                this.Close();
            }
        }

        private void DisplayInvalidCredentialsError()
        {
            ErrorTextBlock.Text = "Ongeldige inloggegevens";
        }
    }
}

