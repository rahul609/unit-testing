using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment3.Controllers;
using Moq;
using Assignment3.Models;
using System.Linq;
using System.Web.Mvc;

namespace Assignment3.Tests.Controllers
{
    /// <summary>
    /// Summary description for phones1ControllerTest
    /// </summary>
    [TestClass]
    public class phones1ControllerTest
    {

        phones1Controller controller;
        Mock<IMockphones1Repository> mock;
        List<phones1> phones;

        [TestInitialize]

        public void TestInitialize()
        {

            // runs automatically before each unit test
            // instantiate the mock object
            mock = new Mock<IMockphones1Repository>();

            // instantiate the mock phones data
            phones = new List<phones1>
            {

                new phones1 { phoneID = 1, phones = "phones 1" },
                new phones1 { phoneID = 2, phones = "phones 2" },
                new phones1 { phoneID = 3, phones = "phones 2" },

            };
            //bind the data to the mock
            mock.Setup(m => m.Phones1).Returns(phones.AsQueryable());

            // initialize the controller and inject the dependency
            controller = new phones1Controller(mock.Object);


        }

        [TestMethod]

        public void IndexViewLoads()
        {


            //act
            var actual = controller.Index();

            // assert
            Assert.IsNotNull(actual);


        }

        [TestMethod]

        public void IndexLoadsPhones1()
        {

            // act - cast ActionResult to ViewResult, then Model to List of phones1
            var actual = (List<phones1>)((ViewResult)controller.Index()).Model; 

            // assert
            CollectionAssert.AreEqual(phones, actual);

        }

        [TestMethod]

        public void DetailsValidPhoneId()
        {

            // act
            var actual = (phones1)((ViewResult)controller.Details(1)).Model;

            // assert
            Assert.AreEqual(phones[0], actual);


        }

        [TestMethod]

        public void DetailsInvalidphones1Id()
        {

            // act - expect the index view to load if no matching phones
            var actual = (ViewResult)controller.Details(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);

        }

        [TestMethod]

        public void DetailsNophones1Id()
        {

            // act 
            var actual = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);

        }

        // GET: Edit
        [TestMethod]

        public void EditGetValidId()
        {

            // act 
            var actual = ((ViewResult)controller.Edit(1)).Model;

            // assert
            Assert.AreEqual(phones[0], actual);

        }

        [TestMethod]

        public void EditGetInvalidId()
        {

            // act 
            var actual = (ViewResult)controller.Edit(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);

        }


        [TestMethod]

        public void EditGetNoId()
        {
            int? id = null;

            // act 
            var actual = (ViewResult)controller.Edit(id);

            // assert
            Assert.AreEqual("Error", actual.ViewName);

        }

        // POST: Edit
        [TestMethod]

        public void EditPostValidId()
        {

            // act 
            var actual = (RedirectToRouteResult)controller.Edit(phones[0]);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }

        [TestMethod]

        public void EditpostInvalid()
        {
            // arrange - manually set model state to invalid
            controller.ModelState.AddModelError("Key", "update error");

            // act 
            var actual = (ViewResult)controller.Edit(phones[0]);

            // assert
            Assert.AreEqual("Edit", actual.ViewName);

        }

        // Create
        [TestMethod]

        public void CreateViewLoads()
        {


            // act
            var actual = (ViewResult)controller.Create();

            //assert
            Assert.AreEqual("Create", actual.ViewName);

        }

        [TestMethod]

        public void CreateValid()
        {
            // arrange
            phones1 a = new phones1
            {

                Name = "New phones1"

            };

            // act
            var actual = (RedirectToRouteResult)controller.Create(a);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }

        [TestMethod]

        public void CreateInValid()
        {
            // arrange
            phones1 a = new phones1
            {

                Name = "New phones1"

            };

            controller.ModelState.AddModelError("key", "create error");

            // act
            var actual = (ViewResult)controller.Create(a);

            //assert
            Assert.AreEqual("Create" , actual.ViewName);



        }

        // DELETE
        [TestMethod]

        public void DeleteGetValidId()
        {


            // act
            var actual = ((ViewResult)controller.Delete(1)).Model;

            //assert
            Assert.AreEqual(phones[0], actual);

        }

       
        [TestMethod]

        public void DeleteGetInvalidId()
        {


            // act
            var actual = (ViewResult)controller.Delete(4);

            //assert
            Assert.AreEqual("Error", actual.ViewName);

        }

        [TestMethod]

        public void DeleteGetNoId()
        {


            // act
            var actual = (ViewResult)controller.Delete(null);

            //assert
            Assert.AreEqual("Error", actual.ViewName);

        }

        [TestMethod]

        public void DeletePostValid()
        {


            // act
            var actual = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);

        }

    }
}
