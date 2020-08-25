using ModelManagement.Core.Business.Business.Model.CommandModel;
using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using ModelManagement.Core.Business.Business.Model.Utils;
using System.Net;
using AutoMapper.QueryableExtensions;
using static System.String;
using System.Linq.Dynamic;

namespace ModelManagement.Core.Business.Business.Helpers
{
    public static class Utility
    {
        public const string UserExistMessage = "UserName Already Exists";

        public const string StatusEnabled = "ENABLED";
        public const string StatusDisabled = "DISABLED";

        public const string RoleTypeUser = "SYS_USER";
        public const string RoleTypeAdmin = "SYS_ADMIN";
        public const string RoleTypeModel = "SYS_MODEL";
        public const string RoleTypeAgent = "SYS_AGENT";

        public const string ContentTypeProfilePic = "PROFILE_PIC";
        public const string HeaderPic = "HEADER_PIC";
        public const string DefaultFilePath = "image/profile.png";
        public const string DefaultPassword = "test";

        public class Status
        {
            public const string JobOfferOffered = "JOB_OFFER_OFFERED";
            public const string JobOfferAccepted = "JOB_OFFER_ACCEPTED";
            public const string JobApplied = "JOB_APP_APPLIED";
            public const string JobQualified = "JOB_APP_QUALIFIED";
            public const string JobRejected = "JOB_APP_REJECTED";
            public const string JobPostCreated = "JOB_POST_CREATED";
        }

        public class GeoTypes
        {
            public const string City = "CITY";
            public const string Country = "COUNTRY";
            public const string Regions = "REGIONS";

        }

        public static class Modules
        {
            public const string User = "User";
            public const string FileUpload = "FileUpload";
        }

        public static class Users
        {
            public const string EmailAdminUserLoginId = "email_admin_login";
            public const string EmailAdminUserId = "email_admin";
        }

        public static string GetId()
        {
            return Guid.NewGuid().ToString("D");
        }



        public static string GetFileName()
        {
            return GetId() + "." + System.Drawing.Imaging.ImageFormat.Jpeg;
        }

        /// <GetUserNumber>
        /// GetUserNumber
        /// </GetUserNumber>
        /// <returns></returns>
        public static string GetUserNumber()
        {
            const int stringLenght = 3;
            const int intLength = 3;
            const int stringNumberLength = 4;
            const string stringPlool = "abcedfghijklmnopqrstuvwxyz";
            const string numberPlool = "0123456789";
            const string stringAndNumberPool = "abcedfghijklmnopqrstuvwxyz0123456789";
            var stringBuilder = new StringBuilder();
            var numberBuilder = new StringBuilder();
            var stringAndNumberBuilder = new StringBuilder();
            var ran = new Random();

            for (var i = 0; i < stringLenght; i++)
            {
                var str = stringPlool[ran.Next(0, stringPlool.Length)];
                stringBuilder.Append(str);
            }

            for (var i = 0; i < intLength; i++)
            {
                var str = numberPlool[ran.Next(0, numberPlool.Length)];
                numberBuilder.Append(str);
            }

            for (var i = 0; i < stringNumberLength; i++)
            {
                var strNmbr = stringAndNumberPool[ran.Next(0, stringAndNumberPool.Length)];
                stringAndNumberBuilder.Append(strNmbr);
            }
            return stringBuilder + "-" + stringAndNumberBuilder + "-" + numberBuilder;
        }

        public static string GetVerificationCode()
        {
            var generator = new Random();
            return generator.Next(0, 999999).ToString("D6");
        }

        /// <CommandSuccess>
        /// CommandSuccess
        /// </CommandSuccess>
        /// <param name="data"></param>
        /// <returns></returns>
        public static CommandResult CommandSuccess(object data = null)
        {
            return new CommandResult()
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static CommandResult CommandError(string errorMessage = "")
        {
            return new CommandResult()
            {
                ErrorMessage = errorMessage,
                IsSuccess = false
            };
        }

        public static string GetSecurityToken()
        {
            var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        public static void CommandException(string exceptionMessage = "", string exceptionType = "")
        {
            throw new InvalidOperationException(exceptionMessage);
        }

        public static string HashPassword(string password)
        {
            var sha1 = SHA1.Create();
            var hashData = sha1.ComputeHash(Encoding.Default.GetBytes(password));
            var returnValue = new StringBuilder();
            foreach (var t in hashData)
            {
                returnValue.Append(t.ToString());
            }

            return returnValue.ToString();
        }

        public static bool ValidateHashPassword(string password, string hashedPassword)
        {
            var hashInputPassword = HashPassword(password);
            return CompareOrdinal(hashInputPassword, hashedPassword) == 0;
        }

        public static string GetFileUploadPath(string fileName = null)
        {
            var uploadPath = ConfigurationManager.AppSettings["FileUploadPath"];
            return fileName == null ? ConfigurationManager.AppSettings["PlaceHolderPic"] : uploadPath + "/" + fileName;
        }

        public static QueryResult QuerySuccessResult(object result, int? entityCount = null)
        {
            return new QueryResult
            {
                Data = result,
                EntityCount = entityCount,
                IsSuccess = true
            };
        }

        public static QueryResult QueryResultList<T>(this IQueryable queryResult, QueryParamArg queryParamArg = null)
        {
            ValidateQueryParamArg(queryParamArg);
            var result = GetResult(queryResult, queryParamArg);
            return new QueryResult
            {
                Data = result.ProjectTo<T>().ToList(),
                EntityCount = queryParamArg == null ? 0 : queryParamArg.ShowEntityCount ? queryResult.Count() : 0,
                IsSuccess = true
            };
        }

        public static void ValidateQueryParamArg(QueryParamArg queryParamArg)
        {
            if (queryParamArg == null) return;
            if (queryParamArg.Pagination != null && IsNullOrEmpty(queryParamArg.SortDirection))
            {
                throw new InvalidOperationException("Sorting direction missing");
            }
            if (queryParamArg.Pagination != null && IsNullOrEmpty(queryParamArg.SortingColumnName))
            {
                throw new InvalidOperationException("Sorting column direction missing");

            }
        }

        private static IQueryable Paginate(IQueryable source, QueryParamArg queryParamArg)
        {
            if (queryParamArg?.Pagination == null)
            {
                return source;
            }
            return source.OrderBy(queryParamArg.SortingColumnName + " " + queryParamArg.SortDirection)
                .Skip(queryParamArg.Pagination.Page * queryParamArg.Pagination.PageSize)
                .Take(queryParamArg.Pagination.PageSize);
        }

        private static IQueryable GetResult(IQueryable source, QueryParamArg queryParamArg)
        {
            if (queryParamArg?.Pagination != null && !string.IsNullOrEmpty(queryParamArg.SortingColumnName) && !string.IsNullOrEmpty(queryParamArg.SortDirection))
            {
                return source.OrderBy(queryParamArg.SortingColumnName + " " + queryParamArg.SortDirection)
                    .Skip(queryParamArg.Pagination.Page * queryParamArg.Pagination.PageSize)
                    .Take(queryParamArg.Pagination.PageSize);
            }
            return string.IsNullOrEmpty(queryParamArg?.SortDirection) ? source : source.OrderBy(queryParamArg.SortingColumnName + " " + queryParamArg.SortDirection);

        }


        public static QueryResult QueryResultGet<T>(this IQueryable queryResult)
        {
            return new QueryResult
            {
                Data = queryResult.ProjectTo<T>().SingleOrDefault(),
                IsSuccess = true
            };
        }

        public static void SetDefaultSortColumn(this QueryParamArg queryParamArg, string defaultSortColumn = null)
        {
            if (!IsNullOrEmpty(queryParamArg.SortingColumnName)) return;
            {
                queryParamArg.SortDirection = "ASC";
                queryParamArg.SortingColumnName = IsNullOrEmpty(defaultSortColumn) ? "Description" : defaultSortColumn;
            }
        }

        public static QueryResult QueryErrorResult(object error)
        {
            return new QueryResult
            {
                ErrorMessage = error,
                IsSuccess = false
            };
        }

        public static string GenerateToken(string visitorId, string visitId)
        {
            var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = BitConverter.GetBytes(visitorId.Length);
            var id = BitConverter.GetBytes(visitId.Length);
            var data = new byte[time.Length + key.Length + id.Length];
            Buffer.BlockCopy(time, 0, data, 0, time.Length);
            Buffer.BlockCopy(key, 0, data, time.Length, key.Length);
            Buffer.BlockCopy(id, 0, data, time.Length + key.Length, id.Length);
            return Convert.ToBase64String(data.ToArray());
        }

        public static void ValidateToken(string visitorId, string visitId, string token)
        {
            var data = Convert.FromBase64String(token);
            var time = data.Take(8).ToArray();
            //var key = data.Skip(8)
        }
    }

    public class UtilityMethods
    {
        public byte[] ConvertImageToByteArray(string imageName)
        {
            var webRequest = WebRequest.Create(Utility.GetFileUploadPath(imageName));
            using (var webResponse = webRequest.GetResponse())
            {
                using (var responseStream = webResponse.GetResponseStream())
                {
                    var image = Image.FromStream(responseStream);
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return memoryStream.ToArray();
                    }
                }
            }
        }

        public Image ConvertByteArrayToImage(byte[] file)
        {
            using (var memoryStream = new MemoryStream(file))
            {
                var image = Image.FromStream(memoryStream);
                return image;
            }
        }

        public void SaveImage(byte[] imageFile, string fileName)
        {
            using (var memoryStream = new MemoryStream(imageFile))
            {
                var image = Image.FromStream(memoryStream);
                var ll = @"\" + fileName;
                image.Save(ll);
            }
            //string path = Path.Combine(@"~/Files", fileName);

            ////var webRequest = WebRequest.Create(imageFile);
            //var dd = System.Web.Hosting.HostingEnvironment.MapPath("~/app/assets/Uplodables");
            //var ll = @".\Files" + fileName;
            //System.IO.File.WriteAllBytes(ll+fileName, imageFile);
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("http://localhost:3330/assets/Uplodables/");
            //request.Method = WebRequestMethods.Ftp.UploadFile;


        }

        public void DelteImage(string fileName)
        {
            var filePath = Utility.GetFileUploadPath(fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

                //System.IO.File.
            }
        }

        public string GetPlaceHolderPic()
        {
            return ConfigurationManager.AppSettings["PlaceHolderPic"];
        }

        public static double CalculateBmI(double? height,double? weight)
        {
            if (height==null || weight==null)
            {
                return 0;
            }
            return (weight/height*height).Value;
        }

    }
}
