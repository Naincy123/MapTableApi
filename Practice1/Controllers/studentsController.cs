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
using Practice1.Models;
using Practice1.DataContracts;

namespace Practice1.Controllers
{
    public class studentsController : ApiController
    {
        private TempEntities2 db = new TempEntities2();

        // GET: api/students
        [HttpGet]
   
        public IHttpActionResult Get()
        {
          
            var response = db.students.Select(e => new StudentContract() { StudentId = e.StudentId, StudentName = e.StudentName }).ToList();
            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var response = db.students.Where(e=>e.StudentId==id).Select(e => new StudentContract() { StudentId = e.StudentId, StudentName = e.StudentName }).ToList();
            //student student = db.students.Find(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut]
        public IHttpActionResult Putstudent(int id, student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentExists(id))
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

        [HttpPost]
        public IHttpActionResult Poststudent(student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.students.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (studentExists(student.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // DELETE: api/students/5
        [HttpDelete]
        public IHttpActionResult Deletestudent(int id)
        {
            student student = db.students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool studentExists(int id)
        {
            return db.students.Count(e => e.StudentId == id) > 0;
        }
    }
}