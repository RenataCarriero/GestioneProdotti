using GestioneProdotti.Entities;
using GestioneProdotti.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Repositories
{
    internal class RepositoryProdAlimentariMOCK : IRepositoryProdAlimentare
    {
        static private List<ProdottoAlimentare> alimentari = new List<ProdottoAlimentare>()
        {
            new ProdottoAlimentare("A1", "Farina 00", 1.20, 130, new DateTime(2022, 05, 31)),
            new ProdottoAlimentare("A2", "Tonno Riomare", 5.30, 200, new DateTime(2023, 07,31)),                
            new ProdottoAlimentare("A3", "Pomodori", 1.30, 100, new DateTime(2022, 04,30)),                
            new ProdottoAlimentare("A4", "Noci", 3.400, 30, new DateTime(2022, 04,29)),                
            new ProdottoAlimentare("A5", "Mozzarelle", 2.50, 40, new DateTime(2022, 04,26))                
        };

        public bool Aggiungi(ProdottoAlimentare item)
        {
            if (item == null)
            {
                return false;
            }
            else
            {
               alimentari.Add(item);
                return true;
            }
        }

        public List<ProdottoAlimentare> GetAll()
        {
            return alimentari;
        }

        public ProdottoAlimentare GetByCodice(string codice)
        {
            if (string.IsNullOrEmpty(codice))
                return null;

            foreach (var item in alimentari)
            {
                if (item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }

        public List<ProdottoAlimentare> GetProdottiConScadenzaOggi()
        {
            List<ProdottoAlimentare> listaFiltrata=new List<ProdottoAlimentare>(); 
            foreach (var item in alimentari)
            {
                if (item.DataScadenza == DateTime.Today)
                {
                    listaFiltrata.Add(item);
                }
            }
            return listaFiltrata;
        }

        public List<ProdottoAlimentare> GetProdottiInScadenza()
        {
            List<ProdottoAlimentare> listaFiltrata = new List<ProdottoAlimentare>();
            foreach (var item in alimentari)
            {
                if (item.GiorniMancantiAllaScadenza >=0 && item.GiorniMancantiAllaScadenza<=3)
                {
                    listaFiltrata.Add(item);
                }
            }
            return listaFiltrata;
        }
    }
}
