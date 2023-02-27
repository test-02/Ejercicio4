using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio4.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] image { get; set; }
    }
}
