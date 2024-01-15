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
using Microsoft.EntityFrameworkCore;

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
            LoadCompanyDb();
        }

        private void BCreateUser_Click(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            var selectedCompany = CompanyCombobox.SelectedItem as Company;
            var company = db.Companies.Single(c => c.Id == selectedCompany.Id);
            bool checkSucceeded = InputCheck();
            if (checkSucceeded == true)
            {
                db.Users.Add(new User
                {
                    Email = TbEmail.Text,
                    Username = TbUsername.Text,
                    JobFunctionId = 1,
                    Password = PbPassword.Password,
                    CompanyId = company.Id,
                });
                db.SaveChanges();
                TbError.Text = "Klant kan nu inloggen!";
            }

        }
        private bool InputCheck()
        {
            using var db = new AppDbContext();
            bool checkSucceeded = false;
            var users = db.Users
                .Where(u => u.Username == TbUsername.Text && u.Email == TbEmail.Text)
                .ToList();

            if (users.Count > 0)
            {
                TbError.Text = "Deze gebruikersnaam is al in gebruik!";
            }
            else if (!TbEmail.Text.Contains("@"))
            {
                TbError.Text = "Voer een geldige Email in!";
            }
            else if (PbPassword.Password == "")
            {
                TbError.Text = "Vul een wachtwoord in!";
            }
            else
            {
                checkSucceeded = true;
            }

            return checkSucceeded;
        }
        private void BRedirectBack_Click(object sender, RoutedEventArgs e)
        {
            var salesWindow = new SalesWindow();
            salesWindow.Activate();
            this.Close();
        }
        private void LoadCompanyDb()
        {
            using (var db = new AppDbContext())
            {
                var company = db.Companies
                    .ToList();
                CompanyCombobox.ItemsSource = company;
            }
        }
    }
}
