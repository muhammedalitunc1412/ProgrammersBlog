using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Data.Abstract
{
   public interface IArticleRepository:IEntityRepository<Article>
    {
        
    }
}
