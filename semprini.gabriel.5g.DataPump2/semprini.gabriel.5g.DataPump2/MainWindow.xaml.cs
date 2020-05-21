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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace semprini.gabriel._5g.DataPump2
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr1 = new StreamReader("Coordinatori.csv");
            StreamReader sr2 = new StreamReader("Classi.csv");
            StreamReader sr3 = new StreamReader("Docenti.csv");
            StreamWriter sw1 = new StreamWriter("NomeFile1.sql");
            StreamWriter sw2 = new StreamWriter("NomeFile2.sql");
            StreamWriter sw3 = new StreamWriter("NomeFile3.sql");

            while (!sr1.EndOfStream & !sr2.EndOfStream & !sr3.EndOfStream)
            {
                string[] colonne = sr1.ReadLine().Split(';', '/');
                string[] colonne1 = sr2.ReadLine().Split(';', '/');
                string[] colonne2 = sr3.ReadLine().Split(';', '/');
                sw1.WriteLine($"insert into csv(classe,coordinatore) values(\"{colonne[0]}\",\"{colonne[1]}\")");
                sw2.WriteLine($"insert into csv(ID,idclasse,nomeclasse,Specializzazione,Articolazione,CodiceMinisteriale,Aula,Sede,CodiceCoordinatore) values(\"{colonne1[0]}\",\"{colonne1[1]}\",\"{colonne1[2]}\",\"{colonne1[3]}\",\"{colonne1[4]}\",\"{colonne1[5]}\",\"{colonne1[6]}\",\"{colonne1[7]}\",,\"{colonne1[8]}\")");
                sw3.WriteLine($"insert into csv(ID,iddocente,nomedocente,ClasseConcorso_1,Sesso,TipoContratto,Email) values(\"{colonne2[0]}\",\"{colonne2[1]}\",\"{colonne2[2]}\",\"{colonne2[3]}\",\"{colonne2[4]}\",\"{colonne2[5]}\",\"{colonne2[6]}\")");

            };


            sw1.Close();
            sw2.Close();
            sw3.Close();
            sr1.Close();
            sr2.Close();
            sr3.Close();
        }
    }
}
