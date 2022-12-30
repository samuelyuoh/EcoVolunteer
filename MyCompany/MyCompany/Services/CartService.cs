using MyCompany.Models;

namespace MyCompany.Services
{
    public class CartService
    {
        private readonly MyDbContext _dbContext;
        public CartService(MyDbContext myDBContext)
        {
            _dbContext = myDBContext;
        }
        public List<Cart> GetAll()
        {
            //to sort the list by lambda expression
            return _dbContext.Carts.OrderBy(d => d.UserId).ToList();
        }
        public Cart? GetCartById(int id)
        {
            // FirstOrDefault could be null
            Cart? cart = _dbContext.Carts.FirstOrDefault(
            x => x.UserId.Equals(id));
            return cart;
        }
        public void AddCart(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }
    }
}
