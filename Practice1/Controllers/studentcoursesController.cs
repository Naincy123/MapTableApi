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
    public class studentcoursesController : ApiController
    {
        private TempEntities2 db = new TempEntities2();

        // GET: api/studentcourses
        [HttpGet]
        public IHttpActionResult Getstudentcourses()
        {
            var response = (from ep in db.students
                            join e in db.studentcourses on ep.StudentId equals e.StudentId
                            join t in db.courses on e.CourseId equals t.CourseId
                            select new
                            {
                                Id = e.Id,
                                StudentId=ep.StudentId,
                                StudentName = ep.StudentName,
                                CourseId=t.CourseId,
                                CourseName = t.CourseName

                            }).ToList();

            return Ok(response);
        }

        // GET: api/studentcourses/5
        [HttpGet]
        public IHttpActionResult Getstudentcourse(int id)
        {
            var response = (from ep in db.students
                            join e in db.studentcourses on ep.StudentId equals e.StudentId
                            join t in db.courses on e.CourseId equals t.CourseId
                            where e.StudentId == id
                            select new
                            {
                                Id = e.Id,
                                StudentId=ep.StudentId,
                                StudentName = ep.StudentName,
                                CourseId=t.CourseId,
                                CourseName = t.CourseName
                            }).ToList();
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // PUT: api/studentcourses/5
        [HttpPut]
        public IHttpActionResult Putstudentcourse(int id, studentcourse studentcourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentcourse.Id)
            {
                return BadRequest();
            }

            db.Entry(studentcourse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentcourseExists(id))
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
        public IHttpActionResult Poststudentcourse(studentcourse studentcourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.studentcourses.Add(studentcourse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (studentcourseExists(studentcourse.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studentcourse.Id }, studentcourse);
        }

        // DELETE: api/studentcourses/5
        [HttpDelete]
        public IHttpActionResult Deletestudentcourse(int id)
        {
            studentcourse studentcourse = db.studentcourses.Find(id);
            if (studentcourse == null)
            {
                return NotFound();
            }

            db.studentcourses.Remove(studentcourse);
            db.SaveChanges();

            return Ok(studentcourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool studentcourseExists(int id)
        {
            return db.studentcourses.Count(e => e.Id == id) > 0;
        }
    }
}