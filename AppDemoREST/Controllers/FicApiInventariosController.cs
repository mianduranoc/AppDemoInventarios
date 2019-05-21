using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDemoREST.Data;
using static AppDemoREST.Models.FicModInventarios;

namespace AppDemoREST.Controllers
{
    [Produces("application/json")]
    public class FicApiInventariosController : Controller
    {
        private readonly FicDBContext FicLoDBContext;
        public FicApiInventariosController(FicDBContext FicPaBDContext)
        {
            FicLoDBContext = FicPaBDContext;
        }
        [HttpGet]
        [Route("/api/inventarios/id")]
        public async Task<IActionResult> FicApiGetListInventarios([FromQuery]int producto)
        {

            var ce_cat_inventarios = (from data_inv in FicLoDBContext.ce_cat_inventarios where data_inv.IdProdServ == producto select data_inv).ToList();
            if (ce_cat_inventarios.Count() > 0)
            {
                ce_cat_inventarios = ce_cat_inventarios.ToList();
                return Ok(ce_cat_inventarios);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpGet]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiGetListInventarios()
        {
            var ce_cat_inventarios = (from data_inv in FicLoDBContext.ce_cat_inventarios select data_inv).ToList();
            if (ce_cat_inventarios.Count() > 0)
            {
                ce_cat_inventarios = ce_cat_inventarios.ToList();
                return Ok(ce_cat_inventarios);
            }
            else
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPost]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiSetInventario([FromForm]ce_cat_inventarios inventario)
        {
            ce_cat_inventarios insertar = inventario;
            FicLoDBContext.ce_cat_inventarios.Add(insertar);
            FicLoDBContext.SaveChanges();
            return Ok(insertar);
        }
        [HttpDelete]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiDeleteInventario([FromQuery] short producto, [FromQuery] string presentacion)
        {
            ce_cat_inventarios inventario = new ce_cat_inventarios();
            inventario.IdProdServ = producto;
            inventario.IdPresentacion = presentacion;
            try
            {
                FicLoDBContext.ce_cat_inventarios.Remove(inventario);
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiUpdateAlmacen([FromForm] ce_cat_inventarios inventario)
        {
            try
            {
                var actualizar = FicLoDBContext.ce_cat_inventarios.First(a => a.IdProdServ == inventario.IdProdServ && a.IdPresentacion==inventario.IdPresentacion);
                actualizar.Activo = inventario.Activo;
                actualizar.Borrado = inventario.Borrado;
                actualizar.CantidadApartada = inventario.CantidadApartada;
                actualizar.CantidadDisponible = inventario.CantidadDisponible;
                actualizar.CantidadMerma = inventario.CantidadMerma;
                actualizar.FechaUltMod = inventario.FechaUltMod;
                actualizar.IdAlmacen = inventario.IdAlmacen;
                actualizar.StockMaximo = inventario.StockMaximo;
                actualizar.StockMinimo = inventario.StockMinimo;
                actualizar.Ubicacion = inventario.Ubicacion;
                actualizar.UsuarioMod = inventario.UsuarioMod;                
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
        //consulta completa, consulta por id cedi, insert inventario, modificacion inventario, eliminar inventario
        /*[HttpGet]
        [Route("/api/inventarios/invacucon")]
        public async Task<IActionResult>FicApiGetListInventarios([FromQuery]int cedi)
        {

            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios where data_inv.IdCEDI == cedi select data_inv).ToList();
            if (zt_inventarios.Count()>0)
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
            else
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
        }
        [HttpGet]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiGetListInventarios()
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios select data_inv).ToList();
            if (zt_inventarios.Count() > 0)
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
            else
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
        }
        [HttpPost]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiSetInventario([FromForm] int id, [FromForm]short cedi, [FromForm]string sap, [FromForm] DateTime fecha, [FromForm] string user)
        {
            Console.WriteLine(id);
            zt_inventarios inventario = new zt_inventarios();
            inventario.IdInventario = id;
            inventario.IdCEDI = cedi;
            inventario.IdInventarioSAP = sap;
            inventario.FechaReg = fecha;
            inventario.UsuarioReg = user;
            inventario.Activo = "S";
            inventario.Borrado = "N";
            FicLoDBContext.zt_inventarios.Add(inventario);
            FicLoDBContext.SaveChanges();
            return Ok(inventario);
            
        }
        [HttpDelete]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiDeleteInventario([FromQuery] int id)
        {
            zt_inventarios inventario = new zt_inventarios();
            inventario.IdInventario = id;
            try
            {
                FicLoDBContext.zt_inventarios.Remove(inventario);
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err","No se encontraron registros");
                return Ok(err);
            }  
        }
        [HttpPut]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiUpdateInventario([FromForm] int id, [FromForm]string sap, [FromForm] DateTime fecha, [FromForm] string user, [FromForm] string activo, [FromForm] string borrado)
        {
            try
            {
                var inventario = FicLoDBContext.zt_inventarios.First(a => a.IdInventario == id);
                inventario.IdInventario = id;
                inventario.IdInventarioSAP = sap;
                inventario.FechaUltMod = fecha;
                inventario.UsuarioMod = user;
                inventario.Activo = activo;
                inventario.Borrado = borrado;
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch(Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
            
        }*/
        // GET: api/FicApiInventarios
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FicApiInventarios/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FicApiInventarios
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FicApiInventarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
