using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using banxemayAPI.Models;

namespace banxemay.Controllers
{
    public class hangxeController : ApiController
    {
        public List<hangxe> Get()
        {
            using (banxemayEntities db = new banxemayEntities())
            {
                return db.hangxes.ToList();
            }
        }

        // GET api/values/5
        public hangxe Get(string id)
        {
            using (banxemayEntities db = new banxemayEntities())
            {
                hangxe s = db.hangxes.SingleOrDefault(x => x.mahang == id);
                if (s != null)
                    return s;
                else
                    return null;
            }
        }
        [HttpGet]
        public List<hangxe> timkiem(string namesearch)
        {
            using (banxemayEntities db = new banxemayEntities())
            {
                var s = db.hangxes.Where(x => x.tenhang.ToLower().Contains(namesearch.ToLower())).ToList();
                return s;
            }

        }
        // POST api/values
        public void Post([FromBody] hangxe value)
        {
            using (banxemayEntities db = new banxemayEntities())
            {
                db.hangxes.Add(value);
                db.SaveChanges();
            }
        }

        // PUT: api/hangxe/5
        public void Put(string id, [FromBody] hangxe value)
        {
            using (banxemayEntities db = new banxemayEntities())
            {
                var s = db.hangxes.SingleOrDefault(x => x.mahang == id);
                if (s != null)
                {
                    s.tenhang = value.tenhang;
                    s.mota = value.mota;
                    db.SaveChanges();
                }
            }
        }

        // DELETE: api/hangxe/5
        public void Delete(string id)
        {
            using (banxemayEntities db = new banxemayEntities())
            {
                hangxe s = db.hangxes.SingleOrDefault(x => x.mahang == id);
                db.hangxes.Remove(s);
                db.SaveChanges();
            }
        }
    }
}
