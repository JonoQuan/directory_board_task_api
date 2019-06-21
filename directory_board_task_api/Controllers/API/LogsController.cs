using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using directory_board_task_api.Models;

namespace directory_board_task_api.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LogsController : ApiController
    {
        private DirectoryBoardContext db = new DirectoryBoardContext();

        // GET: api/Logs
        public IQueryable<Log> GetLogs()
        {
            return db.Logs;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogExists(int id)
        {
            return db.Logs.Count(e => e.Id == id) > 0;
        }
    }
}