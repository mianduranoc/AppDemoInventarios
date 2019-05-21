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
    public class FicApiInventariosSeriesCaracController : Controller
    {
        private readonly FicDBContext FicLoDBContext;
        public FicApiInventariosSeriesCaracController(FicDBContext FicPaBDContext)
        {
            FicLoDBContext = FicPaBDContext;
        }
        [HttpGet]
        [Route("/api/inventarios/series/caracteristica/num")]
        public async Task<IActionResult> FicApiGetSerieCaracteristica([FromQuery]string numserie, [FromQuery] int caracteristica)
        {

            var ce_inventarios_series_caracteristicas = (from data_inv in FicLoDBContext.ce_inventarios_series_caracteristicas where data_inv.NumSerie == numserie && data_inv.IdCaracteristica == caracteristica select data_inv).ToList();
            if (ce_inventarios_series_caracteristicas.Count() > 0)
            {
                ce_inventarios_series_caracteristicas = ce_inventarios_series_caracteristicas.ToList();
                return Ok(ce_inventarios_series_caracteristicas);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpGet]
        [Route("/api/inventarios/series/caracteristica")]
        public async Task<IActionResult> FicApiGetListInventariosSeriesCaracteristica()
        {
            var ce_inventarios_series_caracteristicas = (from data_inv in FicLoDBContext.ce_inventarios_series_caracteristicas select data_inv).ToList();
            if (ce_inventarios_series_caracteristicas.Count() > 0)
            {
                ce_inventarios_series_caracteristicas = ce_inventarios_series_caracteristicas.ToList();
                return Ok(ce_inventarios_series_caracteristicas);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPost]
        [Route("/api/inventarios/series/caracteristica")]
        public async Task<IActionResult> FicApiSetInventarioSerieCaracteristica([FromForm]ce_inventarios_series_caracteristicas serie)
        {
            ce_inventarios_series_caracteristicas insertar = serie;
            FicLoDBContext.ce_inventarios_series_caracteristicas.Add(insertar);
            FicLoDBContext.SaveChanges();
            return Ok(insertar);
        }
        [HttpDelete]
        [Route("/api/inventarios/series/caracteristica")]
        public async Task<IActionResult> FicApiDeleteInventarioSerieCaracteristica([FromQuery]string numserie, [FromQuery] int caracteristica)
        {
            ce_inventarios_series_caracteristicas serie = new ce_inventarios_series_caracteristicas();
            serie.NumSerie = numserie;
            serie.IdCaracteristica = (short)caracteristica;
            try
            {
                FicLoDBContext.ce_inventarios_series_caracteristicas.Remove(serie);
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
        [Route("/api/inventarios/series/caracteristica")]
        public async Task<IActionResult> FicApiUpdateInventarioSerieCaracteristica([FromForm] ce_inventarios_series_caracteristicas serie)
        {
            try
            {
                var actualizar = FicLoDBContext.ce_inventarios_series_caracteristicas.First(a => a.NumSerie == serie.NumSerie && a.IdCaracteristica == serie.IdCaracteristica);
                actualizar.Activo = serie.Activo;
                actualizar.Borrado = serie.Borrado;
                actualizar.FechaUltMod = serie.FechaUltMod;
                actualizar.DesCaracteristica = serie.DesCaracteristica;
                actualizar.Valor = serie.Valor;                
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