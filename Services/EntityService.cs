using HaritaUygulamasi.Data;
using HaritaUygulamasi.Interfaces;
using HaritaUygulamasi.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace HaritaUygulamasi.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response GetAll()
        {
            var result = new Response();
            try
            {
                var entities = _unitOfWork.GetRepository<T>().GetAll();
                if (!entities.Any())
                {
                    result.Message = "There is no coordinate in the database";
                    return result;
                }
                result.Data = entities;
                result.IsSuccess = true;
                result.Message = "Coordinates are listed succesfully";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }

        public Response GetById(int id)
        {
            var result = new Response();
            try
            {
                var entity = _unitOfWork.GetRepository<T>().GetById(id);
                if (entity == null)
                {
                    result.Message = "Coordinate not found";
                    return result;
                }
                result.Data = entity;
                result.IsSuccess = true;
                result.Message = "Coordinate listed succesfully";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }

        public Response Add(T entity)
        {
            var result = new Response();
            try
            {
                _unitOfWork.GetRepository<T>().Add(entity);
                _unitOfWork.Complete();
                result.IsSuccess = true;
                result.Data = entity;
                result.Message = "Coordinate added succesfully";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }

        public Response Update(T entity)
        {
            var result = new Response();
            try
            {
                _unitOfWork.GetRepository<T>().Update(entity);
                _unitOfWork.Complete();
                result.IsSuccess = true;
                result.Data = entity;
                result.Message = "Coordinate updated succesfully";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }

        public Response Delete(int id)
        {
            var result = new Response();
            try
            {
                _unitOfWork.GetRepository<T>().Delete(id);
                _unitOfWork.Complete();
                result.IsSuccess = true;
                result.Message = "Coordinate deleted succesfully";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }

    }
}
