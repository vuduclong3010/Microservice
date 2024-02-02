using AutoMapper;
using Newtonsoft.Json.Linq;
using ProjectServiceB.Models;

namespace ProjectServiceB.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // Add as many of these lines as you need to map your objects
            var productMap = CreateMap<JObject, Product>();
            productMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["id"]));
            productMap.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"]));
            productMap.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["description"]));
            productMap.ForMember(dest => dest.Node, opt => opt.MapFrom(src => src["node"]));
            productMap.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src["price"]));
            productMap.ForMember(dest => dest.Qty, opt => opt.MapFrom(src => src["qty"]));
            productMap.ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src["isDelete"]));

            var orderMap = CreateMap<JObject, Order>();
            orderMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["id"]));
            orderMap.ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src["orderDate"]));
            orderMap.ForMember(dest => dest.TotalMoney, opt => opt.MapFrom(src => src["totalMoney"]));
            orderMap.ForMember(dest => dest.Node, opt => opt.MapFrom(src => src["node"]));
            orderMap.ForMember(dest => dest.NameReciver, opt => opt.MapFrom(src => src["nameReciver"]));
            orderMap.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src["address"]));
            orderMap.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src["email"]));
            orderMap.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src["phone"]));
            orderMap.ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => src["isDelete"]));
            orderMap.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src["isActive"]));
            orderMap.ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src["customerId"]));

            var customerMap = CreateMap<JObject, Customer>();
            customerMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["id"]));
            customerMap.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"]));
            customerMap.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src["address"]));
            customerMap.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src["email"]));
            customerMap.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src["phoneNumber"]));
            customerMap.ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src["avatar"]));
            customerMap.ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src["isDeleted"]));

            var orderDetail = CreateMap<JObject, OrderDetail>();
            orderDetail.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["id"]));
            orderDetail.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src["price"]));
            orderDetail.ForMember(dest => dest.Qty, opt => opt.MapFrom(src => src["qty"]));
            orderDetail.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src["total"]));
            orderDetail.ForMember(dest => dest.ReturnQty, opt => opt.MapFrom(src => src["returnQty"]));
            orderDetail.ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src["idProduct"]));
            orderDetail.ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src["orderId"]));
        }
    }
}
