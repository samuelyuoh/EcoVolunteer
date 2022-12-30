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
        public void CreateCart(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }

        public void AddToCart(int id)
        {
            Cart? cart = _dbContext.Carts.FirstOrDefault(
            x => x.UserId.Equals(id));
            if(cart == null)
            {
                Cart MyCart = new();
                MyCart.UserId = 1;
                MyCart.Total = 0;
                CreateCart(MyCart);
                AddToCart(id);
            }
            else
            {
                CartItem cartItem = new();
                cartItem.CartId = cart.CartId;
                cartItem.ProductId = 2;
                cartItem.Quantity = 1;
                _dbContext.ItemInCart.Add(cartItem);
                _dbContext.SaveChanges();
            }
        }
        public void removeAllItems(int id)
        {
            Cart? cart = _dbContext.Carts.FirstOrDefault(
                x=> x.UserId.Equals(id));
            var itemToRemove = _dbContext.ItemInCart.FirstOrDefault(x=>x.CartId.Equals(cart.CartId));
            do
            {
                if(itemToRemove != null)
                {
                    _dbContext.ItemInCart.Remove(itemToRemove);
                    _dbContext.SaveChanges();
                }
                itemToRemove = _dbContext.ItemInCart.FirstOrDefault(x => x.CartId.Equals(cart.CartId));
            } while (itemToRemove != null);
        }
    }
}
