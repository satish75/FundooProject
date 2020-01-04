// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BussinessLabel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// --------------------------------------------------------------------------------------------------
namespace BussinessLayer.Services
{
    using BussinessLayer.Interface;
    using Common.Models;
    using RepositoryLayer.Interface;
    using ServiceStack.Redis;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public class BussinessLabel : IBussinessLabel
    {
        private readonly IRepositoryLabel _repository;

        /// <summary>
        /// This is Constructor
        /// </summary>
        /// <param name="repository"></param>
        public BussinessLabel(IRepositoryLabel repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds the specified label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Empty</exception>
        public async Task<bool> Add(IList<string> label, int noteId, string userId)
        {
            try
            {
                if (label != null)
                {
                    return await _repository.Add(label, noteId, userId);
                }
                else
                {
                    throw new Exception("Empty");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Task<LabelModel> AddLabel(string label, string UserId)
        {
            try
            {
                if (label != null)
                {
                    return  _repository.AddLabel(label, UserId);
                }
                else
                {
                    throw new Exception("Empty");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<string> DeleteLabel(int id)
        {

            try
            {
                if (id > 0)
                {
                    return _repository.DeleteLabel(id);
                }
                else
                {
                    throw new Exception("Label Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Label Not Found</exception>
        public IList<LabelModel> GetLabel(string id)
        {
            try
            {
                if (id != null)
                {
                    return _repository.GetLabel(id);
                }
                else
                {
                    throw new Exception("Label Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateLabel(int Idlbl,string model)
        {
            try
            {
                var result = await this._repository.UpdateLabel(Idlbl,model);

                ////key to store value in redis
                var cacheKey = "data" + model;
                using (var redis = new RedisClient())
                {


                    ////removing the cache from redis
                    redis.Remove(cacheKey);

                    ////condtion to check if there are record or not in redis
                    if (redis.Get(cacheKey) == null)
                    {
                        if (result == true)
                        {
                            ////sets the data to the redis
                            redis.Set(cacheKey, result);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
