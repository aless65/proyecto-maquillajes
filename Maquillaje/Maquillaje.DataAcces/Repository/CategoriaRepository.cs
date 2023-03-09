using Maquillaje.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Maquillaje.DataAccess.Repository
{
    public class CategoriaRepository : IRepository<tbCategorias>
    {
        public int Delete(tbCategorias item)
        {
            throw new NotImplementedException();
        }

        public tbCategorias find(int? id)
        {
            using var db = new AndreasContext();
            var listado = db.tbCategorias.Find(id);
            return listado;
        }

        public int Insert(tbCategorias item)
        {
            using var db = new AndreasContext();
            db.tbCategorias.Add(item);
            return item.cate_Id;
        }

        public IEnumerable<tbCategorias> List()
        {
            using var db = new AndreasContext();
            return db.tbCategorias.ToList();
        }

        public int Update(tbCategorias item)
        {
            using var db = new AndreasContext();
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item.cate_Id;
        }
    }
}
