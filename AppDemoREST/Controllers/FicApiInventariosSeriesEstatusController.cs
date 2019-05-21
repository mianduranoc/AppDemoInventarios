using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppDemoREST.Data;
using static AppDemoREST.Models.FicModInventarios;

namespace AppDAMInventarios.Controllers
{
    [Produces("application/json")]
    public class FicApiInventariosSeriesEstatusController : Controller
    {
        private readonly FicDBContext FicLoDBContext;
        public FicApiInventariosSeriesEstatusController(FicDBContext FicPaBDContext)
        {
            FicLoDBContext = FicPaBDContext;
        }
        [HttpGet]
        [Route("/api/inventarios/series/estatus/num")]
        public async Task<IActionResult> FicApiGetSerieEstatus([FromQuery]string numserie,[FromQuery] int estatus)
        {

            var ce_inventarios_series_estatus = (from data_inv in FicLoDBContext.ce_inventarios_series_estatus where data_inv.NumSerie == numserie && data_inv.IdEstatusDet==estatus select data_inv).ToList();
            if (ce_inventarios_series_estatus.Count() > 0)
            {
                ce_inventarios_series_estatus = ce_inventarios_series_estatus.ToList();
                return Ok(ce_inventarios_series_estatus);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpGet]
        [Route("/api/inventarios/series/estatus")]
        public async Task<IActionResult> FicApiGetListInventariosSeriesEstatus()
        {
            var ce_inventarios_series_estatus = (from data_inv in FicLoDBContext.ce_inventarios_series_estatus select data_inv).ToList();
            if (ce_inventarios_series_estatus.Count() > 0)
            {
                ce_inventarios_series_estatus = ce_inventarios_series_estatus.ToList();
                return Ok(ce_inventarios_series_estatus);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPost]
        [Route("/api/inventarios/series/estatus")]
        public async Task<IActionResult> FicApiSetInventarioSerieEstatus([FromForm]ce_inventarios_series_estatus serie)
        {
            ce_inventarios_series_estatus insertar = serie;
            FicLoDBContext.ce_inventarios_series_estatus.Add(insertar);
            FicLoDBContext.SaveChanges();
            return Ok(insertar);
        }
        [HttpDelete]
        [Route("/api/inventarios/series/estatus")]
        public async Task<IActionResult> FicApiDeleteInventarioSerieEstatus([FromQuery]string numserie, [FromQuery] int estatus)
        {
            ce_inventarios_series_estatus serie = new ce_inventarios_series_estatus();
            serie.NumSerie = numserie;
            serie.IdEstatusDet = (short)estatus;
            try
            {
                FicLoDBContext.ce_inventarios_series_estatus.Remove(serie);
                FicLoDBContext.SaveChanges();
                return Ok(serie);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/inventarios/series/estatus")]
        public async Task<IActionResult> FicApiUpdateInventarioSerieEstatus([FromForm] ce_inventarios_series_estatus serie)
        {
            try
            {
                var actualizar = FicLoDBContext.ce_inventarios_series_estatus.First(a => a.NumSerie == serie.NumSerie && a.IdEstatusDet==serie.IdEstatusDet);
                actualizar.Activo = serie.Activo;
                actualizar.Borrado = serie.Borrado;
                actualizar.FechaUltMod = serie.FechaUltMod;
                actualizar.IdEstatus = serie.IdEstatus;
                actualizar.Observacion = serie.Observacion;
                actualizar.ReferenciaPedVta = serie.ReferenciaPedVta;
                actualizar.TipoPedidoVenta = serie.TipoPedidoVenta;
                actualizar.UsuarioMod = serie.UsuarioMod;
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