using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entities.Concrete
{
   public class Role:IdentityRole<int>  //int mevzusu primary keyleri int olarak tanımlanmasını istedik
    {
    }
}
