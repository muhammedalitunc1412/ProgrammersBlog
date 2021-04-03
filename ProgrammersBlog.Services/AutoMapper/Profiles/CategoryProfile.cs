using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
   public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));  //CategoryAddDto kısmına CreatedDate ekleyerek Formember kodunu yazmamıza gerek kalmazdı ama adam öğretmek için bunu yaptı
            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Category,CategoryUpdateDto>();

        }
    }
}
