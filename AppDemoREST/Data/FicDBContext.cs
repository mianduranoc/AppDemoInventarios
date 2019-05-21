using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemoREST.Models;
using static AppDemoREST.Models.FicModInventarios;
using static AppDemoREST.Models.FicModAlmacenes;
using static AppDemoREST.Models.FicModGenerales;
using static AppDemoREST.Models.FicModEstatus;

namespace AppDemoREST.Data
{
    public class FicDBContext : DbContext
    {
        public FicDBContext(DbContextOptions<FicDBContext> options) : base(options)
        {

        }//constructor

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionsBuilder)
        {
            try
            {

            }
            catch (Exception e) { }
        }//config conection
        
        //
        public DbSet<ce_cat_conceptos_prod_serv> ce_cat_conceptos_prod_serv { get; set; }
        public DbSet<ce_cat_prod_serv_presenta> ce_cat_prod_serv_presenta { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<cat_estatus> cat_estatus { get; set; }
        public DbSet<cat_tipos_estatus> cat_tipos_estatus { get; set; }
        //Propias
        public DbSet<ce_cat_almacenes> ce_cat_almacenes { get; set; }
        public DbSet<ce_cat_inventarios> ce_cat_inventarios { get; set; }
        public DbSet<ce_inventarios_series> ce_inventarios_series { get; set; }
        public DbSet<ce_inventarios_series_estatus> ce_inventarios_series_estatus { get; set; }
        public DbSet<ce_inventarios_series_caracteristicas> ce_inventarios_series_caracteristicas { get; set; }
        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //      *** LLAVES PRIMARIAS ***     //
          
            //Almacenes
            modelBuilder.Entity<ce_cat_almacenes>().HasKey(c => new { c.IdAlmacen });
            //Inventarios
            modelBuilder.Entity<ce_cat_inventarios>().HasKey(c => new { c.IdProdServ, c.IdPresentacion, c.IdAlmacen });
            modelBuilder.Entity<ce_inventarios_series>().HasKey(c => new { c.NumSerie });
            modelBuilder.Entity<ce_inventarios_series_estatus>().HasKey(c => new { c.NumSerie, c.IdEstatusDet });
            modelBuilder.Entity<ce_inventarios_series_caracteristicas>().HasKey(c => new { c.IdCaracteristica, c.NumSerie });

            //Otros modelos
            modelBuilder.Entity<ce_cat_conceptos_prod_serv>().HasKey(c => new { c.IdProdServ });
            modelBuilder.Entity<ce_cat_prod_serv_presenta>().HasKey(c => new { c.IdProdServ,c.IdPresentacion });
            modelBuilder.Entity<cat_tipos_generales>().HasKey(c => new { c.IdTipoGeneral });
            modelBuilder.Entity<cat_generales>().HasKey(c => new { c.IdGeneral });
            modelBuilder.Entity<cat_tipos_estatus>().HasKey(c => new { c.IdTipoEstatus });
            modelBuilder.Entity<cat_estatus>().HasKey(c => new { c.IdEstatus });

            //    ***  LLAVES FORANEAS  ***    //
            //INVENTARIOS
            
            //-------------------------------------------------------
           
            //Inventarios
            modelBuilder.Entity<ce_cat_inventarios>().HasOne(
                b => b.ce_cat_prod_serv_presenta).WithMany().HasForeignKey(
                d => new { d.IdProdServ,d.IdPresentacion });
            /*modelBuilder.Entity<ce_cat_inventarios>().HasOne(
                b => b.ce_cat_prod_serv_presenta).WithMany().HasForeignKey(
                d => new { d.IdProdServ });*/
            modelBuilder.Entity<ce_cat_inventarios>().HasOne(
                b => b.ce_cat_almacenes).WithMany().HasForeignKey(
                d => new { d.IdAlmacen });
            modelBuilder.Entity<ce_inventarios_series>().HasOne(
                b => b.cat_generales).WithMany().HasForeignKey(
                d => new { d.IdTipoCondicion });
            modelBuilder.Entity<ce_inventarios_series>().HasOne(
                b => b.ce_cat_inventarios).WithMany().HasForeignKey(
                d => new { d.IdProdServ, d.IdPresentacion, d.IdAlmacen });
            /*modelBuilder.Entity<ce_inventarios_series>().HasOne(
                b => b.ce_cat_prod_serv_presenta).WithMany().HasForeignKey(
                d => new { d.IdPresentacion,d.IdProdServ });
            modelBuilder.Entity<ce_inventarios_series>().HasOne(
                b => b.ce_cat_prod_serv_presenta).WithMany().HasForeignKey(
                d => new { d.IdProdServ });*/
            modelBuilder.Entity<ce_inventarios_series_estatus>().HasOne(
                b => b.ce_inventarios_series).WithMany().HasForeignKey(
                d => new { d.NumSerie });
            modelBuilder.Entity<ce_inventarios_series_estatus>().HasOne(
                b => b.cat_estatus).WithMany().HasForeignKey(
                d => new { d.IdEstatus });
            modelBuilder.Entity<ce_inventarios_series_caracteristicas>().HasOne(
                b => b.ce_inventarios_series).WithMany().HasForeignKey(
                d => new { d.NumSerie });
            //Generales
            modelBuilder.Entity<cat_generales>().HasOne(
                b => b.cat_tipos_generales).WithMany().HasForeignKey(
                d => new { d.IdTipoGeneral });
            //Estatus
            modelBuilder.Entity<cat_estatus>().HasOne(
                b => b.cat_tipos_estatus).WithMany().HasForeignKey(
                d => new { d.IdTipoEstatus });
            //Otros
            modelBuilder.Entity<ce_cat_prod_serv_presenta>().HasOne(
                b => b.ce_cat_conceptos_prod_serv).WithMany().HasForeignKey(
                d => new { d.IdProdServ });
        }
    }
}

