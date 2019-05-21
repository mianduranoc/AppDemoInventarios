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
    public class FicApiInventarioSeriesController : Controller
    {
        private readonly FicDBContext FicLoDBContext;
        public FicApiInventarioSeriesController(FicDBContext FicPaBDContext)
        {
            FicLoDBContext = FicPaBDContext;
        }
        [HttpGet]
        [Route("/api/inventarios/series/num")]
        public async Task<IActionResult> FicApiGetSerie([FromQuery]string numserie)
        {

            var ce_cat_inventarios_series = (from data_inv in FicLoDBContext.ce_inventarios_series where data_inv.NumSerie == numserie select data_inv).ToList();
            if (ce_cat_inventarios_series.Count() > 0)
            {
                ce_cat_inventarios_series = ce_cat_inventarios_series.ToList();
                return Ok(ce_cat_inventarios_series);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpGet]
        [Route("/api/inventarios/series")]
        public async Task<IActionResult> FicApiGetListInventariosSeries()
        {
            var ce_inventarios_series = (from data_inv in FicLoDBContext.ce_inventarios_series select data_inv).ToList();
            if (ce_inventarios_series.Count() > 0)
            {
                ce_inventarios_series = ce_inventarios_series.ToList();
                return Ok(ce_inventarios_series);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPost]
        [Route("/api/inventarios/series")]
        public async Task<IActionResult> FicApiSetInventarioSerie([FromForm]ce_inventarios_series serie)
        {
            ce_inventarios_series insertar = serie;
            FicLoDBContext.ce_inventarios_series.Add(insertar);
            FicLoDBContext.SaveChanges();
            return Ok(insertar);
        }
        [HttpDelete]
        [Route("/api/inventarios/series")]
        public async Task<IActionResult> FicApiDeleteInventarioSerie([FromQuery] string numSerie)
        {
            ce_inventarios_series serie = new ce_inventarios_series();
            serie.NumSerie = numSerie;
            try
            {
                FicLoDBContext.ce_inventarios_series.Remove(serie);
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
        [Route("/api/inventarios/series")]
        public async Task<IActionResult> FicApiUpdateInventarioSerie([FromForm] ce_inventarios_series serie)
        {
            try
            {
                var actualizar = FicLoDBContext.ce_inventarios_series.First(a => a.NumSerie == serie.NumSerie);
                actualizar.Activo = serie.Activo;
                actualizar.Borrado = serie.Borrado;
                actualizar.FechaUltMod = serie.FechaUltMod;
                actualizar.IdTipoCondicion = serie.IdTipoCondicion;
                actualizar.Referencia = serie.Referencia;
                actualizar.UbicacionDet = serie.UbicacionDet;
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