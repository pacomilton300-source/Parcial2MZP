using CadParcial2MZP;
using System.Collections.Generic;
using System.Linq;

namespace ClnParcial2MZP
{
    public class CategoriaProgramaCln
    {
        private Parcial2MZPEntities db = new Parcial2MZPEntities();

        public List<CategoriaPrograma> listar()
        {
            return db.CategoriaPrograma.Where(x => x.estado != -1).ToList();
        }
    }
}
