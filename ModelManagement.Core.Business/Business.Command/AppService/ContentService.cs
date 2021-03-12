using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class ContentService : AppRepository
    {
        //private ModelManagementContext _context;
        private EntityRepository<Uploadable> _uplodableRepository;
        private ObjectMapper _mapper;
        private AppRepository _appRepository;
        public ContentService(ModelManagementContext context = null) : base(context)
        {
            var appContext = context ?? new ModelManagementContext();
            _appRepository = new AppRepository(appContext);
            //_uplodableRepository = new EntityRepository<Uploadable>(_context);
            _mapper = new ObjectMapper();
        }

        public Uploadable CreateUplodable(UploadableArg uplodableArg, string personId, string userLoginId)
        {
            var uplodable = SetUplodable(uplodableArg, personId, userLoginId);
            _uplodableRepository.Create(uplodable);
            return uplodable;
        }

        public Uploadable SaveUplodable(UploadableArg uplodableArg, string personId, string userLoginId)
        {
            var fileUplodable = _uplodableRepository.FirstOrDefault(t => t.FileUploadId == uplodableArg.FileUploadId);
            if (fileUplodable == null)
            {
                fileUplodable = SetUplodable(uplodableArg, personId, userLoginId);
                _uplodableRepository.Add(fileUplodable);
            }
            else
            {
                fileUplodable.FileData = uplodableArg.File;
                fileUplodable = _uplodableRepository.UpdateEntity(fileUplodable);
            }
            return fileUplodable;
        }

        public Uploadable SetUplodable(UploadableArg uplodableArg, string personId, string userLoginId, string fileUploadId = null)
        {
            return new Uploadable
            {
                PersonId = personId,
                UserLoginId = userLoginId,
                FileUploadId = string.IsNullOrEmpty(fileUploadId) ? Utility.GetId() : fileUploadId,
                FileData = uplodableArg.File,
                FileName = Utility.GetFileName(),
                FileTypeId = uplodableArg.FileTypeId,
                MimeTypeId = uplodableArg.MimeTypeId
            };
        }

        public void SaveImages(List<UploadableArg> uplodableArgs, List<string> fileNames)
        {
            for (var i = 0; i < uplodableArgs.Count; i++)
            {
                new UtilityMethods().SaveImage(uplodableArgs[i].File, fileNames[i]);
            }
        }

        public void RemoveUplodable(string fileUploadId)
        {
            _uplodableRepository.Delete(_uplodableRepository.FirstOrDefault(t => t.FileUploadId == fileUploadId));
        }

        public void AddAUploadables(List<UploadableArg> uploadableArgs, string personId, string userLoginId)
        {
            foreach (var uploadableArg in uploadableArgs)
            {
                AddUploadable(uploadableArg, personId, userLoginId);
            }
        }

        private Uploadable AddUploadable(UploadableArg uploadableArg, string personId, string userLoginId)
        {
            var uploadable = SetUplodable(uploadableArg, personId, userLoginId);
            Uploadable().Add(uploadable);
            return uploadable;
        }

        public void AddContents(List<ContentArg> contentArgs, string userId, string userLoginId)
        {
            foreach (var content in contentArgs)
            {
                AddContent(content, userId, userLoginId);
            }
        }

        public Content AddContent(ContentArg contentArg, string userId, string userLoginId)
        {
            var content = SetContentProperty(contentArg, userId, userLoginId);
            content.ContentId = Utility.GetId();
            Content().Add(content);
            AddContentData(content.ContentId, contentArg.Data, userLoginId);
            return content;
        }

        public Content SetContentProperty(ContentArg contentArg, string userId, string userLoginId)
        {
            return new Content
            {
                ContentDescription = contentArg.ContentDescription,
                ContentTypeId = contentArg.ContentTypeId,
                ContentUserId = userId,
                ContentName = contentArg.ContentName,
                MimeTypeId = contentArg.MimeTypeId,
                UserLoginId = userLoginId
            };
        }

        public void AddContentData(string contentId, byte[] data, string userLoginId)
        {
            var contentData = new ContentData
            {
                ContentId = contentId,
                Data = data,
                UserLoginId = userLoginId,
                //LastUpdatedByUserLoginId = userLoginId
            };
            ContentData().Add(contentData);
        }

        public void RemoveContent(string contentId)
        {
            var content = Content().Find(contentId);
            var contentData = ContentData().Find(contentId);
            Content().Remove(content);
            if (contentData!=null)
            {
                ContentData().Remove(contentData);
            }
        }

        public void SetProfilePicture(string userId,string contentId)
        {
            var userContents = Content().Filter(t => t.ContentUserId == userId);
            foreach (var content in userContents)
            {
                content.ContentTypeId = content.ContentId==contentId ? Utility.ContentTypeProfilePic : Utility.HeaderPic;
                Content().UpdateEntity(content);
            }
        }


    }
}
