using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyCalendar;
using Newtonsoft.Json;

namespace MyCalendarWPF
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (anneeTxt.Text == string.Empty || moisTxt.Text == string.Empty)
                {
                    MessageBox.Show("Remplisser le mois et l'année");
                    return;
                }
                try
                {
                    Convert.ToInt32(anneeTxt.Text);
                    Convert.ToInt32(moisTxt.Text);
                }
                catch
                {
                    MessageBox.Show("Veuillez remplir des chiffres valides");
                    return;
                }
                int year = int.Parse(anneeTxt.Text);
                int month = int.Parse(moisTxt.Text);

                Calendrier myCalendar = new Calendrier(year, month);

                //Appel De ma Classe Calendrier pour récupérer les jours d'un mois d'une Année
                List<DateTime> myList = myCalendar.GetMonthDays();

                List <Week> myListOfWeek = myCalendar.GetWeeksForAMonth(myList);
                dataGrid.ItemsSource = myListOfWeek;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
