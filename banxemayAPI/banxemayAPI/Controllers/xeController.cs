using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using banxemayAPI.Models;

namespace banxemay.Controllers
{
    public class xeController : ApiController
    {
        public banxemayEntities db = new banxemayEntities();
        // GET: api/xe
        public IEnumerable<xe> Get()
        {
            return db.xes.ToList();
        }

        // GET: api/xe/5
        public xe Get(string id)
        {
            xe s = db.xes.SingleOrDefault(x => x.maxe == id);
            if (s != null)
                return s;
            else
                return null;
        }
        //lay xe theo loai
        [HttpGet]
        public List<xe> getXeTheoLoai(string id)
        {
            var s = db.xes.Where(x => x.maloai == id).ToList();
            return s;
        }
        //lay xe theo hang xe
        [HttpGet]
        public List<xe> getXeTheoHangxe(string id)
        {
            var s = db.xes.Where(x => x.mahang == id).ToList();
            return s;
        }
        [HttpGet]
        public List<xe> timkiem(string namesearch)
        {
            var s = db.xes.Where(x => x.tenxe.ToLower().Contains(namesearch.ToLower())).ToList();
            var y = db.xes.Where(x => x.tenxe.ToLower().Contains(namesearch.ToLower())).ToList();
            return s;
        }
        // POST: api/xe
        public List<xe> Post([FromBody] xe value)
        {
            var s = db.xes.SingleOrDefault(x => x.maxe == value.maxe);
            if (s == null)
            {
                db.xes.Add(value);
                db.SaveChanges();
            }
            return db.xes.ToList();
        }

        // PUT: api/xe/5
        public List<xe> Put(string id, [FromBody] xe value)
        {
            var s = db.xes.SingleOrDefault(x => x.maxe == id);
            if (s != null)
            {
                s.tenxe = value.tenxe;
                s.mahang = value.mahang;
                s.maloai = value.maloai;
                s.mausac = value.mausac;
                s.cannang = value.cannang;
                s.docaoyen = value.docaoyen;
                s.namsanxuat = value.namsanxuat;
                s.xuatxu = value.xuatxu;
                s.dungtichbinhxang = value.dungtichbinhxang;
                s.dungtichxilanh = value.dungtichxilanh;
                s.giaban = value.giaban;
                db.SaveChanges();
            }
            return db.xes.ToList();
        }

        // DELETE: api/xe/5
        public List<xe> Delete(string id)
        {
            var s = db.xes.SingleOrDefault(x => x.maxe == id);
            if (s != null)
            {
                db.xes.Remove(s);
                db.SaveChanges();
            }
            return db.xes.ToList();
        }
    }
}
