using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.EF;
using System.Linq;

namespace DAL.Repositories
{
    class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private KnowledgeTestingSystemDbContext database;
        private DbSet<Entity> dbSet;

        public Repository(KnowledgeTestingSystemDbContext db)
        {
            database = db;
            /*var s = database.Tests.AsEnumerable();
            foreach(var d in s)
            {
                var x = d;
            }*/
            dbSet = database.Set<Entity>();
        }

        public void Create(Entity newRow)
        {
            dbSet.Add(newRow);
        }

        public void Delete(int id)
        {
            Entity entityForDelete = dbSet.Find(id);
            if(entityForDelete != null)
            {
                dbSet.Remove(entityForDelete);
            }
        }

        public IEnumerable<Entity> Find(Func<Entity, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public IEnumerable<Entity> GetAll()
        {
            return dbSet.ToList();
        }

        public Entity GetById(int id)
        {
            Entity entity = dbSet.Find(id);
            if(entity != null)
            {
                return entity;
            }
            else
            {
                throw new NullReferenceException("Entity with given id doesn't exist");
            }
        }

        public void Update(Entity updateRow)
        {
            database.Entry(updateRow).State = EntityState.Modified;
        }
    }
}
