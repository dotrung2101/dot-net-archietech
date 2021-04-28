using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.Interface.Repository;
using MISA.CukCuk.Core.Interface.Services;

namespace MISA.CukCuk.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {

        IBaseRepository<MISAEntity> _baseRepository;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public int Delete(Guid id)
        {
            return _baseRepository.Delete(id);
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public MISAEntity GetByID(Guid id)
        {
            return _baseRepository.GetByID(id);
        }

        public int Insert(MISAEntity entity)
        {
            //Validate data
            ValidatePostData(entity);

            return _baseRepository.Insert(entity);
        }
        protected virtual void ValidatePostData(MISAEntity entity)
        {

        }
        protected virtual void ValidatePutData(MISAEntity entity)
        {

        }
        public int Update(MISAEntity entity)
        {

            ValidatePutData(entity);

            return _baseRepository.Update(entity);
        }
    }
}
