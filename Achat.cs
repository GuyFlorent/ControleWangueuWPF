//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleWangueuWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Achat
    {
        public int id_achat { get; set; }
        public Nullable<int> quantité { get; set; }
        public int id_produit { get; set; }
        public Nullable<int> id_commande { get; set; }
    
        public virtual Commande Commande { get; set; }
        public virtual Produit Produit { get; set; }
    }
}