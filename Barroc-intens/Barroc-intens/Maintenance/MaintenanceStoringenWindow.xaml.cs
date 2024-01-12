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
using Microsoft.EntityFrameworkCore;
using Barroc_intens.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaintenanceStoringenWindow : Window
    {
        public MaintenanceStoringenWindow()
        {
            this.InitializeComponent();
            using (var db = new AppDbContext())
            {
                var storing = db.FaultyRequests
                    .Include(s => s.Product)
                    .ToList();
                storingenListView.ItemsSource = storing;
            }
        }

        private void storingenListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement element && element.DataContext is FaultyRequest ClickedStoring)
            {
                var storingDetailsWindow = new StoringDetailsWindow(ClickedStoring);
                storingDetailsWindow.Activate();
                this.Close();
            } 
        }
    }
}
