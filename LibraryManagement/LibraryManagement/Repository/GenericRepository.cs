using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LibraryManagement.Models.Entity;

namespace LibraryManagement.Repository
{
    public class GenericRepository<T> where T: class , new()
    {
        LibraryDBEntities1 db = new LibraryDBEntities1();
        public List<T> List()
        {

            return db.Set<T>().ToList(); 

        }

        public void TAdd(T p)
        {

            db.Set<T>().Add(p);
            db.SaveChanges();

        }

        public void TDelete(T p)
        {

            db.Set<T>().Remove(p);
            db.SaveChanges();

        }

        public T Find(int id)
        {
            return db.Set<T>().Find(id);

        }

        public T IFind(Expression<Func<T,bool>> where) 
        {

            return db.Set<T>().FirstOrDefault(where);
        
        }

       public void TUpdate(T p)
        {
            db.SaveChanges();
        }
            

    }
}