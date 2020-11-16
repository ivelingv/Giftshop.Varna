using AutoMapper;
using Giftshop.Varna.Database.Models;

namespace Giftshop.Varna.Models.Profiles
{
    public class GiftshopProfiles : Profile
    {
        public GiftshopProfiles()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<UserAddress, UserAddressModel>();
            CreateMap<UserAddressModel, UserAddress>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();

            CreateMap<ShoppingCartProduct, ShoppingCartProductModel>();
            CreateMap<ShoppingCartProductModel, ShoppingCartProduct>();

            CreateMap<ShoppingCart, ShoppingCartModel>();
            CreateMap<ShoppingCartModel, ShoppingCart>();
        }
    }
}
