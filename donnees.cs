using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleWangueuWPF
{
    class donnees
    {
        WANGUEUEntities dbContext = new WANGUEUEntities();

        public void Actualiser()
        {

        }
        public List<Client> ListeClient()
        {
            
            var liste = dbContext.Clients.ToList();
            return liste;
        }

        public void ajouterClient(string nom, string prenom, string email, string password)
        {
            var client = new Client();
            client.nom = nom;
            client.prenom = prenom;
            client.email = email;
            client.password = password;

            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
        }


        public void supprimerClient(Client cli)
        {
            var clientSuprimer = dbContext.Clients.FirstOrDefault(f => f.id_client == cli.id_client);
            if (clientSuprimer != null)
            {
                dbContext.Clients.Remove(clientSuprimer);
                dbContext.SaveChanges();
            }
        }

        public void ModifierClient(Client cli)
        {
            var clientModifier = dbContext.Clients.FirstOrDefault(f => f.id_client == cli.id_client);
            clientModifier.nom = cli.nom;
            clientModifier.prenom = cli.prenom;
            clientModifier.email = cli.email;
            clientModifier.password = cli.password;

            dbContext.SaveChanges();

        }

        //parti du produit

        public List<Produit> ListeProduit()
        {
            
            var liste = dbContext.Produits.ToList();
            return liste;
        }

    public void ajouterProduit(string nom)
    {
        var produit = new Produit();
            produit.nom = nom;

            dbContext.Produits.Add(produit);
       dbContext.SaveChanges();
           
    }


    public void supprimerProduit(Produit p)
    {
            var ProduitSuprime = dbContext.Produits.FirstOrDefault(f => f.id_produit == p.id_produit);
        
        
           dbContext.Produits.Remove(ProduitSuprime);
            dbContext.SaveChanges();
        
    }

        // parti du stock

        public List<Stock> listeStock()
        {
            var liste = dbContext.Stocks.ToList();
            return liste;
        }

        public void ajouterStock()
        {
            var ajouter = (from sto in dbContext.Stocks
                           join prod in dbContext.Produits on sto.id_stock equals prod.id_stock
                           select sto).Count();
          
            
            dbContext.SaveChanges();
                           
        }
}
}
