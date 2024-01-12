using Barroc_intens.Model;
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
    public sealed partial class SalesWindow : Window
    {
        public SalesWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var products = db.Products.ToList();
            var companies= db.Companies.ToList();
            var notes = db.Notes.ToList();
            lvProducts.ItemsSource = products;
            lvbedrijf.ItemsSource = companies;
            lvnote.ItemsSource = notes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Offertewindow = new offerteWindow();
            Offertewindow.Activate();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var notewindow = new Notes();
            notewindow.Activate();
            this.Close();
        }

        private void lvnote_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if(lvnote.SelectedItems.Count > 0)
    {
                // Hier krijg je de geselecteerde notitie
                var selectedNote = (Note)lvnote.SelectedItems[0];

                // Voer de gewenste acties uit, zoals het openen van een nieuw venster
                var notedetailWindow = new notedetailWindow(selectedNote.Id);
                notedetailWindow.Activate();
                this.Close();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var klantaanmaakwindow = new klantaanmakenWindow();
            klantaanmaakwindow.Activate();
            this.Close();
        }
    }
}
