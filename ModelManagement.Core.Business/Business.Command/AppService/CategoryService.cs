using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class CategoryService:AppRepository
    {
        private ModelManagementContext _context;
        //private EntityRepository<Category> _categotyRepo;

        private AppRepository _appRepository;

        public CategoryService(ModelManagementContext context = null):base(context)
        {
            //_context = context ?? new ModelManagementContext();
            //_categotyRepo = new EntityRepository<Category>(context);
            var appContext = context ?? new ModelManagementContext();
            _appRepository = new AppRepository(appContext);
        }

        public List<Category> CreateCategories(List<string> categoryTypeIds, string personId, string userLoginId)
        {
            var categories = SetCategories(categoryTypeIds, personId, userLoginId);
            Category().AddRange(categories);
            return categories;
        }

        public List<Category> UpdateCategories(List<string> categoryTypeIds, string personId, string userLoginId)
        {
            List<Category> categories;            
            var personCategories = Category().Filter(t => t.PersonId == personId).ToList();
            if (personCategories.Any())
            {
                foreach (var item in personCategories)
                {
                    Category().Remove(item);
                }
                categories = SetCategories(categoryTypeIds, personId, userLoginId);
                Category().AddRange(categories);
            }
            else
            {
                categories = SetCategories(categoryTypeIds, personId, userLoginId);
                Category().AddRange(categories);
            }
            return categories;
        }

        private List<Category> SetCategories(List<string> categoryTypeIds, string personId, string userLoginId)
        {
            return categoryTypeIds.Select(categoryTypeId => new Category()
            {
                PersonId = personId, CategoryTypeId = categoryTypeId, UserLoginId = userLoginId
            }).ToList();
        }
    }
}
