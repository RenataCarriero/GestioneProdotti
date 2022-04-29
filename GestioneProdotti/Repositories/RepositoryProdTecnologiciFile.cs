using GestioneProdotti.Entities;
using GestioneProdotti.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Repositories
{
    internal class RepositoryProdTecnologiciFile : IRepositoryProdTecnologico
    {
        string path = @"C:\Users\RenataCarriero\source\repos\GestioneProdotti\GestioneProdotti\Repositories\ProdottiTecnologici.txt";

        public bool Aggiungi(ProdottoTecnologico item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice} - {item.Descrizione} - {item.Prezzo} - {item.Marca} - {item.IsNew}");
            }
            return true;
        }

        public List<ProdottoTecnologico> GetAll()
        {
            List<ProdottoTecnologico> prodottiTecnologici = new List<ProdottoTecnologico>();
            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();

                if (string.IsNullOrEmpty(contenutoFile))//(contenutoFile==null || contenutoFile == "")
                {
                    return prodottiTecnologici;
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split(" - ");
                        ProdottoTecnologico p = new ProdottoTecnologico();
                        p.Codice = campiDellaRiga[0];
                        p.Descrizione = campiDellaRiga[1];
                        p.Prezzo = double.Parse(campiDellaRiga[2]);
                        p.Marca = campiDellaRiga[3];
                        p.IsNew = bool.Parse(campiDellaRiga[4]);
                        prodottiTecnologici.Add(p);
                    }
                }
                return prodottiTecnologici;
            }
        }

        public ProdottoTecnologico GetByCodice(string codice)
        {

            foreach (var item in GetAll())
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
            var listaFiltrata =new List<ProdottoTecnologico>();
            foreach (var item in GetAll())
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
            var listaFiltrata = new List<ProdottoTecnologico>();
            foreach (var item in GetAll())
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
