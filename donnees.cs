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


    public void supprimerCommande(string email)
    {
        var commandeSUprime = dbContext.Clients.FirstOrDefault(f => f.email == email).Commandes.ToList();
        if (commandeSUprime != null)
        {
           // dbContext.Clients.Remove(clientSuprimer);
            dbContext.SaveChanges();
        }
    }

}
}
