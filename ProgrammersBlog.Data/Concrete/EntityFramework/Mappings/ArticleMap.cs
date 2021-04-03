﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);  //Id alanını primary key yaptık
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); //teker teker ıd alanının artmasını sağlıyo
            builder.Property(a => a.Title).HasMaxLength(50);
            builder.Property(a => a.Title).IsRequired(true); //title zorunlu oldu
            builder.Property(a => a.Content).IsRequired(true);
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)"); //alabildiği kadar content yazı alabilir
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c=>c.Articles).HasForeignKey(a=>a.CategoryId); //her article bir kategoriye bağlı olmak zorunda (bire çok)
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);
          builder.ToTable("Articles"); 

            //builder.HasData(
                //new Article
                //{
                //    Id = 1,
                //    CategoryId = 1,
                //    Title = "C# 9.0 ve .NET 5 Yenilikleri",
                //    Content =
                //        "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                //    Thumbnail = "Default.jpg",
                //    SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri",
                //    SeoTags = "C#, C# 9, .NET5, .NET Framework, .NET Core",
                //    SeoAuthor = "Muhammed Ali Tunç",
                //    Date = DateTime.Now,
                //    IsActive = true,
                //    IsDeleted = false,
                //    CreatedByName = "InitialCreate",
                //    CreatedDate = DateTime.Now,
                //    ModifiedByName = "InitialCreate",
                //    ModifiedDate = DateTime.Now,
                //    Note = "C# 9.0 ve .NET 5 Yenilikleri",
                //    UserId = 1,
                //    ViewsCount = 100,
                //    CommentCount = 1
                //},
                //new Article
                //{
                //    Id = 2,
                //    CategoryId = 2,
                //    Title = "C++ 11 ve 19 Yenilikleri",
                //    Content =
                //        "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                //    Thumbnail = "Default.jpg",
                //    SeoDescription = "C++ 11 ve 19 Yenilikleri",
                //    SeoTags = "C++ 11 ve 19 Yenilikleri",
                //    SeoAuthor = "Muhammed Ali Tunç",
                //    Date = DateTime.Now,
                //    IsActive = true,
                //    IsDeleted = false,
                //    CreatedByName = "InitialCreate",
                //    CreatedDate = DateTime.Now,
                //    ModifiedByName = "InitialCreate",
                //    ModifiedDate = DateTime.Now,
                //    Note = "C++ 11 ve 19 Yenilikleri",
                //    UserId = 1,
                //    ViewsCount = 295,
                //    CommentCount = 1
                //},
                //new Article
                //{
                //    Id = 3,
                //    CategoryId = 3,
                //    Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
                //    Content =
                //        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                //    Thumbnail = "Default.jpg",
                //    SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
                //    SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
                //    SeoAuthor = "Muhammed Ali Tunç",
                //    Date = DateTime.Now,
                //    IsActive = true,
                //    IsDeleted = false,
                //    CreatedByName = "InitialCreate",
                //    CreatedDate = DateTime.Now,
                //    ModifiedByName = "InitialCreate",
                //    ModifiedDate = DateTime.Now,
                //    Note = "JavaScript ES2019 ve ES2020 Yenilikleri",
                //    UserId = 1,
                //    ViewsCount = 12,
                //    CommentCount = 1
                //}
         //   );
        }
    }
}
