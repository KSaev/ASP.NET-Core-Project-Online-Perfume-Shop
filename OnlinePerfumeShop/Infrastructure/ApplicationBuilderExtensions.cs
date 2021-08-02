using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Data.Models;
using System;

namespace OnlinePerfumeShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
             this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedBrands(services);
            SeedPerfumes(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlinePerfumeShopDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlinePerfumeShopDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "мъжки" },
                new Category { Name = "женски" },
             
            });

            data.SaveChanges();
        }

        private static void SeedBrands(IServiceProvider services) 
        {
            var data = services.GetRequiredService<OnlinePerfumeShopDbContext>();

            if (data.Brands.Any())
            {
                return;
            }

            data.Brands.AddRange(new[]
            {
                new Brand{ Name= "Savage" },
                new Brand{ Name= "Hugo Boss" },
                new Brand{ Name= "Versace" }
            });

            data.SaveChanges();
        }

        private static void SeedPerfumes(IServiceProvider services) 
        {
            var data = services.GetRequiredService<OnlinePerfumeShopDbContext>();

            if (data.Perfumes.Count() > 12)
            {
                return;
            }

            data.Perfumes.AddRange(new[]
            {
                new Perfume{ 
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{ 
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200
                    
                },new Perfume{ 
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                   new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                   new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                   new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                   new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                   new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 100
                },new Perfume{
                    Name = "Versace Eros"
                    ,Desctription = "Бъдете чувствен като гръцкия бог на любовта Ерос. Тоалетната вода за мъже Versace Eros е съвършено въплъщение на мощ и страст. Ароматната ѝ композиция символизира любовта и копнежа и сякаш е създадена за силния и уверен в себе си мъж, който знае какво иска. Тайнствените нотки на аромата ще грабнат всекиго, а едно е сигурно – жените около вас няма да пропуснат присъствието ви."
                    ,ImageUrl = "https://i.imgur.com/EbSw8mR.jpg"
                    ,Price = 129.00M
                    ,BrandId = 3
                    ,CategoryId = 1
                    ,Qunatity = 200

                },new Perfume{
                    Name = "Hugo Boss Deep Red"
                    ,Desctription = "Hugo Boss Deep Red е дамски парфюм е предназначен за силните и активни жени. Представен е на пазара 2001г. Създаден е от парфюмеристите Alain Astori, Beatrice Piquet. Привлекателен и отблъскващ, дразнещ и възбуждащ, но никога незабележим аромат. Съблазнителната и възбуждаща ароматна аура, ще ви зареди с невероятно настроение и усещане за неповторима уникалност."
                    ,ImageUrl = "https://i.imgur.com/13e6KTB.jpg"
                    ,Price = 49.99M
                    ,BrandId = 2
                    ,CategoryId = 2
                    ,Qunatity = 50
                },

            });

            data.SaveChanges();
        }
    }
}
