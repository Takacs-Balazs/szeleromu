using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            List<Szeleromu> szeleromuk = new List<Szeleromu>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("Szeleromu.txt");
            try
            {

                string[] sorok = sr.ReadLine().Split(";");

                foreach (string i in sorok)
                {

                    if (sorok.Length >= 4)
                    {
                        szeleromuk.Add(new Szeleromu(sorok[0], int.Parse(sorok[1]), int.Parse(sorok[2]), int.Parse(sorok[3])));

                    }
                }

                MessageBox.Show("A beolvasás sikeres volt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(("Hiba történt az állomány beolvasása során: " + ex.Message));
            }
            dataGrid.ItemsSource = szeleromuk;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                int adatokSzama = szeleromuk.Count;
                MessageBox.Show("Az állományban összesen " + adatokSzama + " szélerőmű adat van.");
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

           
                double averagePerformance = CalculateAveragePerformance();
                MessageBox.Show($"Átlagos teljesítmény (2010): {averagePerformance:F2} W");
            
         
            Szeleromu maxPerformance = szeleromuk[0];
            foreach (var szeleromu in szeleromuk)
            {
                if (szeleromu.Teljesitmeny > maxPerformance.Teljesitmeny)
                {
                    maxPerformance = szeleromu;
                }
            }
            MessageBox.Show(maxPerformance.ToString());
        }
        private double CalculateAveragePerformance()
        {
            double sum = 0;
            int count = 0;
            foreach (var szeleromu in szeleromuk)
            {
                if (szeleromu.MukesKezdete.Year == 2010)
                {
                    sum += szeleromu.Teljesitmeny;
                    count++;
                }
            }
            return sum / count;
        }

        private void btnTotalCount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Szélerőművek száma: {szeleromuk.Count}");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            StringBuilder report = new StringBuilder();
            foreach (var szeleromu in szeleromuk)
            {
                string category = szeleromu.GetCategory().ToString();
                report.AppendLine($"{szeleromu.Nev}, {szeleromu.Magassag}, {szeleromu.Teljesitmeny}, {category}");
            }

            File.WriteAllText("jelentes.txt", report.ToString());
            MessageBox.Show("Jelentés generálva: jelentes.txt");
        }
    }
}

