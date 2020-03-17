using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class CategoryService
    {
        private ModelManagementContext _context;
        private EntityRepository<Category> _categotyRepo;

        public CategoryService(ModelManagementContext context = null)
        {
            _context = context ?? new ModelManagementContext();
            _categotyRepo = new EntityRepository<Category>(context);
        }

        public List<Category> CreateCategories(List<string> categoryTypeIds, string personId, string userLoginId)
        {
            var _categories = SetCategories(categoryTypeIds, personId, userLoginId);
            _categotyRepo.AddRange(_categories);
            return _categories;
        }

        public List<Category> UpdateCategories(List<string> categoryTypeIds, string personId, string userLoginId)
        {
            var _categories = new List<Category>();

            var personCategories = _categotyRepo.Filter(t => t.PersonId == personId).ToList();
            if(personCategories.Any())
            {
                foreach (var item in personCategories)
                {
                    _categotyRepo.Remove(item);
                }
                _categories = SetCategories(categoryTypeIds, personId, userLoginId);
                _categotyRepo.AddRange(_categories);

            }
            else
            {
                _categories = SetCategories(categoryTypeIds, personId, userLoginId);
                _categotyRepo.AddRange(_categories);
            }
            return _categories;
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
