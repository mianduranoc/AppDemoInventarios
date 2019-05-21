using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AppDemoREST.Models
{
    public class FicModEstatus
    {
        public class cat_tipos_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoEstatus { get; set; }
            [StringLength(50)]
            public string DesTipoEstatus { get; set; }
            public DateTime FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        } // tipos_generales
        public class cat_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdEstatus { get; set; }
            public Int16 IdTipoEstatus { get; set; }
            public cat_tipos_estatus cat_tipos_estatus { get; set; }
            [StringLength(50)]
            public string DesEstatus { get; set; }
            public DateTime FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
        } // tipos_generales
    }
}
