using GestioneProdotti.Entities;
using GestioneProdotti.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Repositories
{
    internal class RepositoryProdTecnologiciMOCK : IRepositoryProdTecnologico

    {
        private static List<ProdottoTecnologico> prodottiTecnologici = new List<ProdottoTecnologico>()
        {
            new ProdottoTecnologico("T1","Televisore 55 pollici", 625.56, "Samsung", true),
            new ProdottoTecnologico("T2","Smartphone", 100, "Samsung", false),
            new ProdottoTecnologico("T3","Televisore 60 pollici", 750, "Sony", true)
        };

        public bool Aggiungi(ProdottoTecnologico item)
        {
            if (item == null)
            {
                return false;
            }
            else
            {
                prodottiTecnologici.Add(item);
                return true;
            }
        }

        public List<ProdottoTecnologico> GetAll()
        {
            return prodottiTecnologici;
        }

        public ProdottoTecnologico GetByCodice(string codice)
        {
            if (string.IsNullOrEmpty(codice))
                return null;

            foreach (var item in prodottiTecnologici)
            {
                if (item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }

        public List<ProdottoTecnologico> GetProdottiByMarca(string marca)
        {
            List<ProdottoTecnologico> listaFiltrata = new List<ProdottoTecnologico>();
            foreach (var item in prodottiTecnologici)
            {
                if (item.Marca == marca)
                {
                    listaFiltrata.Add(item);
                }
            }
            return listaFiltrata;
        }

        public List<ProdottoTecnologico> GetProdottiNuovi()
        {
            List<ProdottoTecnologico> listaFiltrata = new List<ProdottoTecnologico>();
            foreach (var item in prodottiTecnologici)
            {
                if (item.IsNew == true)
                {
                    listaFiltrata.Add(item);
                }
            }
            return listaFiltrata;
        }
    }
}
