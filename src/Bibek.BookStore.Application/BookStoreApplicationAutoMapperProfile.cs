using AutoMapper;
using Bibek.BookStore.DTO;
using Bibek.BookStore.Model;

namespace Bibek.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<ClientDTO, Client>().ReverseMap(); 
        CreateMap<BookDTO, Book>().ReverseMap();   
        CreateMap<ClientBookDTO,Book>().ReverseMap();    
    }
}
