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
    public class coursesController : ApiController
    {
        private TempEntities2 db = new TempEntities2();

        // GET: api/courses
        [HttpGet]
        public IHttpActionResult Getcourses()
        {
            var response = db.courses.Select(e => new CourseContract() { CourseId = e.CourseId, CourseName = e.CourseName }).ToList();
            return Ok(response);
        }

        // GET: api/courses/5
        [HttpGet]
        public IHttpActionResult Getcourse(int id)
        {
            var response = db.courses.Where(e => e.CourseId == id).Select(e => new CourseContract() { CourseId = e.CourseId, CourseName = e.CourseName }).ToList();
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // PUT: api/courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcourse(int id, course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseId)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!courseExists(id))
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

        // POST: api/courses
        [ResponseType(typeof(course))]
        public IHttpActionResult Postcourse(course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.courses.Add(course);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (courseExists(course.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = course.CourseId }, course);
        }

        // DELETE: api/courses/5
        [ResponseType(typeof(course))]
        public IHttpActionResult Deletecourse(int id)
        {
            course course = db.courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.courses.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }
        
        private bool courseExists(int id)
        {
            return db.courses.Count(e => e.CourseId == id) > 0;
        }
    }
}