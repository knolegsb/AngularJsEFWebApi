using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularJSEFWebApi.Models;
using Newtonsoft.Json;

namespace AngularJSEFWebApi.Controllers
{
    public class ProductApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProductApi
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/ProductApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/ProductApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/ProductApi
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/ProductApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }

        //[HttpGet]
        //public HttpResponseMessage findAll()
        //{
        //    var serializedData = JsonConvert.SerializeObject(db.Products.ToList());
        //    var response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = new StringContent(serializedData);
        //    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    return response;
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public HttpResponseMessage find(int id)
        //{
        //    var serializedData = JsonConvert.SerializeObject(db.Products.Find(id));
        //    var response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Content = new StringContent(serializedData);
        //    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    return response;
        //}

        //[HttpPost]
        //public void create(Product product)
        //{
        //    db.Products.Add(product);
        //    db.SaveChanges();
        //}

        //[HttpPut]
        //public void Update(Product product)
        //{
        //    db.Entry<Product>(product).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public void delete(int id)
        //{
        //    db.Products.Remove(db.Products.Find(id));
        //    db.SaveChanges();
        //}
    }
}