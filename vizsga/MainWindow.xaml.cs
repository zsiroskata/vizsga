using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vizsga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Vizsgazo> vizsgazok = new();
        public MainWindow()
        {
            InitializeComponent();

            using StreamReader sr = new StreamReader(
                path: @"..\..\..\src\adatok.txt",
                encoding: Encoding.UTF8
                );
            while (!sr.EndOfStream)
            {
                vizsgazok.Add(new Vizsgazo(sr.ReadLine()));
            }
            sr.Close();

            foreach (var item in vizsgazok)
            {
                nevLista.Items.Add(item.Nev);
            }
            vizsga.Content = $"{vizsgazok.Count} vizsgázó adatait beolvastuk";


           

        }

        private void sikerButton_Click(object sender, RoutedEventArgs e)
        {
            int sikeresVizsga = 0;
            foreach (var item in vizsgazok)
            {
                if (item.IT > 0.50 && item.Programozas> 0.50 && item.HalozatA > 0.50 && item.HalozatB > 0.50 && item.HalozatC > 0.50 && item.HalozatD > 0.50 && item.SzobeliAngol > 0.50 && item.SzobeliIT > 0.50)
                {
                    sikeresVizsga++;
                }
            }

            sikerLabel.Content = $"{sikeresVizsga} fő";

        }

        private void eredmenyButton_Click(object sender, RoutedEventArgs e)
        {
            using StreamWriter sw = new StreamWriter(path: @"..\..\..\src\vizsgaredmenyek.txt", append: false);

            foreach (var tanulo in vizsgazok)
            {
                double vegeredmeny = tanulo.vegeredmeny(tanulo.HalozatC);
                string erdemjegy = tanulo.erdemjegy(tanulo.HalozatC);

                sw.WriteLine($"{tanulo.Nev}\t{vegeredmeny:F2}\t{erdemjegy}");
            }

            sw.Close();
        }

        private void keresBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                foreach (var item in vizsgazok)
                {
                    if (item.Nev.ToLower().Contains(tanulo.Text.ToLower()))
                    {
                        legjobb.Content = $"{item.LegjobbEredmeny()}%";
                        leggyengebb.Content = $"{item.LeggyengebbEredmeny()}%";

                        if (item.LeggyengebbEredmeny() >= 0.51)
                        {
                            vizsgaEredmeny.Content = "Sikeres vizsgát tett!";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem szerepel ilyen név a listában!");
                        break;
                    }
               
                }

            }

        }

      
    }
}