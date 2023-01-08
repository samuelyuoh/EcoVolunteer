using MyCompany.Models;

namespace MyCompany.Services
{
    public class FundraiserService
    {
        private readonly MyDbContext _context;
        public FundraiserService(MyDbContext context)
        {
            _context = context;
        }
        //private static List<FundraiserInfo> AllFundraisers = new()
        //{
        //    new FundraiserInfo {FundraiserName = "This is my first fundraiser", Reason = "This is a test", StartingGoal = 10000, StartDate = DateTime.Parse("1/1/2023"), EndDate = DateTime.Parse("11/11/2023"), CategoryId = "WL" ,Description = "This is a fundraiser aiming at raising money for animals nearing extinction....."},
        //    new FundraiserInfo {FundraiserName = "This is my second fundraiser", Reason = "This is a second test", StartingGoal = 5000, StartDate = DateTime.Parse("1/1/2022"), EndDate = DateTime.Parse("1/11/2023"), CategoryId = "BC" ,Description = "This is a fundraiser aiming at raising money to keep our beaches clean....."},
        //    //new FundraiserInfo {FundraiserName = "This is my third fundraiser", Reason = "This is a third test", StartingGoal = 23000, StartDate = DateOnly.Parse("12/3/2019"), EndDate = DateOnly.Parse("9/11/2022"), CategoryId = "TP" ,Description = "This is a fundraiser aiming at raising money to help plant more trees....."},
        //};
        public List<FundraiserInfo> GetAll()
        {
            return _context.FundraiserInfo.OrderBy(m => m.FundraiserName).ToList();
        }
        public FundraiserInfo? GetFundraiserById(string id)
        {
            FundraiserInfo? fundraiser = _context.FundraiserInfo.FirstOrDefault(
            x => x.FundraiserId.Equals(id));
            return fundraiser;
        }

        public void AddFundraiser(FundraiserInfo fundraiser)
        {
            _context.FundraiserInfo.Add(fundraiser);
            _context.SaveChanges();
        }
        public void UpdateFundraiser(FundraiserInfo fundraiser)
        {
            _context.FundraiserInfo.Update(fundraiser);
            _context.SaveChanges();
        }
    }
}
