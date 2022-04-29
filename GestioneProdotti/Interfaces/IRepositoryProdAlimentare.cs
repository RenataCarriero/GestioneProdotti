using GestioneProdotti.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Interfaces
{
    internal interface IRepositoryProdAlimentare: IRepository<ProdottoAlimentare>
    {
        List<ProdottoAlimentare> GetProdottiConScadenzaOggi();
        List<ProdottoAlimentare> GetProdottiInScadenza();
        
    }
}
