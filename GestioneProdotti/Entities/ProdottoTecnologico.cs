using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Entities
{
    internal class ProdottoTecnologico: Prodotto
    {
        public string Marca { get; set; }
        public bool IsNew { get; set; } = true;

        public ProdottoTecnologico()
        {

        }
        public ProdottoTecnologico(string codice, string descrizione, double prezzo, string marca, bool isNew)
            : base(codice, descrizione, prezzo)
        {
            Marca = marca;
            IsNew = isNew;
        }
        public override string ToString()
        {
            return base.ToString() + $"Marca: {Marca}  Questo prodotto è: {Condizione()}";
        }
        
        private string Condizione()
        {
            if (IsNew)
                return "NUOVO";
            else
                return "USATO";
        }
    }
}
