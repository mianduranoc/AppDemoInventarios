using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppDemoREST.Models
{
    public class FicModGenerales
    {
        public class cat_tipos_generales
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdTipoGeneral { get; set; }
            [StringLength(50)]
            public string DesTipoGeneral { get; set; }           
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
        public class cat_generales
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdGeneral { get; set; }
            public Int16 IdTipoGeneral { get; set; }
            public cat_tipos_generales cat_tipos_generales { get; set; }
            [StringLength(50)]
            public string DesGeneral { get; set; }
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
