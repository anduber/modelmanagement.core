using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class CommonDataService:AppRepository
    {
        private ModelManagementContext _context;
        private EntityRepository<GeoType> _geoTypeRepository;
        private EntityRepository<Geo> _geoRepository;
        private EntityRepository<GeoAssoc> _geoAssocRepository;

        private readonly AppRepository _appRepository;

        public CommonDataService(ModelManagementContext context = null):base(context)
        {
            _context = context ?? new ModelManagementContext();
            _geoTypeRepository = new EntityRepository<GeoType>(_context);
            _geoRepository = new EntityRepository<Geo>(_context);
            _geoAssocRepository = new EntityRepository<GeoAssoc>(_context);
            //_appRepository = new AppRepository(_context);
            //Context = context;
        }

        public void CreateGeoTypes(List<GeoTypeArg> geoTypeArgs)
        {
            var geoTypes = geoTypeArgs.Select(geoType => new GeoType { GeoTypeId = geoType.GeoTypeId, Description = geoType.Description, GeoTypePurposeId = geoType.GeoTypePurposeId }).ToList();
            _geoTypeRepository.AddRange(geoTypes);
        }

        public void CreateGeos(List<GeoArg> geoArgs)
        {
            var geos = geoArgs.Select(geoArg => new Geo
            {
                GeoId = geoArg.GeoId ?? Utility.GetId(),
                GeoTypeId = geoArg.GeoTypeId,
                GeoName = geoArg.GeoName,
                GeoCode = geoArg.GeoCode,
                DialingCode = geoArg.DialingCode
            }).ToList();
            Geo().AddRange(geos);
            #region UpdateDialing
            //var geo = new List<Geo>();
            //foreach (var geoArg in geoArgs)
            //{
            //    var ll = _geoRepository.FirstOrDefault(t => t.GeoCode == geoArg.GeoCode && t.GeoTypeId == "COUNTRY");
            //    if(ll!=null)
            //    {
            //        ll.DialingCode = geoArg.DialingCode;
            //        _geoRepository.UpdateEntity(ll);
            //    }
            //} 
            #endregion
        }

        public void CreateGeoAssoces(List<GeoAssocArg> geoAssocArgs)
        {
            var geoAssoces = new List<GeoAssoc>();
            geoAssocArgs.ForEach(t => geoAssoces
                .Add(new GeoAssoc
                {
                    GeoId = t.GeoId,
                    GeoIdTo = t.GeoIdTo,
                    GeoAssocTypeId = t.GeoAssocTypeId
                }));
            _geoAssocRepository.AddRange(geoAssoces);
        }

        public CommandResult CreateOfferType(string sequence, string description, string longDescription, int? validNoOfDays, decimal? feeAmount, string userLoginId)
        {
            var offerType = new OfferType
            {
                OfferTypeId = Utility.GetId(),
                Sequence = sequence,
                Description = description,
                LongDescription = longDescription,
                ValidNoOfDays = validNoOfDays,
                FeeAmount = feeAmount,
                IsActive = "Y",
                UserLoginId = userLoginId
            };
            _appRepository.OfferType().Create(offerType);
            return Utility.CommandSuccess(offerType.OfferTypeId);
        }

        public CommandResult UpdateOfferType(string offerTypeId, string sequence, string description, string longDescription, int? validNoOfDays, decimal? feeAmount, string userLoginId)
        {
            var offerType = _appRepository.OfferType().Find(t => t.OfferTypeId == offerTypeId);
            offerType.Sequence = sequence;
            offerType.Description = description;
            offerType.LongDescription = longDescription;
            offerType.ValidNoOfDays = validNoOfDays;
            offerType.FeeAmount = feeAmount;
            offerType.UserLoginId = userLoginId;
            _appRepository.OfferType().Update(offerType);
            return Utility.CommandSuccess();
        }

        public CommandResult RemoveOfferType(string offerTypeId, bool delete)
        {
            var offerType = _appRepository.OfferType().Find(t => t.OfferTypeId == offerTypeId);
            if (delete)
            {
                _appRepository.OfferType().Delete(offerType);
            }
            else
            {
                offerType.IsActive = "N";
                _appRepository.OfferType().Update(offerType);
            }
            return Utility.CommandSuccess();
        }

        public CommandResult CreateOfferItemType(string sequence, string description, string offerTypeId, string userLoginId)
        {
            var offerItemType = new OfferItemType
            {
                OfferItemTypeId = Utility.GetId(),
                Description = description,
                Sequence = sequence,
                UserLoginId = userLoginId,
                IsActive = "Y"
            };
            _appRepository.OfferItemType().Add(offerItemType);
            if (!string.IsNullOrEmpty(offerTypeId))
            {
                _appRepository.OfferItemTypeMap().Add(SetOfferItemTypeMap(offerTypeId, offerItemType.OfferItemTypeId, userLoginId));
            }
            return Utility.CommandSuccess(offerItemType.OfferItemTypeId);
        }

        private static OfferItemTypeMap SetOfferItemTypeMap(string offerTypeId, string offerItemTypeId, string userLoginId)
        {
            return new OfferItemTypeMap
            {
                OfferTypeId = offerTypeId,
                OfferItemTypeId = offerItemTypeId,
                UserLoginId = userLoginId
            };
        }

        public CommandResult UpdateOfferItemType(string offerItemTypeId, string sequence, string description, string userLoginId)
        {
            var offerItemType = _appRepository.OfferItemType().Find(t => t.OfferItemTypeId == offerItemTypeId);
            offerItemType.Description = description;
            offerItemType.Sequence = sequence;
            offerItemType.UserLoginId = userLoginId;
            _appRepository.OfferItemType().Update(offerItemType);
            return Utility.CommandSuccess();
        }

        public CommandResult AddOfferItemTypeMap(string offerTypeId, string offerItemTypeId, string userLoginId)
        {
            _appRepository.OfferItemTypeMap().Create(SetOfferItemTypeMap(offerTypeId, offerItemTypeId, userLoginId));
            return Utility.CommandSuccess();
        }

        public CommandResult RemoveOfferItemTypeMap(string offerTypeId, string offerItemTypeId)
        {
            var offerItemTypeMap =
                _appRepository.OfferItemTypeMap()
                    .Find(t => t.OfferItemTypeId == offerItemTypeId && t.OfferTypeId == offerTypeId);
            _appRepository.OfferItemTypeMap().Delete(offerItemTypeMap);
            return Utility.CommandSuccess();
        }

        public CommandResult CreateEnumerationType(string enumerationTypeId, string description, string userLoginId)
        {
            var enumerationType = new EnumerationType
            {
                EnumerationTypeId = string.IsNullOrEmpty(enumerationTypeId) ? Utility.GetId() : enumerationTypeId,
                Description = description,
                UserLoginId = userLoginId
            };
            _appRepository.EnumerationType().Create(enumerationType);
            return Utility.CommandSuccess();
        }

        public CommandResult UpdateEnumerationType(string enumerationTypeId, string description)
        {
            var enumType = _appRepository.EnumerationType().Find(enumerationTypeId);
            enumType.Description = description;
            _appRepository.EnumerationType().Update(enumType);
            return Utility.CommandSuccess();
        }

        public CommandResult RemoveEnumerationType(string enumerationTypeId)
        {
            var enumType = _appRepository.EnumerationType().Find(enumerationTypeId);
            _appRepository.EnumerationType().Delete(enumType);
            return Utility.CommandSuccess();
        }

        public CommandResult CreateEnumeration(string enumerationId, string enumerationTypeId, string description, string userLoginId)
        {
            var enumeration = new Enumeration
            {
                EnumerationId = string.IsNullOrEmpty(enumerationId) ? Utility.GetId() : enumerationId,
                EnumerationTypeId = enumerationTypeId,
                Description = description,
                UserLoginId = userLoginId
            };
            _appRepository.Enumeration().Create(enumeration);
            return Utility.CommandSuccess(enumeration.EnumerationId);
        }

        public CommandResult UpdateEnumeration(string enumerationId, string enumerationTypeId, string description, string userLoginId)
        {
            var enumeration = _appRepository.Enumeration().Find(enumerationId);
            enumeration.EnumerationTypeId = enumerationTypeId;
            enumeration.Description = description;
            _appRepository.Enumeration().Update(enumeration);
            return Utility.CommandSuccess();
        }

        public CommandResult RemoveEnumeration(string enumerationId)
        {
            _appRepository.Enumeration().Delete(enumerationId);
            return Utility.CommandSuccess();
        }

        public CommandResult CreateGeoType(string geoTypeId, string description, string geoTypePurposeId, string userLoginId)
        {
            var result = GeoType().Create(SetGeoType(geoTypeId, description, geoTypePurposeId, userLoginId));
            return Utility.CommandSuccess(result.GeoTypeId);
        }

        public CommandResult UpdateGeoType(string geoTypeId, string description, string geoTypePurposeId, string userLoginId)
        {
            var geoType = _appRepository.GeoType().Find(geoTypeId);
            _appRepository.GeoType().Update(SetGeoType(geoTypeId, description, geoTypePurposeId, userLoginId, geoType));
            return Utility.CommandSuccess();
        }

        public CommandResult RemoveGeoType(string geoTypeId)
        {
            _appRepository.GeoType().Delete(geoTypeId);
            return Utility.CommandSuccess();
        }

        private static GeoType SetGeoType(string geoTypeId, string description, string geoTypePurposeId, string userLoginId, GeoType geoType = null)
        {
            if (geoType == null)
            {
                geoType = new GeoType
                {
                    GeoTypeId = string.IsNullOrEmpty(geoTypeId) ? Utility.GetId() : geoTypeId,
                };

            }
            geoType.Description = description;
            geoType.GeoTypePurposeId = geoTypePurposeId;
            geoType.UserLoginId = userLoginId;
            return geoType;
        }

        public CommandResult CreateGeo(string geoId, string geoTypeId, string geoName, string geoCode, string dialingCode, string userLoginId)
        {
            var geo = _appRepository.Geo().Create(SetGeo(geoId,geoTypeId,geoName,geoCode,dialingCode,userLoginId));
            return Utility.CommandSuccess(geo.GeoId);
        }

        public CommandResult UpdateGeo(string geoId, string geoTypeId, string geoName, string geoCode, string dialingCode, string userLoginId)
        {
            var geo = _appRepository.Geo().Find(geoId);
            _appRepository.Geo().Update(SetGeo(geoId, geoTypeId, geoName, geoCode, dialingCode, userLoginId,geo));
            return Utility.CommandSuccess();
        }

        public CommandResult RemoveGeo(string geoId)
        {
            _appRepository.Geo().Delete(geoId);
            return Utility.CommandSuccess();
        }

        private static Geo SetGeo(string geoId, string geoTypeId, string geoName, string geoCode, string dialingCode, string userLoginId,Geo geo=null)
        {
            if (geo==null)
            {
                geo = new Geo
                {
                    GeoId = string.IsNullOrEmpty(geoId)?Utility.GetId():geoId
                };
            }
            geo.GeoTypeId = geoTypeId;
            geo.GeoName = geoName;
            geo.GeoCode = geoCode;
            geo.DialingCode = dialingCode;
            geo.UserLoginId = userLoginId;
            return geo;
        }


        public CommandResult SendEmail(string emailFrom,string password,string emailTo,string subject,string messageBody)
        {
            var mailMessage = new MailMessage();
            var smtpServer = new SmtpClient("smtp.gmail.com") {UseDefaultCredentials = false};


            mailMessage.From = new MailAddress(emailFrom);
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = subject;
            mailMessage.Body = messageBody;

            smtpServer.Port = 587;
           
            smtpServer.Credentials = new System.Net.NetworkCredential(emailFrom, password);
            smtpServer.EnableSsl = true;

            smtpServer.Send(mailMessage);
            return Utility.CommandSuccess();
        }

        public CommandResult SendActivationCodeViaEmail(User user,string userName)
        {
            var emailAdmin = UserLogin().Find(Utility.Users.EmailAdminUserLoginId);
            var emailSubject = "Verification Code";
            var messageBody = userName + " This is your verification code" + user.VerificationCode + "\n Got to http://localhost:4200/#/apps/verify-account" + "\n to verify your account." ;
            SendEmail(emailAdmin.User_PersonId.PrimaryEmail,emailAdmin.CurrentPassword,user.PrimaryEmail,emailSubject,messageBody);
            return Utility.CommandSuccess();
        }

        public AdminUserEmail GetAdminEmail()
        {
            var adminUser = User().FirstOrDefault(t => t.PersonId == Utility.Users.EmailAdminUserId);
            var adminEmail = new AdminUserEmail
            {
                EmailId = adminUser?.PrimaryEmail,
                Password = adminUser?.User_UserLogin.FirstOrDefault(t=>t.UserLoginId==Utility.Users.EmailAdminUserLoginId)?.CurrentPassword
            };
            return adminEmail;
        }
    }
}
