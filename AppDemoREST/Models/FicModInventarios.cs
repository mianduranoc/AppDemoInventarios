using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static AppDemoREST.Models.FicModAlmacenes;
using static AppDemoREST.Models.FicModGenerales;
using static AppDemoREST.Models.FicModEstatus;
namespace AppDemoREST.Models
{
    public class FicModInventarios
    {
        public class ce_cat_inventarios
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdProdServ { get; set; }
            [StringLength(20)]
            public string IdAlmacen { get; set; }
            public string IdPresentacion { get; set; }
            public ce_cat_prod_serv_presenta ce_cat_prod_serv_presenta { get; set; }
            public ce_cat_almacenes ce_cat_almacenes { get; set; }
            [StringLength(50)]
            public string Ubicacion { get; set; }
            public float CantidadDisponible { get; set; }
            public float StockMaximo { get; set; }
            public float StockMinimo { get; set; }
            public float CantidadApartada { get; set; }
            public float CantidadMerma { get; set; }
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
        }
        public class ce_inventarios_series
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string NumSerie { get; set; }
            public string IdAlmacen { get; set; }
            public string IdPresentacion { get; set; }
            public Int16 IdProdServ { get; set; }
            public ce_cat_inventarios ce_cat_inventarios { get; set; }
            [StringLength(50)]
            public string Referencia { get; set; }
            public string UbicacionDet { get; set; }
            public Int16 IdTipoCondicion { get; set; }
            public cat_generales cat_generales { get; set; }
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
        }
        public class ce_inventarios_series_estatus
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string NumSerie { get; set; }            
            public Int16 IdEstatusDet { get; set; }
            public ce_inventarios_series ce_inventarios_series { get; set; }
            [StringLength(1)]
            public string TipoPedidoVenta { get; set; }
            public string Actual { get; set; }
            [StringLength(255)]
            public string Observacion { get; set; }
            [StringLength(50)]
            public string ReferenciaPedVta { get; set; }
            public Int16 IdEstatus { get; set; }
            public cat_estatus cat_estatus { get; set; }
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
        }
        public class ce_inventarios_series_caracteristicas
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string NumSerie { get; set; }            
            public Int16 IdCaracteristica { get; set; }
            public ce_inventarios_series ce_inventarios_series { get; set; }            
            [StringLength(50)]
            public string DesCaracteristica { get; set; }
            [StringLength(255)]
            public string Valor { get; set; }            
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
        }
        public class ce_cat_conceptos_prod_serv
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdProdServ { get; set; }
        }
        public class ce_cat_prod_serv_presenta
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Int16 IdProdServ { get; set; }
            public ce_cat_conceptos_prod_serv ce_cat_conceptos_prod_serv { get; set; }
            [StringLength(20)]
            public string IdPresentacion { get; set; }
        }
        
    }
}
