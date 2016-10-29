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

namespace AngularJSEFWebApi.Controllers
{
    public class ContactApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public int AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return contact.Id;
        }

        [HttpGet]
        public Contact GetContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }

        [HttpGet]
        public List<Contact> GetContactList()
        {
            return db.Contacts.ToList();
        }

        [HttpPut]
        public void ModifyContact(Contact contact, int id)
        {
            if (contact.Id == id)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (User != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }

        //// GET: api/ContactApi
        //public IQueryable<Contact> GetContacts()
        //{
        //    return db.Contacts;
        //}

        //// GET: api/ContactApi/5
        //[ResponseType(typeof(Contact))]
        //public IHttpActionResult GetContact(int id)
        //{
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(contact);
        //}

        //// PUT: api/ContactApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutContact(int id, Contact contact)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != contact.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(contact).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContactExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/ContactApi
        //[ResponseType(typeof(Contact))]
        //public IHttpActionResult PostContact(Contact contact)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Contacts.Add(contact);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);
        //}

        //// DELETE: api/ContactApi/5
        //[ResponseType(typeof(Contact))]
        //public IHttpActionResult DeleteContact(int id)
        //{
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Contacts.Remove(contact);
        //    db.SaveChanges();

        //    return Ok(contact);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }
    }
}