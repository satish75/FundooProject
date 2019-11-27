// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryLabel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace RepositoryLayer.Services
{
    using Common.Models;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// this class implemented from IRepository Label interface
    /// </summary>
    /// <seealso cref="RepositoryLayer.Interface.IRepositoryLabel" />
    public class RepositoryLabel : IRepositoryLabel
    {

        private readonly ContextData _contextData;

        //private IConfiguration _configuration;

        /// <summary>
        /// Create the parameterized Constructor of class and pass the UserManager
        /// </summary>
        /// <param name="userManager"></param>
        public RepositoryLabel(ContextData contextData)
        {

            _contextData = contextData;

        }

        /// <summary>
        /// Adds the specified label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        public async Task<bool> Add(LabelModel label)
        {
            var applicationLabel = new LabelModel()
            {


                UserId = label.UserId,
                Label = label.Label,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
               
            };

            _contextData.Add(applicationLabel);
            var results = await _contextData.SaveChangesAsync();

            if (results >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<string> DeleteLabel(int id)
        {
            ////linq for delete notes...it storing the information in delete variable for perticular id
            var deleteNotes = this._contextData.labelUser.Where(s => s.Id == id).FirstOrDefault();


            if (deleteNotes != null)
            {
                ////removing the information from the database
                this._contextData.Remove(deleteNotes);

                ////saving the changes to the database
                await this._contextData.SaveChangesAsync();
                return "Successfully Deleted";
            }
            else
            {
                return "Unsuccessfull";
            }

        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IList<LabelModel> GetLabel(string id)
        {
            try
            {
                var getUserLabels = from getUser in _contextData.labelUser
                              .Where(s => s.UserId == id)
                                   select getUser;

                return getUserLabels.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> UpdateLabel(LabelModel model, int id)
        {
            {

                ////getting the records by id
                var labelData = (from label in _contextData.labelUser
                                 where label.Id == id
                                 select label).FirstOrDefault();

                ////if notes data have records then it will update the records
                if (labelData != null)
                {
                    if (model.Label != "string" || model.Label != null)
                    {
                        labelData.Label = model.Label;
                    }

                    labelData.ModifiedDate = DateTime.Now;
                    ////save changes to the database
                    await this._contextData.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
