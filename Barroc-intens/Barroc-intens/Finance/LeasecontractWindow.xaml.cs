using Barroc_intens.Data;
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

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeasecontractWindow : Window
    {
        public ImageSource Source { get; set; }
        public LeasecontractWindow()
        {
            this.InitializeComponent();
        }

        private void BNieuwLeaseContract_Click(object sender, RoutedEventArgs e)
        {
            var newLeaseWindow = new CreateNewLeaseWindow();
            newLeaseWindow.Activate();
            this.Close();
        }
    }
}
