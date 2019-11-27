// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FundooTest.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace FundooTestCases
{
    using BussinessLayer.Services;
    using Common.Models;
    using Moq;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class FundooTest
    {
        /// <summary>
        /// Registrations this instance.
        /// </summary>
        [Fact]
        public void Registration()
        {
            var repository = new Mock<IRepository>();
            var bussiness = new BussinessRegister(repository.Object);
            var model = new RegistrationModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "Email",
                Mobile = "Mobile",
                UserName = "UserName",
                Password = "Password",
                ProfileImage = "ProfileImage"
            };
            var data = bussiness.Register(model);
            Assert.NotNull(data);
        }

        /// <summary>
        /// Logs the in.
        /// </summary>
        [Fact]       
        public void LogIn()
        {
            var repository = new Mock<IRepository>();
            var bussiness = new BussinessRegister(repository.Object);
            var model = new LoginModel()
            {
              
                UserName = "UserName",
                Password = "Password"
             
            };
            var data = bussiness.Login(model);
            Assert.NotNull(data);
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="tokenString">The token string.</param>
        [Theory]
       [InlineData("Token")]
        public void ResetPassword(string tokenString)
        {
            var repository = new Mock<IRepository>();
            var bussiness = new BussinessRegister(repository.Object);
            var model = new ResetPasswordModel()
            {

                Email = "Email",
                Password = "Password"

            };
            var data = bussiness.ResetPassword(model, tokenString);
            Assert.NotNull(data);
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        [Fact]
        public void ForgetPassword()
        {
            var repository = new Mock<IRepository>();
            var bussiness = new BussinessRegister(repository.Object);
            var model = new ForgotPasswordModel()
            {

                Email = "Email",
              
            };
            var data = bussiness.ForgotPassword(model);
            Assert.NotNull(data);
        }

        /// <summary>
        /// Labels this instance.
        /// </summary>
        [Fact]      
        public void Label()
        {
            var repository = new Mock<IRepositoryLabel>();
            var bussiness = new BussinessLabel(repository.Object);
            var model = new LabelModel()
            {

                UserId = "satish",
                Label = "MyLabel",     
            };
            var data = bussiness.Add(model);
            Assert.NotNull(data);
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        [Fact]
      public void UpdateLabel()
        {
            var mock = new Mock<IRepositoryLabel>();
            var bussiness = new BussinessLabel(mock.Object);
            var model = new LabelModel()
            {
                UserId = "satish",
                Label = "MyLabel",
            };
            var data = bussiness.Add(model);
            Assert.NotNull(data);
        }

        /// <summary>
        /// Creates the notes.
        /// </summary>
        [Fact]
        public void CreateNotes()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);
            var applicationUser = new NotesModel()
            {
                UserId = "5d71c5f7 - be3f - 4e39 - 9b88 - 91b63264de38",
                Title = "FirstNotes",
                Description = "This is My First Notes",
                Color = "#012345",
                Image = "sat.jpeg",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsArchive = true,
                IsTrash = true,
                IsPin = true,
                Reminder = DateTime.Now
            };
            var data = bussiness.CreateNotes(applicationUser);
            Assert.NotNull(data);
        }

        /// IList<LabelModel> GetLabel(string id);
        /// 
        [Fact]
        public void GetLabel()
        {
            var mock = new Mock<IRepositoryLabel>();
            var bussiness = new BussinessLabel(mock.Object);
            var model = new LabelModel()
            {
                UserId = "5d71c5f7 - be3f - 4e39 - 9b88 - 91b63264de38"
              
            };
            var data = bussiness.GetLabel(model.UserId);
            Assert.NotEmpty(data);
        }

        [Fact]
        public void TrashTest()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);
            var model = new NotesModel()
            {
              Id=3
            };
            var data = bussiness.Trash(model.Id);
            Assert.NotNull(data);
        }

        [Fact]
        public void TrashRestoreTest()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);
            var model = new NotesModel()
            {
                Id = 3
            };
            var data = bussiness.TrashRestore(model.Id);
            Assert.NotNull(data);
        }

        [Fact]
        public void ArchiveTest()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);
            var model = new NotesModel()
            {
                Id = 3
            };
            var data = bussiness.Archive(model.Id);
            Assert.NotNull(data);
        }

        [Fact]
        public void SearchTest()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);          
            var data = bussiness.Search("notes");
            Assert.NotNull(data);
        }
        

             [Fact]
        public void Collaborate()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);
            IList<string> id = new List<string>();    
                int noteId =5;
       
            var data = bussiness.Collaborate(id,noteId);
            Assert.NotNull(data);
        }

        [Fact]
        public void Pin()
        {
            var mock = new Mock<IRepositoryNotes>();
            var bussiness = new BussinessNotes(mock.Object);
            var model = new NotesModel()
            {
                Id = 3
            };
            var data = bussiness.Archive(model.Id);
            Assert.NotNull(data);
        }

        [Fact]
        public void AdminRegistration()
        {
            var repository = new Mock<IAdminSignUpRepository>();
            var bussiness = new AdminSignUpBussiness(repository.Object);
            var model = new RegistrationModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "Email",
                Mobile = "Mobile",
                UserName = "UserName",
                Password = "Password",
                ProfileImage = "ProfileImage"
            };
            var data = bussiness.AdminRegister(model);
            Assert.NotNull(data);
        }

        [Fact]
        public void AdminLogIn()
        {
            var repository = new Mock<IAdminSignUpRepository>();
            var bussiness = new AdminSignUpBussiness(repository.Object);
            var model = new LoginModel()
            {

                UserName = "UserName",
                Password = "Password"

            };
            var data = bussiness.Login(model);
            Assert.NotNull(data);
        }

    }
}
