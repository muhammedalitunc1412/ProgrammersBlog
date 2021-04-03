using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entities.Dtos
{
   public class CategoryDto:DtoGetBase
    {
        public Category Category { get; set; }
    }
}
