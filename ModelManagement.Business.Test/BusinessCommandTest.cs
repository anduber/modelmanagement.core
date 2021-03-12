using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelManagement.Core.Business.Business.Service;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Command;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.EntityProfile;


namespace ModelManagement.Business.Test
{
    [TestClass]
    public class BusinessCommandTest
    {
        private ModelManagementCommandServices _service;
        [TestInitialize]
        public void SetUp()
        {
            _service = new ModelManagementCommandServices();
        }

        #region UserCommandsTest

        private void InvokeTest()
        {

        }

        [TestMethod]
        public void CreateUserCommandTest()
        {
            var command = new CreateUserCommand
            {
                UserCommandArg = new UserCommandArg
                {
                    Description = "test",
                    UserName = "askuale",
                    PrimaryPhoneNumber = "125545",
                    StatusId = "ENABLED",
                    Password = "12333232",
                    RoleTypeId = "SYS_AGENT"
                }
            };
            var result = _service.InvokeCommand(command);
        }



        [TestMethod]
        public void UpdateUserCommand()
        {
            var updateUserCommand = new UpdateUserCommand
            {
                PersonId = "4b642a56a4f542ff86d3783226b7c83b",
                Email = "user2@gmail.com",
                RoleTypeId = "SYS_ADMIN"
            };
            //updateUserCommandModel.UserName = "user1";
            //updateUserCommandModel.RoleTypeId = "SYS_USER";
            //var result = _service.UpdateUserCommand(updateUserCommandModel);
            //Assert.IsTrue(result.IsSuccess);
            var result = _service.InvokeCommand(updateUserCommand);
        }

        [TestMethod]
        public void RemoveUserCommandTest()
        {
            var removeUserComman = new RemoveUserCommand { PersonId = "9558128e683a4793b148728d640681cf" };
            var result = _service.InvokeCommand(removeUserComman);
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void ChangeUserStatusCommandTest()
        {
            var changeStatusCommand = new ChangeUserStatusCommand
            {
                PersonId = "0674dc4c-dd3e-4eb4-8eb0-163664e60a24",
                StatusId = Utility.StatusDisabled,
                UserLoginId = "142f29b4-f873-4bf8-b1fe-88db902e46b1"
            };
            var _result = _service.InvokeCommand(changeStatusCommand);
        }

        [TestMethod]
        public void CreatePersonalInformationCommandTest()
        {
            CreatePersonalInformationCommand _command = new CreatePersonalInformationCommand();
            _command.UserLoginId = "5428043b9eae4ad382795f763260c596";
            _command.PersonalInformationArg = new PersonalInformationArg()
            {
                UserName = "mode2vc",
                FirstName = "model2vc",
                DateOfBirth = DateTime.Now.AddYears(-26),
                Sex = "Female"
            };
            _command.CategoryIds = new List<string>() { "VIDEO_COMMERCIALS", "PRINT_COMMERCIALS" };
            var result = _service.InvokeCommand(_command);

        }

        [TestMethod]
        public void UpdatePersonalInformationCommandTest()
        {
            var updatePersonalInfoCmd = new UpdatePersonalInformationCommand();
            updatePersonalInfoCmd.PersonId = "16c7aa1a-27d9-424f-bfc5-a7e1ba0804bb";
            updatePersonalInfoCmd.UserLoginId = "142f29b4-f873-4bf8-b1fe-88db902e46b1";
            updatePersonalInfoCmd.PersonalInformationArg = new PersonalInformationArg()
            {
                FirstName = "Adela",
                FatherName = "Echegoyen",
                LastName = "Eshetu",
                Sex = "F",
                DateOfBirth = DateTime.Now,
                GeoId = "ETH"
            };
            updatePersonalInfoCmd.CategoryTypeIds = new List<string>
            {
                "PRINT_COMMERCIALS","RUN_WAY"
            };
            //updatePersonalInfoCmd.UplodableArg = new UploadableArg
            //{
            //    File = new UtilityMethods().ConvertImageToByteArray("5.jpg"),
            //    FileTypeId = "PROFILE_PIC"
            //};
            var _result = _service.InvokeCommand(updatePersonalInfoCmd);
        }

        [TestMethod]
        public void CreatePhysicalInformationCommandTest()
        {
            CreateUpdatePhysicalInformationCommand _cpPhysicalInfCmd = new CreateUpdatePhysicalInformationCommand();
            _cpPhysicalInfCmd.PersonId = "1adfdcca74514adf93979becd00f65e8";
            _cpPhysicalInfCmd.UserLoginId = "5428043b9eae4ad382795f763260c596";
            _cpPhysicalInfCmd.PhysicalInformationArg = new PhysicalInformationArg()
            {
                Bust = 1.9,
                DressSize = "XL",
                EyeColor = "Red",
                HairColor = "RED",
                Height = 1.56,
                Hip = 3.3,
                ShoeSize = 32,
                Waist = 90,
                Weight = 68,
                HeightEnumId = "METER",
                WeightEnumId = "KG"
            };
            var _result = _service.InvokeCommand(_cpPhysicalInfCmd);
        }

        [TestMethod]
        public void UpdatePhysicalInformationCommandTest()
        {
            PhysicalInformationCommandModel physicalInformationCreate = new PhysicalInformationCommandModel();
            physicalInformationCreate.Bust = 1.9;
            physicalInformationCreate.DressSize = "XL";
            physicalInformationCreate.EyeColor = "Red";
            physicalInformationCreate.HairColor = "Regora";
            physicalInformationCreate.Height = 1.56;
            physicalInformationCreate.Hip = 3.0;
            physicalInformationCreate.PersonId = "1c1e2100ed284113a42c5aa6b70d984c";
            physicalInformationCreate.ShoeSize = 32;
            physicalInformationCreate.Waist = 90;
            physicalInformationCreate.Weight = 68;

            //var result = _service.UpdatePhysicalInformationCommand(physicalInformationCreate);
            //Assert.IsTrue(result.IsSuccess);
        }


        [TestMethod]
        public void AuthenticateUserCommandTest()
        {
            AuthenticateUserCommand _authenticateUser = new AuthenticateUserCommand
            {
                UserName = "admin_test4",
                Password = "test2"
            };
            var result = _service.InvokeCommand(_authenticateUser);
        }

        [TestMethod]
        public void AddUserRoleCommandTest()
        {
            var userRoleCommand = new AddUserRoleCommand
            {
                UserId = "0674dc4c-dd3e-4eb4-8eb0-163664e60a24",
                RoleTypeId = "SYS_MODEL",
                UserLoginId = "00622e41-b4ca-4670-a3e9-b06a2b619e65"
            };
            var result = _service.InvokeCommand(userRoleCommand);
        }

        [TestMethod]
        public void RegisterModelCommandTest()
        {
            var registerCommand = new RegisterModelCommand
            {
                PersonalInformationArg = new PersonalInformationArg
                {
                    UserName = "Jalenii23",
                    FirstName = "Berhane",
                    FatherName = "Birhanu",
                    DateOfBirth = DateTime.Parse("1992-01-06T21:00:00.000Z"),
                    Sex = "F",
                    Email = "lula@gmail.com",
                    //GeoId = "792cbf1e-af13-4e13-b844-2e0597a96219",
                    OfferTypeId = "PREMIMUM_USER"
                },

                PhysicalInformationArg = new PhysicalInformationArg
                {
                    Height = 1.70,
                    HeightEnumId = "METER",
                    Weight = 65,
                    WeightEnumId = "KG",
                    Complexion = "lula@gmail.com"
                },
                ContactInfoArgs = new List<ContactInfoArg>()
                {
                    new ContactInfoArg
                    {
                        ContactMechTypeId="WEBSITE",
                        ContactUrl="http://www.smitspatriciagarity.com"
                    },
                    new ContactInfoArg
                    {
                        ContactMechTypeId="INSTAGRAM",
                        ContactUrl="@lula"
                    }
                },
                CategoryTypeIds = new List<string> { "MODELING", "VIDEO_COMMERCIALS", "PRINT_COMMERCIALS" }
            };
            var result = _service.InvokeCommand(registerCommand);
        }

        [TestMethod]
        public void UploadUser()
        {
            //UploadUserCommand cmd = new UploadUserCommand();
            //var xxx = _service.InvokeCommand(cmd);
        }

        #endregion

        #region FileUploadCommandsTest
        [TestMethod]
        public void CreateUploadableCommandTest()
        {
            var createUploadable = new CreateUploadableCommand
            {
                PersonId = "421f563f-1840-4635-9b70-a6e1fd57fe6a",
                UplodableArg = new UploadableArg
                {
                    FileTypeId = "PROFILE_PIC",
                    File = new UtilityMethods().ConvertImageToByteArray("1.jpg")
                },
                UserLoginId = "142f29b4-f873-4bf8-b1fe-88db902e46b1"
            };
            var result = _service.InvokeCommand(createUploadable);
        }

        [TestMethod]
        public void CreateUplodablesCommandTest()
        {
            var createUplodablesCommand = new SaveUplodablesCommand
            {
                PersonId = "16c7aa1a-27d9-424f-bfc5-a7e1ba0804bb",
                UserLoginId = "142f29b4-f873-4bf8-b1fe-88db902e46b1",
                UplodableArgs = new List<UploadableArg>
                {
                   new UploadableArg
                   {
                       FileTypeId = "HEADER_PIC",
                       MimeTypeId="image/jpeg",
                       FileUploadId="5852efd0-dd72-44ba-901b-ddc69b139359",
                       File = new UtilityMethods().ConvertImageToByteArray("res/15.jpg")
                   },
                   new UploadableArg
                   {
                       FileTypeId="HEADER_PIC",
                       MimeTypeId="image/jpeg",
                       FileUploadId="7763cb76-e706-4110-aae6-2869c26b0af3",
                       File = new UtilityMethods().ConvertImageToByteArray("res/4.jpg")
                   },
                   new UploadableArg
                   {
                       FileTypeId="HEADER_PIC",
                       MimeTypeId="image/jpeg",
                       File = new UtilityMethods().ConvertImageToByteArray("res/8.jpg")
                   },
                   //new UplodableArg
                   //{
                   //    FileTypeId="PROFILE_PIC",
                   //    File = new UtilityMethods().ConvertImageToByteArray("res/6.jpg")
                   //},
                   //new UplodableArg
                   //{
                   //    FileTypeId="PROFILE_PIC",
                   //    File = new UtilityMethods().ConvertImageToByteArray("res/7.jpg")
                   //}
                }
            };
            var result = _service.InvokeCommand(createUplodablesCommand);
        }

        [TestMethod]
        public void RemoveUplodableCommandTest()
        {
            var removeUplodableCommand = new RemoveUplodableCommand
            {
                FileUploadId = "7763cb76-e706-4110-aae6-2869c26b0af3"
            };
            var result = _service.InvokeCommand(removeUplodableCommand);

        }

        #endregion

        #region CommonCommandTest
        [TestMethod]
        public void CreateGeoTypesTest()
        {
            var xclImport = new ImportFromExcel();
            var geoTypeImportList = xclImport.ExportToList<GeoTypeImp>("G:/WorkFiles/ModelManagement/res/geo/geo.xlsx", "GEO_ASSOC_TYPE");

            var geoTypeArgs = geoTypeImportList.Select(gtyMap => new GeoTypeArg { GeoTypeId = gtyMap.GEO_TYPE_ID, Description = gtyMap.DESCRIPTION, GeoTypePurposeId = "GEO_ASSOC" }).ToList();
            var createGeoTypesCommand = new CreateGeoTypesCommand
            {
                GeoTypeArgs = geoTypeArgs
            };

            var result = _service.InvokeCommand(createGeoTypesCommand);

        }

        [TestMethod]
        public void CreateGeosCommandTest()
        {
            var xclImport = new ImportFromExcel();
            var geoImportList = xclImport.ExportToList<GeoImport>("G:/WorkFiles/ModelManagement/res/geo/geo_dial.xlsx", "Sheet1");
            var geoArgs = (from geoImp in geoImportList
                           where !string.IsNullOrEmpty(geoImp.GEO_CODE)
                           select new GeoArg
                           {
                               //GeoId = geoImp.GEO_ID,
                               //GeoTypeId = geoImp.GEO_TYPE_ID,
                               //GeoName = geoImp.GEO_NAME,
                               GeoCode = geoImp.GEO_CODE,
                               DialingCode = geoImp.DIALING_CODE
                           }).ToList();
            ;
            var createGeoCommand = new CreateGeosCommand
            {
                GeoArgs = geoArgs
            };
            var result = _service.InvokeCommand(createGeoCommand);

        }

        [TestMethod]
        public void CreateGeoAssocCommandTest()
        {
            var xclImport = new ImportFromExcel();
            var geoAssocImportList = xclImport.ExportToList<GeoAssocImport>("G:/WorkFiles/ModelManagement/res/geo/geo.xlsx", "GEO_ASSOC");
            var geoAssocArg = new List<GeoAssocArg>();
            geoAssocImportList.ForEach(t => geoAssocArg.Add(new
            GeoAssocArg
            {
                GeoId = t.GEO_ID,
                GeoIdTo = t.GEO_ID_TO,
                GeoAssocTypeId = t.GEO_ASSOC_TYPE_ID
            }));
            var result = _service.InvokeCommand(new CreateGeoAssocesCommand { GeoAssocArgs = geoAssocArg });

        }


        #endregion



        #region ContactCommands
        [TestMethod]
        public void CreateContactInfosCommandTest()
        {
            var contactInfoCommand = new CreateContactInfosCommand
            {
                ContactInfoArgs = new List<ContactInfoArg>
                {
                    new ContactInfoArg
                    {
                        ContactMechTypeId="FACEBOOK",
                        ContactUrl="berly@facebook.com"
                    },
                    new ContactInfoArg
                    {
                        ContactMechTypeId="EMAIL",
                        ContactUrl="verly@gmail.com"
                    }
                },
                PersonId = "1ee96cea-a3cb-4388-9ebb-cc33369d0faf",
                UserLoginId = "66f24112-7bf9-4e34-9e12-f03f9dfdc509"
            };
            var result = _service.InvokeCommand(contactInfoCommand);
        }

        [TestMethod]
        public void RemoveContactInfoCommandTest()
        {
            var removeContactInfoCommand = new RemoveContactInfoCommand
            {
                PersonId = "2f5f6692-ed32-4fc6-84a6-6d2512ebca2a",
                ContactMechTypeId = "TELEPHONE",
                ContactUrl = "650-811-9032"
            };
            var result = _service.InvokeCommand(removeContactInfoCommand);
        }

        [TestMethod]
        public void CreateContactCommandTest()
        {
            var createContactCommand = new CreateContactCommand
            {
                PersonId = "b9a3d7bf-c53b-4cca-8030-38d8f15ea6ca",
                ContactInfoArg = new ContactInfoArg
                {
                    ContactUrl = "aster2@facebook.com",
                    ContactMechTypeId = "FACEBOOK"
                }
            };
            var result = _service.InvokeCommand(createContactCommand);
        }

        [TestMethod]
        public void SetVisitorCommandTest()
        {
            var command = new SetVisitorCommand
            {
                //VisitorId = "e46a4463-eff9-43c1-a2cb-0e0e47abdcce",
                // UserLoginId = "04b63753-53a2-4b13-bf86-7f064079ad9d",
                VisitorArg = new VisitorArg(),
                UserAgentTypeId = "WEB_APP"
            };
            var result = _service.InvokeCommand(command);
        }
        #endregion
    }
}
