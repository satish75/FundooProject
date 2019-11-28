// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BussinessNotes.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
using BussinessLayer.Interface;
using Common.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Interface;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class BussinessNotes : IBussinessNotes
    {
        private readonly IRepositoryNotes _repository;

        /// <summary>
        /// This is Constructor
        /// </summary>
        /// <param name="repository"></param>
        public BussinessNotes(IRepositoryNotes repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates the notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        /// <exception cref="Exception">User is empty</exception>
        public async Task<bool> CreateNotes(NotesModel notes)
        {
            try
            {
                if (notes != null)
                {
                    return await _repository.CreateNotes(notes);
                }
                else
                {
                    throw new Exception("User is empty");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> DeleteNotes(List<int> id, string UserId)
        {
            try
            {
                if (id != null)
                {
                    return await _repository.DeleteNotes(id, UserId);
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Notes Not Found</exception>
        public IList<NotesModel> GetNotes(string id)
        {
            try
            {
                if (id != null)
                {
                    return _repository.GetNotes(id);
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }



        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateNotes(NotesModel model, int id)
        {

            try
            {
                var result = await this._repository.UpdateNotes(model, id);

                ////key to store value in redis
                var cacheKey = "data" + model.UserId;
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
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteForever(List<int> id, string UserId)
        {
            try
            {
                if (id != null)
                {
                    return await _repository.DeleteForever(id, UserId);
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }


        public async Task<bool> Trash(int id)
        {
            try
            {
                var result = await this._repository.Trash(id);
                if (id != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> TrashRestore(int id)
        {
            try
            {
                var result = await this._repository.TrashRestore(id);
                if (id != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> Archive(int id)
        {
            try
            {
                var result = await this._repository.Archive(id);
                if (id != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public async Task<bool> Pin(int id)
        {
            try
            {
                var result = await this._repository.Pin(id);
                if (id != 0)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Notes Not Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string UploadImage(string userid, int id, IFormFile file)
        {
            try
            {
                ImageCloudinary cloudinary = new ImageCloudinary();
                var url = cloudinary.ImgaeUrl(file);
                if (userid != null)
                {
                    return _repository.UploadImage(url, userid, id, file); ;
                }
                else
                {
                    throw new Exception("Image is not uploaded");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> Collaborate(IList<string> id, int noteId)
        {
            if (id != null)
            {
                return await _repository.Collaborate(id, noteId);
            }
            else
            {
                return false;
            }
        }

        public IList<NotesModel> Search(string word, string Id)
        {
            if (word != null)
            {
                return _repository.Search(word,Id);
            }
            else
            {
                throw new Exception("Not Found");
            }
        }
    }
}
