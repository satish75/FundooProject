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
        public async Task<bool> CreateNotes(NotesModel notes,string id)
        {
            try
            {
                if (notes != null)
                {
                    return await _repository.CreateNotes(notes,id);
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
        public async Task<bool> DeleteNotes(List<int> id, string UserId)
        {
            try
            {
                if (id != null)
                {
                    return await _repository.DeleteNotes(id, UserId);
                }
                else
                {
                    return false;
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
        public IList<NotesModel> GetNotes(string UserId)
        {
            try
            {
                if ( UserId != null)
                {
                    return _repository.GetNotes(UserId);
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
        public async Task<bool> UpdateNotes(NotesModel model, int noteId)
        {

            try
            {
                var result = await this._repository.UpdateNotes(model,noteId);

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

        public async Task<bool> DeleteForever(List<int> id, string UserId)
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


        public async Task<bool> Trash(int id, string userId)
        {
            try
            {
                var result = await this._repository.Trash(id,userId);
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

        public async Task<bool> Archive(int id, string userId)
        {
            try
            {
                var result = await this._repository.Archive(id, userId);
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

        public async Task<bool> Collaborate(IList<string> id, int noteId,string userId)
        {
            if (id != null)
            {
                return await _repository.Collaborate(id, noteId,userId);
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

        public IList<NotesModel> GetAllTrash(string UserId)
        {
            try
            {
                if (UserId != null)
                {
                    return _repository.GetAllTrash(UserId);
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

        public IList<NotesModel> GetAllArchive(string UserId)
        {
            try
            {
                if (UserId != null)
                {
                    return _repository.GetAllArchive(UserId);
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

        public bool ColorService(ColorModel data)
        {
            try
            {
                if (data.userId != null)
                {
                    return _repository.ColorService(data);
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
    }
}
