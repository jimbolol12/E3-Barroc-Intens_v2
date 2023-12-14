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
        public MaintenanceEditWerkbonWindow(MaintenanceAppointment selectedAppointment)
        {
            this.InitializeComponent();
            using (var db = new AppDbContext())
            {


                var storingDetail = db.MaintenanceAppointments
                    .Include(ma => ma.Company)
                    .Where(ma => ma.Id == selectedAppointment.Id)
                    .ToList();
                

            }
        }
    }
}
