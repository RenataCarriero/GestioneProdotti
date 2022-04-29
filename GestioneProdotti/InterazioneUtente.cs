using GestioneProdotti.Entities;
using GestioneProdotti.Interfaces;
using GestioneProdotti.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti
{
    internal static class InterazioneUtente
    {
        
        static IRepositoryProdAlimentare repoAlimentari = new RepositoryProdAlimentariMOCK();
        static IRepositoryProdTecnologico repoProdTecnologici = new RepositoryProdTecnologiciMOCK();
        internal static void Start()
        {
            bool continua = true;
            while (continua) // continua==true
            {
                int scelta = Menu();
                switch (scelta)
                {
                    case 1:
                        VisualizzaTuttiIProdotti();
                        break;
                    case 2:
                        VisualizzaAlimentari();
                        break;
                    case 3:
                        VisualizzaProdottiTecnologici();
                        break;
                    case 4:
                        AggiungiProdottoTecnologico();
                        break;
                    case 5:
                        AggiungiProdottoAlimentare();
                        break;
                    case 6:
                        CercaAlimentarePerCodice();
                        break;
                    case 7:
                        CercaProdottiTecnoPerMarca();
                        break;
                    case 8:
                        VisualizzaProdottiTecnologiciNuovi();
                        break;
                    case 9:
                        VisualizzaAlimentariScadenzaOggi();
                        break;
                    case 10:
                        VisualizzaAlimentariInScadenza();
                        break;
                    case 0:
                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Scelta errata.");
                        break;
                }
            }
        }

        private static void VisualizzaAlimentariInScadenza()
        {
            var prodotti = repoAlimentari.GetProdottiInScadenza();
            if (prodotti.Count == 0)
            {
                Console.WriteLine("Nessun prodotto in scadenza nei prossimi 3 giorni");
            }
            else
            {
                foreach (var item in prodotti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VisualizzaAlimentariScadenzaOggi()
        {
            var prodotti = repoAlimentari.GetProdottiConScadenzaOggi();
            if (prodotti.Count == 0)
            {
                Console.WriteLine("Nessun prodotto in scadenza oggi");
            }
            else
            {
                foreach (var item in prodotti)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static void VisualizzaProdottiTecnologiciNuovi()
        {
            var prodNuovi = repoProdTecnologici.GetProdottiNuovi();
            if (prodNuovi.Count > 0)
            {
                foreach (var item in prodNuovi)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Nessun prodotto nuovo");
            }

        }

        private static void CercaProdottiTecnoPerMarca()
        {
            Console.WriteLine("Inserisci la marca");
            string marca = Console.ReadLine();
            var prodRecuperati = repoProdTecnologici.GetProdottiByMarca(marca);
            if (prodRecuperati.Count == 0)
            {
                Console.WriteLine("Nessun prodotto della marca inserita");
            }
            else
            {
                Console.WriteLine($"Prodotti della marca {marca}:");
                foreach (var item in prodRecuperati)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void CercaAlimentarePerCodice()
        {
            Console.WriteLine("Inserisci il codice del prodotto Alimentare da ricercare");
            string codice = Console.ReadLine();
            var prodRecuperato = repoAlimentari.GetByCodice(codice);
            if (prodRecuperato == null)
            {
                Console.WriteLine("Nessun prodotto corrispondente a questo codice");
            }
            else
            {
                Console.WriteLine(prodRecuperato);
            }
        }

        private static void AggiungiProdottoAlimentare()
        {
            Console.WriteLine("Inserisci il codice del nuovo prodotto");
            string codice = Console.ReadLine();
            while (repoAlimentari.GetByCodice(codice) != null)
            {
                Console.WriteLine("Codice già presente. Riprova");
                codice = Console.ReadLine();
            }
            Console.WriteLine("Inserisci la descrizione del nuovo prodotto");
            string descrizione = Console.ReadLine();

            Console.WriteLine("Inserisci prezzo in euro");
            double prezzo;
            while (!double.TryParse(Console.ReadLine(), out prezzo))
            {
                Console.WriteLine("Formato non valido. Riprova..");
            }
            Console.WriteLine("Inserisci quantità disponibile");
            int qta;
            while (!(int.TryParse(Console.ReadLine(), out qta) && qta >= 0))
            {
                Console.WriteLine("Inserisci un numero maggiore o uguale a zero. Riprova..");
            }
            Console.WriteLine("Inserisci data scadenza prodotto");
            DateTime dataScadenza;
            while (!(DateTime.TryParse(Console.ReadLine(), out dataScadenza) && dataScadenza >= DateTime.Today))
            {
                Console.WriteLine("Formato data con corretto. Riprova..");
            }
            var prod = new ProdottoAlimentare(codice, descrizione, prezzo, qta, dataScadenza);
            var esito = repoAlimentari.Aggiungi(prod);
            if (esito)
            {
                Console.WriteLine("Prodotto aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("impossibile aggiungere il prodotto.");
            }
        }

        private static void AggiungiProdottoTecnologico()
        {
            Console.WriteLine("Inserisci il codice del nuovo prodotto");
            string codice = Console.ReadLine();
            while (repoProdTecnologici.GetByCodice(codice) != null)
            {
                Console.WriteLine("Codice già presente. Riprova");
                codice = Console.ReadLine();
            }
            Console.WriteLine("Inserisci la descrizione del nuovo prodotto");
            string descrizione = Console.ReadLine();

            Console.WriteLine("Inserisci prezzo in euro");
            double prezzo;
            while (!double.TryParse(Console.ReadLine(), out prezzo))
            {
                Console.WriteLine("Formato non valido. Riprova..");
            }
            Console.WriteLine("Inserisci marca");
            string marca = Console.ReadLine();
            Console.WriteLine("Stato del prodotto: NUOVO o USATO?");
            string stato = Console.ReadLine();
            bool isNew = stato.ToUpper() == "NUOVO" ? true : false;
            var prod = new ProdottoTecnologico(codice, descrizione, prezzo, marca, isNew);
            var esito = repoProdTecnologici.Aggiungi(prod);
            if (esito)
            {
                Console.WriteLine("Prodotto aggiunto correttamente");
            }
            else
            {
                Console.WriteLine("impossibile aggiungere il prodotto.");
            }
        }



        private static void VisualizzaProdottiTecnologici()
        {
            var prodotti = repoProdTecnologici.GetAll();
            if (prodotti.Count > 0)
            {
                Console.WriteLine($"Ecco i {prodotti.Count} prodotti tecnologici presenti:");
                int i = 1;
                foreach (var item in prodotti)
                {
                    Console.WriteLine($"{i++}. " + item);
                }
            }
        }

        private static void VisualizzaAlimentari()
        {
            var prodotti = repoAlimentari.GetAll();
            if (prodotti.Count > 0)
            {
                Console.WriteLine($"Ecco i {prodotti.Count} prodotti alimentari presenti:");
                int i = 1;
                foreach (var item in prodotti)
                {
                    Console.WriteLine($"{i++}. " + item);
                }
            }
        }

        private static void VisualizzaTuttiIProdotti()
        {
            List<Prodotto> prodotti = new List<Prodotto>();
            prodotti.AddRange(repoAlimentari.GetAll());
            prodotti.AddRange(repoProdTecnologici.GetAll());

            if (prodotti.Count > 0)
            {
                Console.WriteLine("Elenco completo dei prodotti:");
                int i = 1;
                foreach (var item in prodotti)
                {
                    Console.WriteLine($"{i++}.{item}\n");
                }
            }
            else
            {
                Console.WriteLine("Non ci sono prodotti");
            }
        }

        private static int Menu()
        {
            Console.WriteLine("---------------MENU----------");
            Console.WriteLine("1.Visualizza tutti i Prodotti");
            Console.WriteLine("2.Visualizza tutti i Prodotti Alimentari");
            Console.WriteLine("3.Visualizza tutti i Prodotti Tenologici");
            Console.WriteLine("4.Aggiungi un prodotto Tecnologico");
            Console.WriteLine("5.Aggiungi un prodotto Alimentare");
            Console.WriteLine("6.Cercare un prodotto Alimentare per codice");
            Console.WriteLine("7.Cercare un prodotto tecnologico per Marca");
            Console.WriteLine("8.Visualizzare i Prodotti Tecnologici nuovi");
            Console.WriteLine("9.Visualizzare i prodotti alimentari in scadenza oggi");
            Console.WriteLine("10.Visualizzare i prodotti alimentari che scadono tra meno 3 giorni");
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("\nInserisci la tua scelta:");
            //int sceltaUtente=int.Parse(Console.ReadLine());
            int sceltaUtente;
            while (!(int.TryParse(Console.ReadLine(), out sceltaUtente) /*&& sceltaUtente >= 0 && sceltaUtente <= 10*/))
            {
                Console.WriteLine("Scelta errata. Riprova..");
            }
            return sceltaUtente;
        }
    }
}
