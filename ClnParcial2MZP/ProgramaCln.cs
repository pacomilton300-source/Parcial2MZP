using CadParcial2MZP;
using System.Collections.Generic;
using System.Linq;

namespace ClnParcial2MZP
{
    public class ProgramaCln
    {
        private Parcial2MZPEntities db = new Parcial2MZPEntities();

        public dynamic listar()
        {
            return db.Programa
                .Where(x => x.estado != -1)
                .ToList()
                .Select(x => new
                {
                    x.id,
                    x.idCanal,
                    Canal = x.Canal.nombre,
                    x.idCategoriaPrograma,
                    Categoria = x.CategoriaPrograma != null ? x.CategoriaPrograma.nombre : "Sin categoría",
                    x.titulo,
                    x.descripcion,
                    x.duracion,
                    x.productor,
                    x.fechaEstreno,

                })
                .ToList();
        }

        public void insertar(Programa p)
        {
            p.estado = 1;

            db.Programa.Add(p);
            db.SaveChanges();
        }

        public void actualizar(Programa p)
        {
            Programa programa = db.Programa.Find(p.id);

            programa.idCanal = p.idCanal;
            programa.idCategoriaPrograma = p.idCategoriaPrograma;
            programa.titulo = p.titulo;
            programa.descripcion = p.descripcion;
            programa.duracion = p.duracion;
            programa.productor = p.productor;
            programa.fechaEstreno = p.fechaEstreno;

            db.SaveChanges();
        }

        public void eliminar(int id)
        {
            Programa programa = db.Programa.Find(id);

            programa.estado = -1;

            db.SaveChanges();
        }
    }
}