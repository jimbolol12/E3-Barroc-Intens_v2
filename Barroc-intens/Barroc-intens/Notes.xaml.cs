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
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Notes : Window
    {
        public Notes()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ar = LoginWindow.LoggedInUser;

            using var db = new AppDbContext();
            db.Notes.Add(new Note
            {
                Title = titel.Text,
                AuthorId = LoginWindow.LoggedInUser.Id,
                /*Author = ar.*/
                Description = beschrijving.Text,
                Date = DateTime.Now
               
            }
                );
            db.SaveChanges();

            var saleswindow = new SalesWindow();
            saleswindow.Activate();
            this.Close();

        }
    }
}
