using System;
using System.Collections.Generic;
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

namespace ControleWangueuWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Client> test;
        private Client cli;
        private List<Produit> prod;
        private Produit clipro;
        public MainWindow()
        {
            InitializeComponent();
            
            donnees donnees = new donnees();
            // donnees.ajouterClient("etoo", "fils", "etoo.@yohh.com", "hyir");
            prod = donnees.ListeProduit();

            produitDataGrid.DataContext = prod;
            test = donnees.ListeClient();

            clientDataGrid.DataContext = test;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // clientViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource produitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("produitViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // produitViewSource.Source = [source de données générique]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MonTab.SelectedIndex = 2;
            int i = clientDataGrid.SelectedIndex;

            this.cli = test[i];
            txtNom.Text = cli.nom;
            txtPrenom.Text = cli.prenom;
            txtEmail.Text = cli.email;
            txtPassWord.Text = cli.password;
           

        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            donnees donnees = new donnees();

            this.cli.email = txtEmail.Text;
            this.cli.nom = txtNom.Text;
            this.cli.prenom = txtPrenom.Text;
            this.cli.password = txtPassWord.Text;

            donnees.ModifierClient(this.cli);
            test = donnees.ListeClient();

            clientDataGrid.DataContext = test;
            MessageBox.Show("modifier avec succes!");
            txtNom.Text = ""; txtPrenom.Text = ""; txtEmail.Text = ""; txtPassWord.Text = "";

        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            donnees donnees = new donnees();
            if (txtNom.Text != null && txtPrenom.Text != null && txtEmail.Text != null && txtPassWord.Text != null &&
                txtNom.Text != "" && txtPrenom.Text != "" && txtEmail.Text != "" && txtPassWord.Text != "")
            {
                donnees.ajouterClient(txtNom.Text, txtPrenom.Text, txtEmail.Text, txtPassWord.Text);
            }
            else 
            {
                donnees.ajouterProduit(txtNom.Text);
                prod = donnees.ListeProduit();
                produitDataGrid.DataContext = prod;

            }
            
            test = donnees.ListeClient();

            clientDataGrid.DataContext = test;
            txtNom.Text = ""; txtPrenom.Text = ""; txtEmail.Text = ""; txtPassWord.Text = "";
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            donnees donnees = new donnees();
            donnees.supprimerClient(this.cli);
            test = donnees.ListeClient();

            clientDataGrid.DataContext = test;
            MessageBox.Show("Supprimer avec succes!");

        }

        private void clientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  donnees donnees = new donnees();
           // donnees.ModifierClient(this.cli);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MonTab.SelectedIndex = 1;
            int i = clientDataGrid.SelectedIndex;

            this.clipro= prod[i];
            txtNom.Text = clipro.nom;
        }
    }
}
