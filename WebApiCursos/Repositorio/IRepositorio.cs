using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCursos.Repositorio
{
    interface IRepositorio<TEntidad>//es necesario un generic para el repositorio
    {

        //los pondré como int porque quiero el número de registros afectados.
        int Add(TEntidad modelo);//método añadir, siempre lo necesito, estos métodos ya los tengo desacoplados y personalizables, y puedo reutilizarlos
        int Borrar(int id);
        int Borrar(Expression<Func<TEntidad, bool>> lam);//este es un borrar donde podré insertar búiquedas. 
        //Le meto una expresión landa que va a ser la función, con un objeto TEntidad, me devuelva un booleano.
        int Actualizar(TEntidad modelo);
        List<TEntidad> Get();//para devolver todos los objetos
        List<TEntidad> Get(Expression<Func<TEntidad, bool>> lam);//para devolver el objeto buscado por la función
        TEntidad Get(int pk);//para devolver el onjeto buscado por clave pimaria
        



    }
}
