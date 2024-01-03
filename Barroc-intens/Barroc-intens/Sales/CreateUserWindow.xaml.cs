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
using Barroc_intens.Model;
using Barroc_intens.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens.Sales
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            this.InitializeComponent();
        }

        private void BCreateUser_Click(object sender, RoutedEventArgs e)
        {
            string username = TbUsername.Text;
            string email = TbEmail.Text;
            using var db = new AppDbContext();
            var users = db.Users.Where(u => u.Username == username).ToList();

            if (users.Count > 0)
            {
                TbError.Text = "Deze gebruikersnaam is al in gebruik!";
            }
            else
            {
                db.Users.Add(new User
                {
                    Email = email,
                    Username = username,
                    JobFunctionId = 1
                });
                db.SaveChanges();
                TbError.Text = "Klant kan nu registreren en een wachtwoord aanmaken!";
            }

        }

        private void BRedirectBack_Click(object sender, RoutedEventArgs e)
        {
            var salesWindow = new SalesWindow();
            salesWindow.Activate();
            this.Close();
        }
    }
}
