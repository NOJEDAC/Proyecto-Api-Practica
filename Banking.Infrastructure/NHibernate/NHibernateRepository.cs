using System;
using Common;

namespace Banking.Infrastructure.NHibernate
{
    public class NHibernateRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UnitOfWorkNHibernate _unitOfWork;

        protected NHibernateRepository(UnitOfWorkNHibernate unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TEntity Get(int id)
        {
            TEntity entity;
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                entity = _unitOfWork.GetSession().Get<TEntity>(id);
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return entity;
        }

        public TEntity Get(long id)
        {
            TEntity entity;
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                entity = _unitOfWork.GetSession().Get<TEntity>(id);
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return entity;
        }

        public void SaveOrUpdate(TEntity entity)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                _unitOfWork.GetSession().SaveOrUpdate(entity);
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
        }

        public void Delete(TEntity entity)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                _unitOfWork.GetSession().Delete(entity);
                _unitOfWork.Commit(uowStatus);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
        }
    }
}
