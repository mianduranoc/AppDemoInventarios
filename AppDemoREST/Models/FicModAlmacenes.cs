using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppDemoREST.Models
{
    public class FicModAlmacenes
    {
        public class ce_cat_almacenes
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdAlmacen { get; set; }
            public string DesAlmacen { get; set; }
            public string Capacidad { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        } // Almacen
    }
}
