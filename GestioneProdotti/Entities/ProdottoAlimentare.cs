using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Entities
{
    internal class ProdottoAlimentare : Prodotto
    {
        public int QuantitàInMagazzino { get; set; }
        public DateTime DataScadenza { get; set; }
        public int GiorniMancantiAllaScadenza { get { return CalcolaGiorni(); } }

        public ProdottoAlimentare()
        {

        }
        public ProdottoAlimentare(string codice, string descrizione, double prezzo, int quantita, DateTime dataScadenza )
            :base(codice, descrizione,prezzo)
        {
            QuantitàInMagazzino = quantita;
            DataScadenza=dataScadenza;
        }
        public int CalcolaGiorni()
        {
            return (DataScadenza - DateTime.Today).Days;
        }
        public override string ToString()
        {
            return base.ToString() + $" {QuantitàInMagazzino} pezzi disponibili.\tScadenza: {DataScadenza.ToShortDateString()} quindi scade {StampaGiorniScadenza()}";
        }

        private string StampaGiorniScadenza()
        {
            if (GiorniMancantiAllaScadenza == 0)
            {
                return "oggi!";
            }else if(GiorniMancantiAllaScadenza == 1)
            {
                return "domani!";
            }
            else
            {
                return $"tra {GiorniMancantiAllaScadenza} giorni!";
            }
        }
    }
}
