using CadParcial2MZP;
using System.Collections.Generic;
using System.Linq;

namespace ClnParcial2MZP
{
    public class CanalCln
    {
        private Parcial2MZPEntities db = new Parcial2MZPEntities();

        public List<Canal> listar()
        {
            return db.Canal.ToList();
        }
    }
}