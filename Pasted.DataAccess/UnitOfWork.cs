using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasted.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private bool _isDisposed;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
