using System;
using System.Collections.Generic;
using MISA.CukCuk.Core.AttributesCustom;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interface.Repository;
using MISA.CukCuk.Core.Interface.Services;

namespace MISA.CukCuk.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {

        IBaseRepository<MISAEntity> _baseRepository;

        protected List<Object> _listValidate;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _listValidate = new List<Object>();
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

        
        private void ValidatePostData(MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();

            foreach(var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotNull), true);

                if(requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        _listValidate.Add(new {devMsg = (requiredProperties[0] as MISARequiredNotNull).Msg });
                    }
                }

                requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotDuplicate), true);

                if(requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (_baseRepository.CheckPostAttributeDuplicate(property.Name,propertyValue.ToString()))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotDuplicate).Msg });
                    }
                }

                
            }

            CustomPostValidate(entity);

            if(_listValidate.Count > 0)
            {
                throw new CustomerException(_listValidate.ToArray());
            }
        }

        protected virtual void CustomPostValidate(MISAEntity entity)
        {

        }

        protected virtual void CustomPutValidate(MISAEntity entity, Guid entityId)
        {

        }


        private void ValidatePutData(MISAEntity entity, Guid entityId)
        {
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotNull), true);

                if (requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotNull).Msg });
                    }
                }

                requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotDuplicate), true);

                if (requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (_baseRepository.CheckPutAttributeDuplicate(entityId, property.Name, propertyValue.ToString()))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotDuplicate).Msg });
                    }
                }

                
            }

            CustomPutValidate(entity, entityId);

            if (_listValidate.Count > 0)
            {
                throw new CustomerException(_listValidate.ToArray());
            }
        }
        public int Update(MISAEntity entity, Guid entityId)
        {

            ValidatePutData(entity, entityId);

            return _baseRepository.Update(entity);
        }
    }
}
