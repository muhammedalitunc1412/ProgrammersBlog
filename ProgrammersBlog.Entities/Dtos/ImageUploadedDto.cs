using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Entities.Dtos
{
   public class ImageUploadedDto
    {
        public string FullName  { get; set; }
        public string OldName { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string FolderName { get; set; }
        public long Size { get; set; }
    }
}
