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
using System.Text;
using System.Security.Cryptography;
using Barroc_intens.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class klantaanmakenWindow : Window
    {
        public klantaanmakenWindow()
        {
            this.InitializeComponent();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using var db = new AppDbContext();
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string email = txtEmail.Text;

            string hashedPassword = HashPassword(password);

            User newUser = new User
            {
                Username = username,
                Password = hashedPassword,
                Email = email,
                JobFunction = new JobFunction() { Id = 11 }
            };

            db.Users.Add(newUser);
            db.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
