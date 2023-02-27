using Ejercicio4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Controllers
{
    public class EmpleadoBD
    {
        readonly SQLiteAsyncConnection db;

        public EmpleadoBD()
        {
        }
        public EmpleadoBD(string pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            db.CreateTableAsync<Empleado>();
        }

        public Task<List<Empleado>> listaempleados()
        {
            return db.Table<Empleado>().ToListAsync();
        }

        public Task<Empleado> ObtenerEmpleado(int pcodigo)
        {
            return db.Table<Empleado>().Where(i => i.id == pcodigo).FirstOrDefaultAsync();
        }

        public Task<int> EmpleadoGuardar(Empleado empleado)
        {
            if (empleado.id != 0)
            {
                return db.UpdateAsync(empleado);
            }
            else
            {
                return db.InsertAsync(empleado);
            }
        }

        public Task<int> EmpleadoBorrar(Empleado empleado)
        {
            return db.DeleteAsync(empleado);
        }
    }
}
