using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelManagement.Core.Business.Business.Service;
using ModelManagement.Core.Business.Business.Model.Utils;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using ModelManagement.Core.Business.Business.Query;

namespace ModelManagement.Business.Test
{
    [TestClass]
    public class BusinessQueryTest
    {
        private ModelManagementQueryServices _queryService;
        [TestInitialize]
        public void SetUp()
        {
            this._queryService = new ModelManagementQueryServices();
        }

        #region UserTests
        [TestMethod]
        public void ListPersonalInformationTest()
        {
            QueryCommandBase queryParam = new QueryCommandBase();
            var list = _queryService.ListPersonalInformation(queryParam);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void EditPersonalInformationTest()
        {
            string personId = "10b523c0-9485-4f8a-a886-c86c35827b36";
            var edit = _queryService.EditPersonalInformation(personId);
            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void GetListModelsInfoTest()
        {
            var queryParam = new ListModelsQueryParam
            {
                //AgeFrom=18,
                //ThruAge=19,
                //ThruAge=20,
                //WeightFrom=3,
                //WeightThru=5,
                //WeightEnumId="KG",
                //CategoryTypeId = "RUN_WAY",
                Pagination = new Pagination(0,100)
            };
            var result = _queryService.GetListModelsInfo(queryParam);
        }

        [TestMethod]
        public void ListUserTest()
        {
            QueryCommandBase queryParam = new QueryCommandBase();
            var list = _queryService.ListUser(queryParam);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void EditUserTest()
        {
            string personId = "6a9c0ebcd8354d7dbb283573c4990d7a";
            var edit = _queryService.EditUser(personId);
            Assert.IsNotNull(edit);
        }
        
        [TestMethod]
        public void EditPhysicalInformationTest()
        {
            string personId = "092791334a914b24b7c1e2408360508e";
            var edit = _queryService.EditPhysicalInformation(personId);
            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void GetListPersonalInfoTest()
        {
            var queryParam = new ListPersonalInfoQueryParam 
            {
                SearchText="a",
                Pagination = new Pagination(0,100)
            };
            var result = _queryService.GetListPersonalInfo(queryParam);
        }

        [TestMethod]
        public void ListPersonsTest()
        {
            var queryParam = new ListPersonalInfoQueryParam();
            //queryParam.AgeFrom = 25;
            //queryParam.ThruAge = 26;
            //queryParam.UserNumber = "sbi";
            //queryParam.CategoryTypeIds = new List<string> { "MODELING" };
            //queryParam.CategoryTypeIds = new System.Collections.Generic.List<string>() { "FILM", "MODELING" };
            queryParam.HeightFrom = 1.56;
            queryParam.HeightThru = 1.56;
            queryParam.HeightUom = "METER";
            
            var result = _queryService.ListSearchPersonalInfos(queryParam);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditPersonalInfoTest()
        {
            var editPesonalInfo = new EditPersonalInfoQuery
            {
                PersonId = "ef0f4954-48d1-4513-a992-a59de31ef25e"
            };
            var result = _queryService.InvokeQuery(editPesonalInfo);
        }

        [TestMethod]
        public void ListModelslInfoQueryTest()
        {
            var listPersonalInfoQuery = new ListModelslInfoQuery
            {
                ModelsQueryParam = new ListModelsQueryParam
                {
                    Status= "ENABLED",
                    //IsActive=true,
                    Pagination = new Pagination(0, 8)
                }
            };
            var result = _queryService.InvokeQuery(listPersonalInfoQuery);
        }

        [TestMethod]
        public void CheckUserNameQueryTest()
        {
            var checkUserNameQuery = new CheckUserNameQuery
            {
                UserName = "Ash1a"
            };
            var result = _queryService.InvokeQuery(checkUserNameQuery);
        }
        #endregion

        #region CommonTests
        [TestMethod]
        public void LookupAllEnumerationTest()
        {
            var lookup = _queryService.LookupAllEnumeration();
            Assert.IsTrue(lookup.Count > 0);
        }


        [TestMethod]
        public void ListGeosTest()
        {
            var listGeos = new ListGeos
            {
                GeoIdTo = "ec54bd60-9acc-4520-88ee-2452bd918db7"
            };
            var result = _queryService.InvokeQuery(listGeos);
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void LookupEnumTest()
        {
            var lookupEnum = new LookupEnum
            {
                EnumTypeId = "COMPLEXION"
            };
            var result = _queryService.InvokeQuery(lookupEnum);
        }

        [TestMethod]
        public void LookupCategoryTypeTest()
        {
            var query = new LookupCategoryType();
            var result = _queryService.InvokeQuery(query);
        }

        [TestMethod]
        public void LookupCategoryTypeQueryTest()
        {
            var query = new LookupCategoryTypeQuery
            {

            };
            var result = _queryService.InvokeQuery(query);
        }

        #endregion

        #region CategoryQuery
        [TestMethod]
        public void ListCategoryTest()
        {
            string personId = "c8423b4a998a457983e469e9823d526e";
            var list = _queryService.ListCategory(personId);
            Assert.IsTrue(list.Count>0);
        }

        [TestMethod]
        public void EditCategoryTest()
        {
            string categoryId = "017a9505fbb449c9b48f0980af040095";
            var edit = _queryService.EditCategory(categoryId);
        }
        #endregion

        #region ContactQuery
        [TestMethod]
        public void ListContactInformationTest()
        {
            string personId = "c8423b4a998a457983e469e9823d526e";
            var list = _queryService.ListContactInformation(personId);
            Assert.IsTrue(list.Count>0);
        }

        [TestMethod]
        public void EditContactInformationTest()
        {
            string contactInfoId = "ebbb3f3d4a334fefa927f5220e99001a";
            var edit = _queryService.EditContactInformation(contactInfoId);
            Assert.IsNotNull(edit);
        }

        [TestMethod]
        public void LookupOffersQueryTest()
        {
            var query = new LookupOffersQuery();
            var result = _queryService.InvokeQuery(query);
        }

        [TestMethod]
        public void EditPhysicalInfoQueryTest()
        {
            var query = new EditPhysicalInfoQuery
            {
                PersonId = "0674dc4c-dd3e-4eb4-8eb0-163664e60a24"
            };
            var result = _queryService.InvokeQuery(query);
        }

        [TestMethod]
        public void ListPersonContactInfoQueryTest()
        {
            var query = new ListPersonContactInfoQuery
            {
                QueryParamArg = new QueryParamArg()
                {
                    ShowEntityCount = true,
                    Pagination = new Pagination(0,1),
                    SortDirection = "ASC",
                    SortingColumnName = "PersonId"
                },
                PersonId = "b9a3d7bf-c53b-4cca-8030-38d8f15ea6ca"
            };
            var result = _queryService.InvokeQuery(query);
        }

        //[TestMethod]
        //public void ListJobPostQueryTest()
        //{
        //    var query = new ListJobPostQuery
        //    {
        //        UserId= "a9b8f74b-8f2b-4b79-8309-2aa0794c5412"
        //    };
        //    var result = _queryService.InvokeQuery(query);
        //}

        [TestMethod]
        public void ListJobOfferQueryTest()
        {
            var query = new ListJobOfferQuery
            {
                JobPostId= "66445bbb-94fa-46a1-b744-8f51ef5223d3"
            };
            var result = _queryService.InvokeQuery(query);
        }

        [TestMethod]
        public void LookupContactMechTypeQueryTest()
        {
            var query = new LookupContactMechTypeQuery
            {
                QueryParamArg = new QueryParamArg
                {
                    SortingColumnName = "Description",
                    SortDirection = "DESC"
                }
            };
            var result = _queryService.InvokeQuery(query);
        }

        [TestMethod]
        public void ListOfferTypeQueryTest()
        {
            var query = new ListOfferTypeQuery
            {
                QueryParamArg = new QueryParamArg
                {
                    SearchText = "BRO"
                }
            };
            var result = _queryService.InvokeQuery(query);
        }

        [TestMethod]
        public void ListOfferItemTypeQueryTest()
        {
            var query = new ListOfferItemTypeQuery
            {
               OfferTypeId = "GOLD_USER"
            };
            var result = _queryService.InvokeQuery(query);
        }
        #endregion

    }
}
 