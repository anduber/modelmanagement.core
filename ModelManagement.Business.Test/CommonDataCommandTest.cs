using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelManagement.Core.Business.Business.Command;
using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Service;

namespace ModelManagement.Business.Test
{
    [TestClass]
    public class CommonDataCommandTest
    {
        private ModelManagementCommandServices _service;
        [TestInitialize]
        public void SetUp()
        {
            _service = new ModelManagementCommandServices();
        }

        [TestMethod]
        public void CreateOfferTypeCommandTest()
        {
            var  command = new CreateOfferTypeCommand
            {
                UserLoginId = "00622e41-b4ca-4670-a3e9-b06a2b619e65",
                Sequence = "0023",
                Description = "Desc",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente esse necessitatibus neque.Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente esse necessitatibus nequeLorem ipsum dolor sit amet, consectetur adipisicing elit.",
                ValidNoOfDays = 23,
                FeeAmount = 12,
            };
            var result = _service.InvokeCommand(command);
        }

        [TestMethod]
        private void InvokeTest(ICommand command)
        {
            var result = _service.InvokeCommand(command);
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void UpdateOfferTypeCommandTest()
        {
            var command = new UpdateOfferTypeCommand
            {
                OfferTypeId = "04f92ebd-a18b-4f0e-a81d-053171e72a19",
                UserLoginId = "00622e41-b4ca-4670-a3e9-b06a2b619e65",
                Sequence = "002322222222",
                Description = "Desc222222"
            };
            var result = _service.InvokeCommand(command);
        }

        [TestMethod]
        public void DeactivateOfferTypeCommandTest()
        {
            var command = new DeactivateOfferTypeCommand
            {
                OfferTypeId = "45780f35-26e1-48c8-b16a-35de350e6a93"
            };
            var result = _service.InvokeCommand(command);
        }

        [TestMethod]
        public void RemoveOfferTypeCommandTest()
        {
            var command = new RemoveOfferTypeCommand
            {
                OfferTypeId = "63e510c2-ef9c-4002-8ce7-268139579b15"
            };
            var result = _service.InvokeCommand(command);
        }

        [TestMethod]
        public void CreateOfferItemTypeCommandTest()
        {
            var command = new CreateOfferItemTypeCommand
            {
                UserLoginId = "00622e41-b4ca-4670-a3e9-b06a2b619e65",
                Description = "Offer6",
                Sequence = "005",
                OfferTypeId = "FREE_USER"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void UpdateOfferItemTypeCommandTest()
        {
            var command = new UpdateOfferItemTypeCommand
            {
                OfferItemTypeId = "e55d02f3-cbfe-45c1-9c71-f604abe62e4e",
                Description = "34",
                Sequence = "34"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void AddOfferItemTypeMapCommandTest()
        {
            var command = new AddOfferItemTypeMapCommand
            {
                OfferTypeId = "FREE_USER",
                OfferItemTypeId = "OFFER_4",
                UserLoginId = "00622e41-b4ca-4670-a3e9-b06a2b619e65"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void RemoveOfferItemTypeMapCommandTest()
        {
            var command = new RemoveOfferItemTypeMapCommand
            {
                OfferItemTypeId = "2c68003d-418d-4d28-b328-cd6601b25471",
                OfferTypeId = "FREE_USER"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void CreateEnumerationTypeCommandTest()
        {
            var command = new CreateEnumerationTypeCommand
            {
                EnumerationTypeId = "",
                Description = "Desc",
                UserLoginId = "0219eaef-3c70-4b5e-9a5b-f689e6913dbc"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void UpdateEnumerationTypeCommandTest()
        {
            var command = new UpdateEnumerationTypeCommand
            {
                EnumerationTypeId = "8062dbe5-1341-43b4-9b9b-0f667c908dae",
                Description = "Body Size",
                UserLoginId = "0219eaef-3c70-4b5e-9a5b-f689e6913dbc"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void RemoveEnumerationTypeCommandTest()
        {
            var command = new RemoveEnumerationTypeCommand
            {
                EnumerationTypeId = "c0395fe7-0678-4c1b-8dd6-8ac32202f9a2"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]
        public void CreateEnumerationCommandTest()
        {
            var command = new CreateEnumerationCommand
            {
                EnumerationId = "1234",
                EnumerationTypeId = "HAIR_COLOR",
                Description = "Desc",
                UserLoginId = "0219eaef-3c70-4b5e-9a5b-f689e6913dbc"
            };
            _service.InvokeCommand(command);
        }

        [TestMethod]    
        public void RemoveEnumerationCommandTest()
        {
            var command = new RemoveEnumerationCommand
            {
                EnumerationId = "7edd22e3-a600-4105-8398-a3efd1c618c9"
            };
            var result = _service.InvokeCommand(command);
        }

        [TestMethod]
        public void CreateGeoTypeCommandTest()
        {
            var command = new CreateGeoTypeCommand
            {
                Description = "Desc",
                UserLoginId = "0219eaef-3c70-4b5e-9a5b-f689e6913dbc"
            };
            InvokeTest(command);
        }

        [TestMethod]
        public void UpdateGeoTypeCommandTest()
        {
            var command = new UpdateGeoTypeCommand
            {
                GeoTypeId = "a3732107-9e6d-4e52-aab3-c13dd0cad4e6",
                GeoTypePurposeId = "GEO_ASSOC",
                Description = "Derrrr",
                UserLoginId = "0219eaef-3c70-4b5e-9a5b-f689e6913dbc"
            };
            InvokeTest(command);
        }

        [TestMethod]
        public void RemoveGeoTypeCommandTest()
        {
            var command = new RemoveGeoTypeCommand
            {
                GeoTypeId = "a3732107-9e6d-4e52-aab3-c13dd0cad4e"
            };
            InvokeTest(command);
        }
    }
}
