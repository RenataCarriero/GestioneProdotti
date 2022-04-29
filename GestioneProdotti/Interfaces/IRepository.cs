using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Interfaces
{
    internal interface IRepository<T>
    {
        List<T> GetAll();
        bool Aggiungi(T item);
        T GetByCodice(string codice);
    }
}
