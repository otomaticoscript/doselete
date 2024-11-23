using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doselete.Infrastructure.RestAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Doselete.Application.UserCase;
using Doselete.Domain.Repository.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Moq;
using System.Configuration;
using Newtonsoft.Json;
using Doselete.Domain.Entity;

namespace Doselete.Infrastructure.RestAPI.Controllers.Tests
{
    [TestClass()]
    public class MasterControllerTests
    {
        private MasterController controller;
        private string dbSQL = "Server=localhost;Database=doselete;Port=3306;Connect Timeout=2147483;Userid=root;Pwd=;AllowUserVariables=True;";

        private class IdResponse
        {
            public int Id { get; set; }
        }
        [TestInitialize]
        public void TestInitialize()
        {
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "dbSQL")]).Returns(dbSQL);

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(mockConfSection.Object);
            var connection = new MySqlConnection();

            IMasterData masterData = new MasterData(configuration.Object, connection);
            IMasterManager masterManager = new MasterManager(masterData);

            controller = new MasterController(masterManager);
        }
        private string loadJson(string name)
        {
            var URI = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + $"Mock/{name}");
            if (File.Exists(URI))
            {
                throw new Exception($"No Existe el fichero en [{URI}], verifica que lo has copiado bien.");
            }
            return File.ReadAllText(URI);
        }
        [TestMethod()]
        public async Task GetMastersTest()
        {
            JsonResult json = (JsonResult)await controller.GetMasters();
            Assert.IsNull(json.Value);
        }
        [TestMethod()]
        public async Task GetOptionsTest()
        {
            JsonResult json = (JsonResult)await controller.GetOptions(1);
            Assert.IsNull(json.Value);
        }
        [TestMethod()]
        public async Task InsertMasterTest()
        {
            var filestring = loadJson("masterNew.json");
            var master = JsonConvert.DeserializeObject<Master[]>(filestring);

            JsonResult jsonResponse = (JsonResult)await controller.SetMaster(master[0]);
            if (jsonResponse.Value != null)
            {
                IdResponse remove = (IdResponse)jsonResponse.Value;
                await controller.RemoveMaster(remove.Id);
            }
            Assert.IsNull(jsonResponse.Value);
        }
        [TestMethod()]
        public async Task UpdateMasterTest()
        {
            var filestring = loadJson("masterNew.json");
            var master = JsonConvert.DeserializeObject<Master[]>(filestring);

            JsonResult first = (JsonResult)await controller.SetMaster(master[0]);

            IdResponse inserted = (IdResponse)first.Value;
            master[1].Id = inserted.Id;
            JsonResult jsonResponse = (JsonResult)await controller.SetMaster(master[1]);

            Assert.IsNull(jsonResponse.Value);
            await controller.RemoveMaster(inserted.Id);

        }
    }
}