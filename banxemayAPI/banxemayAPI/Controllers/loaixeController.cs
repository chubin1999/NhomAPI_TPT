using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using banxemayAPI.Models;

namespace banxemayAPI.Controllers
{
    public class loaixecontroller : ApiController
    {
        public banxemayEntities db = new banxemayEntities();
        // GET: api/Loaixe
        public List<loaixe> Get()
        {
            return db.loaixes.ToList();
        }

        // GET: api/Loaixe/5
        public loaixe Get(string id)
        {
            loaixe s = db.loaixes.SingleOrDefault(x => x.maloai == id);
            return s;
        }

        // POST: api/Loaixe
        public List<loaixe> Post([FromBody] loaixe value)
        {
            var s = db.loaixes.SingleOrDefault(x => x.maloai == value.maloai);
            if (s == null)
            {
                db.loaixes.Add(value);
                db.SaveChanges();
            }
            return db.loaixes.ToList();
        }

        // PUT: api/Loaixe/5
        public List<loaixe> Put(string id, [FromBody] loaixe loaixe)
        {
            var s = db.loaixes.SingleOrDefault(x => x.maloai == id);
            if (s != null)
            {
                s.tenloai = loaixe.tenloai;
                s.mota = loaixe.mota;
                db.SaveChanges();
            }
            return db.loaixes.ToList();
        }

        // DELETE: api/Loaixe/5
        public List<loaixe> Delete(string id)
        {
            loaixe s = db.loaixes.SingleOrDefault(x => x.maloai == id);
            db.loaixes.Remove(s);
            db.SaveChanges();
            return db.loaixes.ToList();
        }
        [HttpGet]
        public List<loaixe> gettimkiem(string name)
        {
            var s = db.loaixes.Where(x => x.tenloai.ToLower().Contains(name.ToLower())).ToList();
            return s;
        }
    }
}
