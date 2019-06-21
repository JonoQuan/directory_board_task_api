using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using directory_board_task_api.Models;


namespace directory_board_task_api.Controllers.API
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DirectoriesController : ApiController
    {
        private DirectoryBoardContext db = new DirectoryBoardContext();

        // GET: api/Directories
        public IQueryable<Directory> GetDirectories()
        {
            return db.Directories;
        }

        // PUT: api/Directories/
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDirectory(Directory directory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var old = LoadDirectoryItem(directory.Id);
            db.Entry(directory).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryExists(directory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            LogUpdate(old, directory);
            return Ok(directory);
        }

        // POST: api/Directories
        [ResponseType(typeof(Directory))]
        public IHttpActionResult PostDirectory(Directory directory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Directories.Add(directory);
            db.SaveChanges();
            LogUpdate(null, directory);
            return CreatedAtRoute("DefaultApi", new { id = directory.Id }, directory);
        }

        // DELETE: api/Directories/5
        [ResponseType(typeof(Directory))]
        public IHttpActionResult DeleteDirectory(int id)
        {
            Directory directory = db.Directories.Find(id);
            if (directory == null)
            {
                return NotFound();
            }
            db.Directories.Remove(directory);
            db.SaveChanges();
            LogDelete(directory);
            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectoryExists(int id)
        {
            return db.Directories.Count(e => e.Id == id) > 0;
        }
        private void LogDelete(Directory directory)
        {
            var log = new Log()
            {
                DirectoryId = 0,
                Date = DateTime.Now,
                From = directory.Company,
                To = "- DELETED -",
                Field = "Company"
            };
            db.Logs.Add(log);
            db.SaveChanges();
        }
        private Directory LoadDirectoryItem(int id)
        {
            var row = (from c in db.Directories
                       where c.Id == id
                       select c).AsNoTracking().FirstOrDefault();
            return row;
        }
        private void LogUpdate(Directory dir, Directory newDir)
        {
          //get values from appending record

            var id = newDir.Id;
            var newCompany = newDir.Company;
            var newLevel = newDir.Level;
            var newSuite = newDir.Suite; 

            var company = dir == null ? "" : dir.Company;
            var level = dir == null ? "" : dir.Level;
            var suite = dir == null ? "" : dir.Suite;

            // compare current values to appending values. If true, properties added to log.

            if (!(company == newCompany))
            {
                var log = new Log() {
                    DirectoryId = id,
                    Date = DateTime.Now,
                    From = company,
                    To = newCompany,
                    Field = "Company"
                };
                db.Logs.Add(log);
                db.SaveChanges();
            }
            if (!(level == newLevel))
            {
                var log = new Log()
                {
                    DirectoryId = id,
                    Date = DateTime.Now,
                    From = level,
                    To = newLevel,
                    Field = "Level"
                };
                db.Logs.Add(log);
                db.SaveChanges();
            }
            if (!(suite == newSuite))
            {
                var log = new Log()
                {
                    DirectoryId = id,
                    Date = DateTime.Now,
                    From = suite,
                    To = newSuite,
                    Field = "Suite"
                };
                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}