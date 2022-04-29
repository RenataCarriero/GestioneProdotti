using GestioneProdotti.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneProdotti.Interfaces
{
    internal interface IRepositoryProdTecnologico: IRepository<ProdottoTecnologico>
    {
        List<ProdottoTecnologico> GetProdottiNuovi();
        List<ProdottoTecnologico> GetProdottiByMarca(string marca);        
    }
}
