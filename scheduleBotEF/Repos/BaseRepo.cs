using scheduleDbLayer.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Repos
{
    class BaseRepo<T> : IDisposable, IRepo<T> where T: class
    {
        private readonly DbSet<T> _table;
        private readonly ScheduleEntities _db;

        public BaseRepo()
        {
            _db = new ScheduleEntities();
            _table = _db.Set<T>();
        }

        protected ScheduleEntities Context => _db;

        public void Dispose()
        {
            _db?.Dispose();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => _table.SqlQuery(sql, sqlParametersObjects).ToList();

        public virtual List<T> GetAll() => _table.ToList();

        public T GetOne(int? d) => _table.Find(d);

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) { throw; }

            catch (DbUpdateException ex) { throw; }

            catch (CommitFailedException ex) { throw; }

            catch (Exception ex) { throw; }

        }
    }
}
