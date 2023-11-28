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
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Aspose.Foundation;
using Aspose.Pdf;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class offerteWindow : Window
    {
        public offerteWindow()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string klantNaam = KlantNaamTextBox.Text;
            string klantAdres = KlantAdresTextBox.Text;
            string postcode = PostcodeTextBox.Text;
            string periode = PeriodeTextBox.Text;


            // The path to the documents directory.
            string dataDir = "C:\\pdfbaroc\\offerte.pdf";

            // Initialize document object
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            // Add page
            Aspose.Pdf.Page page = document.Pages.Add();
            // Add text to new page
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"Klantnaam: {klantNaam}\nKlantadres: {klantAdres}\nPostcode: {postcode}\nPeriode: {periode}"));
            // Save updated PDF
            document.Save(dataDir + "offerte.pdf");
        }
    }
}
