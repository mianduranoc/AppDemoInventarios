using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDemoREST.Data;
using static AppDemoREST.Models.FicModAlmacenes;

namespace AppDemoREST.Controllers
{
    [Produces("application/json")]
    public class FicApiAlmacenesController : Controller
    {
        private readonly FicDBContext FicLoDBContext;
        public FicApiAlmacenesController(FicDBContext FicPaBDContext)
        {
            FicLoDBContext = FicPaBDContext;
        }
        //consulta completa, consulta por id cedi, insert inventario, modificacion inventario, eliminar inventario
        [HttpGet]
        [Route("/api/almacenes/id")]
        public async Task<IActionResult> FicApiGetListInventarios([FromQuery]string almacen)
        {

            var ce_cat_almacenes = (from data_inv in FicLoDBContext.ce_cat_almacenes where data_inv.IdAlmacen == almacen select data_inv).ToList();
            if (ce_cat_almacenes.Count() > 0)
            {
                ce_cat_almacenes = ce_cat_almacenes.ToList();
                return Ok(ce_cat_almacenes);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpGet]
        [Route("/api/almacenes")]
        public async Task<IActionResult> FicApiGetListAlmacenes()
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.ce_cat_almacenes select data_inv).ToList();
            if (zt_inventarios.Count() > 0)
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPost]
        [Route("/api/almacenes")]
        public async Task<IActionResult> FicApiSetAlmacen([FromForm]ce_cat_almacenes almacen)
        {
            ce_cat_almacenes insertar = almacen;
            FicLoDBContext.ce_cat_almacenes.Add(insertar);
            FicLoDBContext.SaveChanges();
            return Ok(insertar);
        }
        [HttpDelete]
        [Route("/api/almacenes")]
        public async Task<IActionResult> FicApiDeleteAlmacen([FromQuery] string id)
        {
            ce_cat_almacenes almacen = new ce_cat_almacenes();
            almacen.IdAlmacen = id;
            try
            {
                FicLoDBContext.ce_cat_almacenes.Remove(almacen);
                FicLoDBContext.SaveChanges();
                return Ok(almacen);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/almacenes")]
        public async Task<IActionResult> FicApiUpdateAlmacen([FromForm] ce_cat_almacenes almacen)
        {
            try
            {
                var actualizar = FicLoDBContext.ce_cat_almacenes.First(a => a.IdAlmacen == almacen.IdAlmacen);
                actualizar.Capacidad = almacen.Capacidad;
                actualizar.DesAlmacen = almacen.DesAlmacen;
                actualizar.FechaUltMod = almacen.FechaUltMod;
                actualizar.UsuarioMod = almacen.UsuarioMod;
                actualizar.Borrado = almacen.Borrado;
                actualizar.Activo = almacen.Activo;
                FicLoDBContext.SaveChanges();
                return Ok(actualizar);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }

        }
    }
}
