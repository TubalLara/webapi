using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApiCursos.Models;

namespace WebApiCursos.Repositorio
{
    public class Repositorio<TEntidad>:IRepositorio<TEntidad> where TEntidad:class //el where se lo ponemos para que sea una clase
    {

        private cursosEntities Context;//creo el objeto contect que lo que contiene es el acceso a la base datos


        public Repositorio(cursosEntities context)//aquí instancio la conexión
        {
            Context = context;
        }

        protected DbSet<TEntidad> DbSet//creo un método para poder acceder al set y lo parametrizo para poder elegir los métodos.
            //DbContexte es siempre el contexto de la base datos y DbSet el conjunto de tablas de la base de datos
        {
            get { return Context.Set<TEntidad>();}//esto devuelve el DbSet de esta tabla concreta
        } 
 
        public virtual int Add(TEntidad modelo)//el n es para que salga un 0 si esto falla y poder utilizarlo para saber si ha fallado o no
        {
            DbSet.Add(modelo);
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
            }
            return n;
        }

        public virtual int Borrar(int id)//como no sabemos que id tiene el obj tenemos que recuperarlo antes
        {
            var obj = Get(id);

            DbSet.Remove(obj);
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
            }
            return n;
        }

        public virtual int Borrar(Expression<Func<TEntidad, bool>> lam)
        {
            var datos = Get(lam);
            
            DbSet.RemoveRange(datos);
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
            }
            return n;
        }

      

        public virtual int Actualizar(TEntidad modelo)//voy a marcarlo como modificado y decirle que me lo guarde
        {
            Context.Entry(modelo).State = EntityState.Modified;//el método entry me permite decirle en qué estado está a un tipo de objeto
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
            }
            return n;

        }

        public virtual List<TEntidad> Get()
        {
            return DbSet.ToList();
        }

        public virtual List<TEntidad> Get(Expression<Func<TEntidad, bool>> lam)
        {
            return DbSet.Where(lam).ToList();
        }

        public virtual TEntidad Get(int pk)
        {
            return DbSet.Find(pk);
        }
    }
}