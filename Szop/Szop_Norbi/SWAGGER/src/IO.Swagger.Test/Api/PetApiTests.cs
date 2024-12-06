/* 
 * Swagger Petstore - OpenAPI 3.0
 *
 * This is a sample Pet Store Server based on the OpenAPI 3.0 specification.  You can find out more about Swagger at [https://swagger.io](https://swagger.io). In the third iteration of the pet store, we've switched to the design first approach! You can now help us improve the API whether it's by making changes to the definition itself or to the code. That way, with time, we can improve the API in general, and expose some of the new features in OAS3.  _If you're looking for the Swagger 2.0/OAS 2.0 version of Petstore, then click [here](https://editor.swagger.io/?url=https://petstore.swagger.io/v2/swagger.yaml). Alternatively, you can load via the `Edit > Load Petstore OAS 2.0` menu option!_  Some useful links: - [The Pet Store repository](https://github.com/swagger-api/swagger-petstore) - [The source API definition for the Pet Store](https://github.com/swagger-api/swagger-petstore/blob/master/src/main/resources/openapi.yaml)
 *
 * OpenAPI spec version: 1.0.11
 * Contact: apiteam@swagger.io
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing PetApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class PetApiTests
    {
        private PetApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new PetApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of PetApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' PetApi
            //Assert.IsInstanceOfType(typeof(PetApi), instance, "instance is a PetApi");
        }

        /// <summary>
        /// Test AddPet
        /// </summary>
        [Test]
        public void AddPetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Pet body = null;
            //var response = instance.AddPet(body);
            //Assert.IsInstanceOf<Pet> (response, "response is Pet");
        }
        /// <summary>
        /// Test DeletePet
        /// </summary>
        [Test]
        public void DeletePetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? petId = null;
            //string apiKey = null;
            //instance.DeletePet(petId, apiKey);
            
        }
        /// <summary>
        /// Test FindPetsByStatus
        /// </summary>
        [Test]
        public void FindPetsByStatusTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string status = null;
            //var response = instance.FindPetsByStatus(status);
            //Assert.IsInstanceOf<List<Pet>> (response, "response is List<Pet>");
        }
        /// <summary>
        /// Test FindPetsByTags
        /// </summary>
        [Test]
        public void FindPetsByTagsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> tags = null;
            //var response = instance.FindPetsByTags(tags);
            //Assert.IsInstanceOf<List<Pet>> (response, "response is List<Pet>");
        }
        /// <summary>
        /// Test GetPetById
        /// </summary>
        [Test]
        public void GetPetByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? petId = null;
            //var response = instance.GetPetById(petId);
            //Assert.IsInstanceOf<Pet> (response, "response is Pet");
        }
        /// <summary>
        /// Test UpdatePet
        /// </summary>
        [Test]
        public void UpdatePetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Pet body = null;
            //var response = instance.UpdatePet(body);
            //Assert.IsInstanceOf<Pet> (response, "response is Pet");
        }
        /// <summary>
        /// Test UpdatePetWithForm
        /// </summary>
        [Test]
        public void UpdatePetWithFormTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? petId = null;
            //string name = null;
            //string status = null;
            //instance.UpdatePetWithForm(petId, name, status);
            
        }
        /// <summary>
        /// Test UploadFile
        /// </summary>
        [Test]
        public void UploadFileTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? petId = null;
            //Object body = null;
            //string additionalMetadata = null;
            //var response = instance.UploadFile(petId, body, additionalMetadata);
            //Assert.IsInstanceOf<ModelApiResponse> (response, "response is ModelApiResponse");
        }
    }

}
