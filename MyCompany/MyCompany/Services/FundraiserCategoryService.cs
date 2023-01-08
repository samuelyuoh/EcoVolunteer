using MyCompany.Models;

namespace MyCompany.Services
{
    public class FundraiserCategoryService
    {
        private readonly MyDbContext _context;
        public FundraiserCategoryService(MyDbContext context)
        {
            _context = context;
        }
        //private static List<FundraiserCategory> AllCategories = new()
        //{                    
        //    new FundraiserCategory{ CategoryId = "BC", Name = "Beach Cleaning"},
        //    new FundraiserCategory{ CategoryId = "TP", Name = "Tree Planting"},
        //    new FundraiserCategory{ CategoryId = "WL", Name = "Wildlife"},
        //    new FundraiserCategory{ CategoryId = "RA", Name = "Raising Awareness"},
        //};

        public List<FundraiserCategory> GetAll()
        {
            return _context.FundraiserCategories.OrderBy(f => f.Name).ToList();
        }
        public FundraiserCategory? GetCategoryById(string id)
        {
            FundraiserCategory? category = _context.FundraiserCategories.FirstOrDefault(
            x => x.CategoryId.Equals(id));
            return category;
        }

    }

}
