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
using System.Net;
using System.Net.Mail;

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


            /*// Afzender en ontvanger e-mailadressen
            string afzender = "";
            string ontvanger = "thomasbouman1505@gmail.com";

            // SMTP-server en poort
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            // Gebruikersnaam en wachtwoord voor authenticatie
            string gebruikersnaam = "D290249@edu.curio.nl";
            string wachtwoord = "";

            // Onderwerp van de e-mail
            string onderwerp = "Aangepaste mail met variabelen";

            // Aangepaste gegevens voor de inhoud van de e-mail
            string naam = "John Doe";
            int leeftijd = 30;

            // Inhoud van de e-mail met variabelen
            string inhoud = $"Beste {naam},\n\nDit is een aangepaste e-mail vanuit C#. Je bent {leeftijd} jaar oud.";

            MailMessage mail = new MailMessage(afzender, ontvanger, onderwerp, inhoud);

            // Maak een SmtpClient-object en configureer het
            SmtpClient smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(gebruikersnaam, wachtwoord);
            smtpClient.EnableSsl = true; // Schakel SSL in als de SMTP-server dit vereist*/


            var saleswindow = new SalesWindow();
            saleswindow.Activate();
            this.Close();


        }
    }
}
