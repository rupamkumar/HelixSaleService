﻿using HelixSaleService.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTest.Models;

namespace HelixSaleService.Controllers
{
    [ServiceAuthenticationFilter]
    public class SalesController : ApiController
    {
        private SaleServiceContext db = new SaleServiceContext();

        // GET: api/Sales
        [ServiceAuthorizationFilter]
        public IQueryable<Sale> GetSales()
        {
            return db.Sales;
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> GetSale(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSale(int id, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.ID)
            {
                return BadRequest();
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sales
        [ServiceAuthorizationFilter]
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> PostSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sales.Add(sale);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sale.ID }, sale);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public async Task<IHttpActionResult> DeleteSale(int id)
        {
            Sale sale = await db.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sale);
            await db.SaveChangesAsync();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sales.Count(e => e.ID == id) > 0;
        }
    }
}