using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Command.CommandArgs;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class FileUploadService:AppRepository
    {
        private ModelManagementContext _context;
        private EntityRepository<Uploadable> _uplodableRepository;
        private ObjectMapper _mapper;
        public FileUploadService(ModelManagementContext context = null):base(context)
        {
            _context = context ?? new ModelManagementContext();
            //_uplodableRepository = new EntityRepository<Uploadable>(_context);
            _mapper = new ObjectMapper();
        }

        public Uploadable CreateUplodable(UploadableArg uplodableArg, string personId, string userLoginId)
        {
            var _uplodable = SetUplodable(uplodableArg, personId, userLoginId);
            _uplodableRepository.Create(_uplodable);
            return _uplodable;
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

        public void AddAUploadables(List<UploadableArg> uploadableArgs,string personId,string userLoginId)
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



    }
}
