using AutoMapper;
using WebApiStart.Model;

namespace WebApiStart.Migrations
{
    public class BookMappingProfile: Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookModel>();
        }
    }
}
