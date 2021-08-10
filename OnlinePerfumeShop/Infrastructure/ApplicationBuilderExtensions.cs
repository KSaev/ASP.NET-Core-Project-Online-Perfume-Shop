using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlinePerfumeShop.Data;
using OnlinePerfumeShop.Data.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

using static OnlinePerfumeShop.Area.Admin.AdminConstants;


namespace OnlinePerfumeShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {        public static IApplicationBuilder PrepareDatabase(
             this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedBrands(services);
            SeedPerfumes(services);
            SeedAdministrator(services);

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
                new Brand{ Name= "Christian Dior" },
                new Brand{ Name= "Hugo Boss" },
                new Brand{ Name= "Versace" },
                new Brand{ Name = "Calvin Klein"},
                new Brand{ Name = "Antonio Banderas"},
                new Brand{ Name = "Guess"},
                new Brand{ Name = "Dolce & Gabbana"},
                new Brand{ Name = "Ariana Grande"},
                new Brand{ Name = "Armani"},
                new Brand{ Name = "Gucci"},
            });

            data.SaveChanges();
        }

        private static void SeedPerfumes(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlinePerfumeShopDbContext>();

            if (data.Perfumes.Any())
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
                    ,BrandId = 2
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
                    ,BrandId = 1
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "Calvin Klein In2U"
                    ,Desctription = "Calvin Klein In2U e модерен аромат насочен към младото поколение, създаден да изрази свободната воля и желанието на младите хора да изследват и опознават света.  Усеща духа и  настроението на енергичните млади мъже и жени. Представен на пазара 2007г. Свеж, динамичен, чист и тонизиращ. Прекрасно предложени за топлите месеци, ваканциите и забавленията с приятели на открито. Ароматният състав е разработен от уникален екип парфюмеристи - Bruno Jovanovic , Jean-Marc Chaillan , Loc Dong и Carlos Benaim.  Calvin Klein In2U е представен на пазара за първи път през 2007 година."
                    ,ImageUrl = "https://i.imgur.com/NgWSnk9.jpg"
                    ,Price = 41.99M
                    ,BrandId = 4
                    ,CategoryId = 2
                    ,Qunatity = 100
                },
                 new Perfume{
                    Name = "Hugo Boss Bottled Nigh"
                    ,Desctription = "Hugo Boss Bottled Night EDT е дървесен аромат за мъже лансиран на пазара през юли 2010 година. За младия, амбициозен, модерен мъж, който преследва целите си. Той е уверен в своите способности и знае, че всяка цел е постижима и всичко е възможно! Успехът е на една ръка разстояние от Вас! Съблазнителен и много мъжествен аромат, подчертаващ сила и чувственост. Не по-малко харизматича е бутилката - флакон, оцветен в наситени, тъмносини нюанси, обрисуващи загадачността на нощта. Неговият елегантен и благороден блясък разкрива на своя собственик тайните на прелъстяването, подготвя го за приключенията, съпътстващи тъмната част на денонощието. "
                    ,ImageUrl = "https://i.imgur.com/NgWSnk9.jpg"
                    ,Price = 59.99M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 50
                },
                new Perfume{
                    Name = "Calvin Klein Encounter парфюм за мъже"
                    ,Desctription = "Calvin Klein Encounter e мистериозен, мъжествен и съблазнително секси аромат, представен на пазара през 2012 година. Разработка е на парфюмеристите Honorine Blane и Piere Negrine. Усещането за този аромат е като дългоочаквана среща между мъж и жена, заредена с много вълнение, страст и магнетизъм. Подходящ е за всички моменти, в които искате да бъдете неустоими."
                    ,ImageUrl = "https://i.imgur.com/KKVstuY.jpg"
                    ,Price = 99.99M
                    ,BrandId = 4
                    ,CategoryId = 1
                    ,Qunatity = 100
                },
                new Perfume{
                    Name = "Antonio Banderas Power of Seduction"
                    ,Desctription = "През 2018 година Antonio Banderas се завръща с ново неустоимо предизвикателство за мъжете. Името му, Power Of Seduction, олицетворява духа и настроението, което ароматът дарява на своя притежател. Уханието е топло, дървесно и съблазнително. На открито, свежи акорди бергамот се съчетават със зелена ябълка и изпъкват в състава. Лавандула, градински чай и артемизия в сърцето, подчертават земните нюанси на парфюма. А богатия кехлибар и тонка, добавят сладост към сместа, докато пачули и мъх допълват дървесните нотки. Тази комбинация от ярки бележки, поставя началото на играта на съблазняване, в която трябва да сте готови на всичко, за да спечелите."
                    ,ImageUrl = "https://i.imgur.com/Jt9k49S.jpg"
                    ,Price = 28.99M
                    ,BrandId = 5
                    ,CategoryId = 1
                    ,Qunatity = 100
                },
                new Perfume{
                  Name = "Antonio Banderas The Secret"
                  ,Desctription = "През 2018 година Antonio Banderas се завръща с ново неустоимо предизвикателство за мъжете. Името му, Power Of Seduction, олицетворява духа и настроението, което ароматът дарява на своя притежател. Уханието е топло, дървесно и съблазнително. На открито, свежи акорди бергамот се съчетават със зелена ябълка и изпъкват в състава. Лавандула, градински чай и артемизия в сърцето, подчертават земните нюанси на парфюма. А богатия кехлибар и тонка, добавят сладост към сместа, докато пачули и мъх допълват дървесните нотки. Тази комбинация от ярки бележки, поставя началото на играта на съблазняване, в която трябва да сте готови на всичко, за да спечелите."
                  ,ImageUrl = "https://i.imgur.com/4bH15zE.jpg"
                  ,Price = 27.99M
                  ,BrandId = 5
                  ,CategoryId = 1
                  ,Qunatity = 100
                }, 
                new Perfume{
                  Name = "Guess Seductive"
                  ,Desctription = "През 2010 година известната и ценена в цял свят марка Guess лансира на пазара заедно с компанията Coty парфюм за жени, озаглавен Seductive, който бързо намира своите почитатели. Аромата съчетава изискания флирт на елегантната жена и умерената дързост на младото момиче.  В своя парфюм модна къща Guess обявява изцяло нов женствен стил! Той умело съчетава дързост и женственост, провокативност и елегантност. Guess Seductive EDT е създаден да съблазнява, привлича и провокира мъжете. Цветно-плодова ароматна палитра, наситена със сексапил и чувственост."
                  ,ImageUrl = "https://i.imgur.com/oGkXPEs.jpg"
                  ,Price = 147.99M
                  ,BrandId = 6
                  ,CategoryId = 2
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Guess Girl"
                  ,Desctription = "През 2010 година известната и ценена в цял свят марка Guess лансира на пазара заедно с компанията Coty парфюм за жени, озаглавен Seductive, който бързо намира своите почитатели. Аромата съчетава изискания флирт на елегантната жена и умерената дързост на младото момиче.  В своя парфюм модна къща Guess обявява изцяло нов женствен стил! Той умело съчетава дързост и женственост, провокативност и елегантност. Guess Seductive EDT е създаден да съблазнява, привлича и провокира мъжете. Цветно-плодова ароматна палитра, наситена със сексапил и чувственост."
                  ,ImageUrl = "https://i.imgur.com/4B2rVej.jpg"
                  ,Price = 44.99M
                  ,BrandId = 6
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Versace Bright Crystal Absolu"
                  ,Desctription = "Versace Bright Crystal Absolu е разкошната, по-силна и чувствена версия на оригинала. Тя е създадена специално за по-взискателните почитатели на бранда. Донатела Версаче, творческият директор на Версаче, изтъква предимството на аромата от към интензивност и продължителност. Тя добавя, че сред най-ярките му характеристики е притежанието на любов, провокативност и жизненост. Ароматната композиция на Versace Bright Crystal Absolu е създадена от уникалния парфюмерист Alberto Morillas. Рекламно лице на кампанията е супермодела Candice Swanepoel."
                  ,ImageUrl = "https://i.imgur.com/UFrotEi.jpg"
                  ,Price = 89.99M
                  ,BrandId = 3
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Crystal Noir"
                  ,Desctription = "За блестящата, чувствена, загадъчна жена, безрезервно уверена в себе си. Вечерен аромат, лансиран през 2004г. Негов създател е парфюмериста Antoine Lie. Едно истинско парфюмерийно бижу, което оставя след себе си воал от удоволствие и наслада. Ако търсите  женствен, ориенталски, съблазнителен аромат, тогава Versace Crystal Noir е вашият перфектен парфюм, излъчващ мистериозна атрактивност и магия. Ненадминато усещане за блясък, лукс и ексклузивност."
                  ,ImageUrl = "https://i.imgur.com/PQJk5kk.jpg"
                  ,Price = 74.99M
                  ,BrandId = 3
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Bright Crystal"
                  ,Desctription = "Versace Bright Crystal EDT е перлата сред парфюмите на модна къща Versace. Това специално ухание  е създадено за елегантната и самоуверена жена, която иска да изрази своята женственост. Ароматът оставя ярка следа и един запомнящ се за дълго аромат. Превъзходен летен аромат, изключително подходящ за топлите дни. Разкошният флакон е изработен от прозрачно стълко, разкриващо розова течност."
                  ,ImageUrl = "https://i.imgur.com/ax3iIHW.jpg"
                  ,Price = 74.99M
                  ,BrandId = 3
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Dolce & Gabbana Light Blue"
                  ,Desctription = "Light Blue от Dolce & Gabbana е тоалетна вода за жени с изключително прохладно присъствие, който ни потапя в атмосферата на Сицилианското лято, ваканцията и свободата. Създаден е от парфюмериста Olivier Cresp. Представен е за директна продажба на пазара през 2001година. Много популярен летен аромат,превърнал се в запазена марка за много жени, но много ярка и характерна ароматна аура, която всеки от нас оцветява с различни нюанси."
                  ,ImageUrl = "https://i.imgur.com/ZGjTHSK.jpg"
                  ,Price = 112.99M
                  ,BrandId = 7
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Dolce & Gabbana Anthology 3 L`Imperatrice"
                  ,Desctription = "Dolce & Gabbana представиха пет нови аромата, от новата си колекция The D&G Anthology. Те са представени на пазара през септември 2009г. Ароматите се ракламират от известни знаменитости, които се показват голи в рекламната кампания. Колекцията The D & G Anthology е вдъхновена от картите таро. Dolce & Gabbana Anthology L`Imperatrice 3  рекламни лице е Naomi Campbell."
                  ,ImageUrl = "https://i.imgur.com/avpEUcS.jpg"
                  ,Price = 59.99M
                  ,BrandId = 7
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Ariana Grande Ari"
                  ,Desctription = "Ari на Ariana Grande е  флорално плодов дамски  аромат . Това е нов парфюм , който стартира през 2019 година. Носът зад този аромат е Jerome Epinette. Thank U Next има наситен и сладък връх на бяла круша, а динамичното му сърце прелива от аромата на сочна и дива малина. Уникалната и незабравима роза се среща с тропическия кокос, а  в базата на аромата богатият кадифен мускус е украсен с фантастичните захарни френски макарони, които без съмнение приветстват сладостта в уханието. Уникален, модерен, смайващ и изключителен като самата Ariana Grande, Thank U Next ще Ви подари страхотно настроение и траен аромат!"
                  ,ImageUrl = "https://i.imgur.com/owmkHtF.jpg"
                  ,Price = 77.99M
                  ,BrandId = 8
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Ariana Grande Sweet Like Candy"
                  ,Desctription = "Sweet Like Candy на Ariana Grande е  флорално плодов дамски  аромат . Това е нов парфюм , който стартира през 2019 година. Носът зад този аромат е Jerome Epinette. Thank U Next има наситен и сладък връх на бяла круша, а динамичното му сърце прелива от аромата на сочна и дива малина. Уникалната и незабравима роза се среща с тропическия кокос, а  в базата на аромата богатият кадифен мускус е украсен с фантастичните захарни френски макарони, които без съмнение приветстват сладостта в уханието. Уникален, модерен, смайващ и изключителен като самата Ariana Grande, Thank U Next ще Ви подари страхотно настроение и траен аромат!"
                  ,ImageUrl = "https://i.imgur.com/YLcvtU8.jpg"
                  ,Price = 75.99M
                  ,BrandId = 8
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Ariana Grande Thank U Next"
                  ,Desctription = "Thank U Next на Ariana Grande е  флорално плодов дамски  аромат . Това е нов парфюм , който стартира през 2019 година. Носът зад този аромат е Jerome Epinette. Thank U Next има наситен и сладък връх на бяла круша, а динамичното му сърце прелива от аромата на сочна и дива малина. Уникалната и незабравима роза се среща с тропическия кокос, а  в базата на аромата богатият кадифен мускус е украсен с фантастичните захарни френски макарони, които без съмнение приветстват сладостта в уханието. Уникален, модерен, смайващ и изключителен като самата Ariana Grande, Thank U Next ще Ви подари страхотно настроение и траен аромат!"
                  ,ImageUrl = "https://i.imgur.com/75rtlF5.jpg"
                  ,Price = 83.99M
                  ,BrandId = 8
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Christian Dior J`adore"
                  ,Desctription = "J'adore е модерен, бляскав, пищен  и изключително популярен за бранда аромат .  Ухание,  което носи светлина и символизира  жената с характер, елегантна  и стилна . Неговата богат и златен аромат блести върху кожата като слънчеви лъчи.  Флакона е оформен като гръцки амфори. J'adore представя нова концепция на Dior  за женствеността. Създаден през 1999г."
                  ,ImageUrl = "https://i.imgur.com/zm6mYTe.jpg"
                  ,Price = 148.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Christian Dior Joy"
                  ,Desctription = "Joy – новото слънчево предизвикателство от Christian Dior. Искряща радост, идеално сгушена в ароматното сърце на Dior. С уникално име и усмивка на цветя и цитрусови плодове, Joy опиянява сетивата. Хармонично и опияняващо ухание, което се разгръща с по-фини нотки, обгърнати от топла и кремообразна база. Нежно ароматно докосване, което носи уют и неописуемо щастие. Бутилката е семпла, изпълнена с розови цветове. Капачката е обвита с луксозен сребрист пръстен, с който Dior придава завършеност на парфюма. Модната къща дарява почитателите си с това бляскаво преживяване през месец август 2018 година."
                  ,ImageUrl = "https://i.imgur.com/laNXXkN.jpg"
                  ,Price = 199.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Christian Dior Miss Dior 2017"
                  ,Desctription = "Christian Dior Miss Dior 2017 е създаден за романтичните и модерни жени, които са готови на всичко в името на любовта! Новото издание получава официалното си представя през месец септември 2017 година и е дело на парфюмериста на марката - уникалния Francois Demachy. Съставът, който той разработва се определя като цветен и елегантен, с доминиращи акорди на роза Дамасцена и роза от Грас. Нежното флорално докосване е подчертано с божествени плодови нюанси и дървесни нотки. За много кратко време, новия парфюм се превръща в тотален хит, а всяка почитателка на колекцията определено оценява високо новата прелестна версия. Рекламно лице на кампанията Christian Dior Miss Dior 2017 отново е известната и обожавана актриса Натали Портман."
                  ,ImageUrl = "https://i.imgur.com/YwHMEk9.jpg"
                  ,Price = 194.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Christian Dior Addict"
                  ,Desctription = "Christian Dior Addict Eau de Parfum е ново променено издание на оригиналния аромат от 2012г. Представен е на пазара 2014година, а неговият създател е парфюмериста Francois Demanchy. Аромата се отваря с нотки на листа от мандарина счетани с портокалов цвят. Сърцето включва  жасмин Самбак, омайна  ванилия придава сладост на уханието в завършек и пленява със собствена харизма. Женствен, топъл, пикантен и магнетичен."
                  ,ImageUrl = "https://i.imgur.com/oMRFIRW.jpg"
                  ,Price = 149.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Christian Dior Hypnotic Poison"
                  ,Desctription = "Vanilla ориенталски аромат за жени представен на пазара 1998г. Секси, съблазнителен и скандален дамски парфюм към който никой не остава равнодушен. Създаден е  с много страст от парфюмериста Аnnick Menardo, той определено отваря сетивата и провокира въображението."
                  ,ImageUrl = "https://i.imgur.com/ZfrS3N8.jpg"
                  ,Price = 124.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Giorgio Armani SI"
                  ,Desctription = "Giorgio Armani Si е аромат за силната жена. Тя има присъствие пълно с елегантност, чар и харизма ,  казва \"Да\" на живота с всичките му възможности. Това описва и самия аромат  - различните аспекти на една жена , което всъщност  представлява  и парфюмът Si. Чувственост и рационалност; Емпоции и интензивност; Всички тези противоречия намират израз както в елегантния флакон , така и в самото ухание. Представен на пазара 2013 година и негов създател  е парфюмериста Christine Nagel."
                  ,ImageUrl = "https://i.imgur.com/VEMyfbn.jpg"
                  ,Price = 179.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Acqua Di Gioia"
                  ,Desctription = "Giorgio Armani Acqua Di Gioia е един от най-възхитителните и прелестни аромати, които марката е лансирала някога. Той е толкова уникален парфюм, че дори дава начало на създаването на цяла ароматна колекцията. Съставът на Acqua Di Gioia е сравнен с жена, която притежава силен и свободен дух, която същевременно се намира в идеална хармония с природата. Композицията представлява идеята за \"бягство от ежедневието\" и е вдъхновена от летните дни на остров Пантелерия. Уханието ще Ви помогне да възстановите енергията си и да откриете баланса между душа и тяло, благодарение на свежите природни ухания. Парфюмът е дело на невероятното трио Loc Dong , Anne Flipo и Dominique Ropion! Появява се на пазара през 2010 година."
                  ,ImageUrl = "https://i.imgur.com/jnqlf7N.jpg"
                  ,Price = 119.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Armani Emporio She"
                  ,Desctription = "Дамския аромат Emporio Armani  She е чувствен и нежен, който говори на езика на любовта.  Парфюмът Armani She носи различни ароматни съставки, които се допълват перфектно и може да бъде много специално преживяване. Ориенталски-ванилов аромат за жени лансиран на пазара 1998 година. Секси, елегантен, топъл и с  лек намек за класика."
                  ,ImageUrl = "https://i.imgur.com/n1C79ed.jpg"
                  ,Price = 128.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Si Passione"
                  ,Desctription = "Giorgio Armani Si Passione е уникална интерпретация на класическото издание. Той крие в себе си сила, женственост и независим дух от едно съвсем различно измерение. Този разкошен и безкомпромисен аромат е създаден само и единствено за уверените жени. За тези от тях, които обуват високите токчета и слагат ярко червеното си червило - готови да покорят света!"
                  ,ImageUrl = "https://i.imgur.com/4f8rCli.jpg"
                  ,Price = 158.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Acqua di Gio Profumo"
                  ,Desctription = "Giorgio Armani Acqua di Gio Profumo е нова версия на емблематичния за бранда аромат Giorgio Armani Acqua di Gio. Създадена е от парфюмериста Alberto Morillas. Представена е на пазара 2015. Аромата символизира сливането на морските вълни и скалите. Определението за елегантен, ефирен и дълбок мъжки парфюм. Зрял и една идея по-елегантен прочит на основата на Acqua di Gio."
                  ,ImageUrl = "https://i.imgur.com/WHPpEqv.jpg"
                  ,Price = 158.99M
                  ,BrandId = 9
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Acqua di Gio"
                  ,Desctription = "Giorgio Armani Acqua di Gio е мъжки парфюм, превърнал се емблема на дизайнера. От 1996 година, до сега той се радва на изключителната любов на почитателите си, които стават все по-многобройни. Създаден е от изключителния парфюмерист Alberto Morillas. Това е аромат на свободата на духа и тялото, на безкрайната водна шир, вятъра и слънцето. Създава усещане за чистота, свежест, жизненост и енергия. Жените харесват мъжа който носи Giorgio Armani Acqua di Gio, защото той е елегантен, секси и изключително магнетичен. Еднакво добре ще изрази вашата индивидуалност, и в деловото ежедневие, и във времето в коетосе забавлявате."
                  ,ImageUrl = "https://i.imgur.com/cI5Jf7m.jpg"
                  ,Price = 109.99M
                  ,BrandId = 9
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Giorgio Armani Code Profumo"
                  ,Desctription = "През 2016 година ненадминатият моден дизайнер Giorgio Armani пуска нова мъжка парфюмна вода, част от колекцията \"Code\", Code Profumo. Един великолепен ароматен шедьовър с благородно и съвършено звучене! Ухание, което е в състояние да създаде образа на чувствения, сексуален и темпераментен човек, характеризиращ се с фини черти, добри маниери и галантност. Изискания дизайн на бутилка също подчертава уникалността на вкуса. С този аромат можете да изглеждате добре във всяка ситуация."
                  ,ImageUrl = "https://i.imgur.com/HERfZLp.jpg"
                  ,Price = 224.99M
                  ,BrandId = 9
                  ,CategoryId = 1
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Dolce & Gabbana Pour Homme 2012"
                  ,Desctription = "Dolce & Gabbana Pour Homme 2012 е връщане към корените, едно истинско прераждане и доказателство за еволюцията на бранда. Той е деликатен, изтънчен, мек, но и едновременно с това изключително мъжествен. Композицията се отключва със свежи и ободряващи нотки, в комбинация с остър мирис на лавандула, зелен чай и малка доза пикантност, която се носи в средата. Финалът на това пътешествие е подчертан с чувствен и омайващ съюз между тютюн, кедър и тонка. Dolce & Gabbana Pour Homme 2012 е представен на пазара 2012 година."
                  ,ImageUrl = "https://i.imgur.com/gHAzEwm.jpg"
                  ,Price = 114.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Dolce & Gabbana The One Royal Night"
                  ,Desctription = "Dolce & Gabbana The One Royal Night е новото ексклузивно творение на D&G, представено през 2015 година. Това чувствено ориенталско издание ще ви отведе на вълнуващо пътуване до Близкия Изток. С дървесните си ухания и вълшебни пикантни нюанси, то ще ви накара да се почувствате като герой от приказка на Шехерезада. Няма как да не бъде спомената и стъклената бутилка в преливащи тъмни нюанси, която е луксозно украсена със златни детайли. Името на аромата е изписано със златисти арабски букви, точно над логото на бранда."
                  ,ImageUrl = "https://i.imgur.com/pZwoN6E.jpg"
                  ,Price = 134.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Dolce & Gabbana Intenso"
                  ,Desctription = "Dolce & Gabbana Intenso e мъжки парфюм представен на пазара 2014 година. Определен е като изключително мъжествен и елегантен аромат. Ухание от ново поколение, което изразява инстинкти и емоции, силата на мъжа. Dolce & Gabbana Intenso е създаден за изискан мъж, около който витае мистерия и грабва женските сърца само с поглед. Композицията му е наситена с дървесни нотки, омайващо поръсени в неустоими подправки."
                  ,ImageUrl = "https://i.imgur.com/cIFpuaM.jpg"
                  ,Price = 74.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Dolce & Gabbana The One"
                  ,Desctription = "Dolce & Gabbana The One е аромат за мъже, представен на пазара 2008г. След изкючителния успех на The One за жени, известните дизайнери Dolce & Gabbana лансираха на пазара мъжката версия. Определя се, като съвременен, модерен класически аромат, зареден с усещане за стил и определена визия. Топлата дървесно ориенталска аура, много финно и меко се слива със ежедневния ви стайлинг, но може и прекрасно да изрази и допълни във вечерните часове, вашия неустоим мъжествен чар."
                  ,ImageUrl = "https://i.imgur.com/PgbFk9k.jpg"
                  ,Price = 68.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Gucci Guilty Absolute"
                  ,Desctription = "Gucci Guilty Absolute е новото мъжко парфюмно издание на бранда, представено в началото на 2017 година. Ароматът е резултат от прекрасното сътрудничество между Alessandro Michele - творческия директор на Гучи и топ парфюмериста Alberto Morillas. Интензивното дървесно ухание се дължи на изисканата композиция, съставена от кожа, масло от пачули, кипарис, горски акорди и ветивер. Gucci Guilty Absolute е мъжествен аромат, създаден за зрелите и уравновесени господа, които обичат интересните и характерни ухания."
                  ,ImageUrl = "https://i.imgur.com/9pkWMfa.jpg"
                  ,Price = 179.99M
                  ,BrandId = 10
                  ,CategoryId = 1
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Gucci by Gucci"
                  ,Desctription = "Gucci by Gucci EDT парфюм за мъже, достоен спътник на женския вариант от 2007 година. Подчератно модерен и елегантен аромат, предназначен за креативни и стилни мъже, с изтънчен вкус и добри обноски. Представен на пазара през 2008 година. Създаден е от Фрида Джанини и със съдействието на Givaudan и P&G. Изключително изискан аромат с много добри характеристики и трайност. Стилен и с подчертана класа. Бутилката е проектирана в строго елегантен дизай, излъчващ изисканост и добър вкус. Gucci by Gucci EDT - подписа на модерия човек!"
                  ,ImageUrl = "https://i.imgur.com/YtMxdsy.jpg"
                  ,Price = 84.99M
                  ,BrandId = 10
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Gucci Guilty"
                  ,Desctription = "Gucci Guilty e aромат, създаден за мъжете които знаят какво искат и за тези, които винаги получават това, което искат. Парфюм за мъжа лидър, той винаги доминира и печели. Провокативен, съблазнителен и много привлекателен за жените. Композицията е една невероятна селекция от компоненти, създаваща аура на мъжественост и авторитет. Gucci Guilty EDT притежава невероятен аромат, \"затворен\" в много атрактивен флакон. Gucci Guilty EDT - не се страхувайте да бъдете смели в желанията си! Презентиран е на пазара през 2011 година."
                  ,ImageUrl = "https://i.imgur.com/1vqeRXU.jpg"
                  ,Price = 104.99M
                  ,BrandId = 10
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Versace Pour Homme Oud Noir"
                  ,Desctription = "Versace Homme Oud Noir е чувственo опияняваща композиция действаща  почти като  афродизиак. Неговият ориенталски характер прави Versace Pour Homme Oud Noir един мъжки аромат за ценители с изразена индивидуалност. Интензивен аромат, който привлича със свояте пикантни дървесни нотки, фокусира  вниманието към себе си и остава траен спомен в  съзнанието. Лансиран на пазара през 2013 година."
                  ,ImageUrl = "https://i.imgur.com/uHhEpiT.jpg"
                  ,Price = 124.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Versace Versus Blue Jeans"
                  ,Desctription = "Versace Versus Blue Jeans е аромат, към който носталгията винаги ще ви връща. Класически мъжки парфюм с характерна свежа, безгрижна и излъчваща чистота аура. Негов създател е парфюмериста Jean-Pierrre Bethouart, който съчетава ухание с дървесни, цитрусови нотки с пикантно сърце и затопляща основа. Представен е на пазара 1994 година."
                  ,ImageUrl = "https://i.imgur.com/JWID0KF.jpg"
                  ,Price = 24.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Eros Flame"
                  ,Desctription = "Versace Eros Flame е новото парфюмно творение на луксозния италиански бранд Versace. Наследникът на обичания от всички Eros е изпълнен с любов, страст и съблазън. Versace описват своя парфюм като леден и горещ, сладък и пикантен, светъл и мрачен. Парфюм с два противоположни характера, събрани в прекрасен огнено червен флакон с добре познатите златни елементи. Този пленителен аромат е насочен към силния, страстен и самоуверен мъж, който винаги е наясно със своите емоции и чувства. Парфюмната вода е дело на парфюмериста Olivier Pescheux и е лансиран през 2018 година."
                  ,ImageUrl = "https://i.imgur.com/H7UcRV5.jpg"
                  ,Price = 91.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Pour Homme"
                  ,Desctription = "Versace Pour Homme е изключителен аромат, предназначен за елегантни и изискани мъже. Носител е на всички типични за бранда достойнства, а именно, собствен стил и неподражаема елегатнност. Представн е за продажба на пазара през 2008година. Създаден е от изключителния парфюмерист Alberto Morillas. Ако искате да сте желан, ако искате да сте привличащ, ако искате да ви харесват, и вие да харесвате себе си Versace Pour Homme е вашия аромат."
                  ,ImageUrl = "https://i.imgur.com/hWrhWWV.jpg"
                  ,Price = 89.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                 new Perfume{
                    Name = "DIOR Sauvage"
                    ,Desctription = "Франсоа Демаши, парфюмерист на Dior, намира вдъхновението във вълшебния момент, в който здрачът се спуска над пустинята. Смесен с прохладата на нощта, изгарящият пустинен въздух носи тайнствени аромати. Момент, оцветен в тъмно синьо, който отприщва и най-смелите инстинкти. В часа, в който вълците излизат, а небето гори с лъчите на залязващото слънце, се появява нова магия."
                    ,ImageUrl = "https://i.imgur.com/Iy1QyP8.jpg"
                    ,Price = 185.00M
                    ,BrandId = 2
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
                    ,BrandId = 1
                    ,CategoryId = 2
                    ,Qunatity = 50
                },
                 new Perfume{
                    Name = "Calvin Klein In2U"
                    ,Desctription = "Calvin Klein In2U e модерен аромат насочен към младото поколение, създаден да изрази свободната воля и желанието на младите хора да изследват и опознават света.  Усеща духа и  настроението на енергичните млади мъже и жени. Представен на пазара 2007г. Свеж, динамичен, чист и тонизиращ. Прекрасно предложени за топлите месеци, ваканциите и забавленията с приятели на открито. Ароматният състав е разработен от уникален екип парфюмеристи - Bruno Jovanovic , Jean-Marc Chaillan , Loc Dong и Carlos Benaim.  Calvin Klein In2U е представен на пазара за първи път през 2007 година."
                    ,ImageUrl = "https://i.imgur.com/NgWSnk9.jpg"
                    ,Price = 41.99M
                    ,BrandId = 4
                    ,CategoryId = 2
                    ,Qunatity = 100
                },
                 new Perfume{
                    Name = "Hugo Boss Bottled Nigh"
                    ,Desctription = "Hugo Boss Bottled Night EDT е дървесен аромат за мъже лансиран на пазара през юли 2010 година. За младия, амбициозен, модерен мъж, който преследва целите си. Той е уверен в своите способности и знае, че всяка цел е постижима и всичко е възможно! Успехът е на една ръка разстояние от Вас! Съблазнителен и много мъжествен аромат, подчертаващ сила и чувственост. Не по-малко харизматича е бутилката - флакон, оцветен в наситени, тъмносини нюанси, обрисуващи загадачността на нощта. Неговият елегантен и благороден блясък разкрива на своя собственик тайните на прелъстяването, подготвя го за приключенията, съпътстващи тъмната част на денонощието. "
                    ,ImageUrl = "https://i.imgur.com/NgWSnk9.jpg"
                    ,Price = 59.99M
                    ,BrandId = 1
                    ,CategoryId = 1
                    ,Qunatity = 50
                },
                new Perfume{
                    Name = "Calvin Klein Encounter парфюм за мъже"
                    ,Desctription = "Calvin Klein Encounter e мистериозен, мъжествен и съблазнително секси аромат, представен на пазара през 2012 година. Разработка е на парфюмеристите Honorine Blane и Piere Negrine. Усещането за този аромат е като дългоочаквана среща между мъж и жена, заредена с много вълнение, страст и магнетизъм. Подходящ е за всички моменти, в които искате да бъдете неустоими."
                    ,ImageUrl = "https://i.imgur.com/KKVstuY.jpg"
                    ,Price = 99.99M
                    ,BrandId = 4
                    ,CategoryId = 1
                    ,Qunatity = 100
                },
                new Perfume{
                    Name = "Antonio Banderas Power of Seduction"
                    ,Desctription = "През 2018 година Antonio Banderas се завръща с ново неустоимо предизвикателство за мъжете. Името му, Power Of Seduction, олицетворява духа и настроението, което ароматът дарява на своя притежател. Уханието е топло, дървесно и съблазнително. На открито, свежи акорди бергамот се съчетават със зелена ябълка и изпъкват в състава. Лавандула, градински чай и артемизия в сърцето, подчертават земните нюанси на парфюма. А богатия кехлибар и тонка, добавят сладост към сместа, докато пачули и мъх допълват дървесните нотки. Тази комбинация от ярки бележки, поставя началото на играта на съблазняване, в която трябва да сте готови на всичко, за да спечелите."
                    ,ImageUrl = "https://i.imgur.com/Jt9k49S.jpg"
                    ,Price = 28.99M
                    ,BrandId = 5
                    ,CategoryId = 1
                    ,Qunatity = 100
                },
                new Perfume{
                  Name = "Antonio Banderas The Secret"
                  ,Desctription = "През 2018 година Antonio Banderas се завръща с ново неустоимо предизвикателство за мъжете. Името му, Power Of Seduction, олицетворява духа и настроението, което ароматът дарява на своя притежател. Уханието е топло, дървесно и съблазнително. На открито, свежи акорди бергамот се съчетават със зелена ябълка и изпъкват в състава. Лавандула, градински чай и артемизия в сърцето, подчертават земните нюанси на парфюма. А богатия кехлибар и тонка, добавят сладост към сместа, докато пачули и мъх допълват дървесните нотки. Тази комбинация от ярки бележки, поставя началото на играта на съблазняване, в която трябва да сте готови на всичко, за да спечелите."
                  ,ImageUrl = "https://i.imgur.com/4bH15zE.jpg"
                  ,Price = 27.99M
                  ,BrandId = 5
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Guess Seductive"
                  ,Desctription = "През 2010 година известната и ценена в цял свят марка Guess лансира на пазара заедно с компанията Coty парфюм за жени, озаглавен Seductive, който бързо намира своите почитатели. Аромата съчетава изискания флирт на елегантната жена и умерената дързост на младото момиче.  В своя парфюм модна къща Guess обявява изцяло нов женствен стил! Той умело съчетава дързост и женственост, провокативност и елегантност. Guess Seductive EDT е създаден да съблазнява, привлича и провокира мъжете. Цветно-плодова ароматна палитра, наситена със сексапил и чувственост."
                  ,ImageUrl = "https://i.imgur.com/oGkXPEs.jpg"
                  ,Price = 147.99M
                  ,BrandId = 6
                  ,CategoryId = 2
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Guess Girl"
                  ,Desctription = "През 2010 година известната и ценена в цял свят марка Guess лансира на пазара заедно с компанията Coty парфюм за жени, озаглавен Seductive, който бързо намира своите почитатели. Аромата съчетава изискания флирт на елегантната жена и умерената дързост на младото момиче.  В своя парфюм модна къща Guess обявява изцяло нов женствен стил! Той умело съчетава дързост и женственост, провокативност и елегантност. Guess Seductive EDT е създаден да съблазнява, привлича и провокира мъжете. Цветно-плодова ароматна палитра, наситена със сексапил и чувственост."
                  ,ImageUrl = "https://i.imgur.com/4B2rVej.jpg"
                  ,Price = 44.99M
                  ,BrandId = 6
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Versace Bright Crystal Absolu"
                  ,Desctription = "Versace Bright Crystal Absolu е разкошната, по-силна и чувствена версия на оригинала. Тя е създадена специално за по-взискателните почитатели на бранда. Донатела Версаче, творческият директор на Версаче, изтъква предимството на аромата от към интензивност и продължителност. Тя добавя, че сред най-ярките му характеристики е притежанието на любов, провокативност и жизненост. Ароматната композиция на Versace Bright Crystal Absolu е създадена от уникалния парфюмерист Alberto Morillas. Рекламно лице на кампанията е супермодела Candice Swanepoel."
                  ,ImageUrl = "https://i.imgur.com/UFrotEi.jpg"
                  ,Price = 89.99M
                  ,BrandId = 3
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Crystal Noir"
                  ,Desctription = "За блестящата, чувствена, загадъчна жена, безрезервно уверена в себе си. Вечерен аромат, лансиран през 2004г. Негов създател е парфюмериста Antoine Lie. Едно истинско парфюмерийно бижу, което оставя след себе си воал от удоволствие и наслада. Ако търсите  женствен, ориенталски, съблазнителен аромат, тогава Versace Crystal Noir е вашият перфектен парфюм, излъчващ мистериозна атрактивност и магия. Ненадминато усещане за блясък, лукс и ексклузивност."
                  ,ImageUrl = "https://i.imgur.com/PQJk5kk.jpg"
                  ,Price = 74.99M
                  ,BrandId = 3
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Bright Crystal"
                  ,Desctription = "Versace Bright Crystal EDT е перлата сред парфюмите на модна къща Versace. Това специално ухание  е създадено за елегантната и самоуверена жена, която иска да изрази своята женственост. Ароматът оставя ярка следа и един запомнящ се за дълго аромат. Превъзходен летен аромат, изключително подходящ за топлите дни. Разкошният флакон е изработен от прозрачно стълко, разкриващо розова течност."
                  ,ImageUrl = "https://i.imgur.com/ax3iIHW.jpg"
                  ,Price = 74.99M
                  ,BrandId = 3
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Dolce & Gabbana Light Blue"
                  ,Desctription = "Light Blue от Dolce & Gabbana е тоалетна вода за жени с изключително прохладно присъствие, който ни потапя в атмосферата на Сицилианското лято, ваканцията и свободата. Създаден е от парфюмериста Olivier Cresp. Представен е за директна продажба на пазара през 2001година. Много популярен летен аромат,превърнал се в запазена марка за много жени, но много ярка и характерна ароматна аура, която всеки от нас оцветява с различни нюанси."
                  ,ImageUrl = "https://i.imgur.com/ZGjTHSK.jpg"
                  ,Price = 112.99M
                  ,BrandId = 7
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Dolce & Gabbana Anthology 3 L`Imperatrice"
                  ,Desctription = "Dolce & Gabbana представиха пет нови аромата, от новата си колекция The D&G Anthology. Те са представени на пазара през септември 2009г. Ароматите се ракламират от известни знаменитости, които се показват голи в рекламната кампания. Колекцията The D & G Anthology е вдъхновена от картите таро. Dolce & Gabbana Anthology L`Imperatrice 3  рекламни лице е Naomi Campbell."
                  ,ImageUrl = "https://i.imgur.com/avpEUcS.jpg"
                  ,Price = 59.99M
                  ,BrandId = 7
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Ariana Grande Ari"
                  ,Desctription = "Ari на Ariana Grande е  флорално плодов дамски  аромат . Това е нов парфюм , който стартира през 2019 година. Носът зад този аромат е Jerome Epinette. Thank U Next има наситен и сладък връх на бяла круша, а динамичното му сърце прелива от аромата на сочна и дива малина. Уникалната и незабравима роза се среща с тропическия кокос, а  в базата на аромата богатият кадифен мускус е украсен с фантастичните захарни френски макарони, които без съмнение приветстват сладостта в уханието. Уникален, модерен, смайващ и изключителен като самата Ariana Grande, Thank U Next ще Ви подари страхотно настроение и траен аромат!"
                  ,ImageUrl = "https://i.imgur.com/owmkHtF.jpg"
                  ,Price = 77.99M
                  ,BrandId = 8
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Ariana Grande Sweet Like Candy"
                  ,Desctription = "Sweet Like Candy на Ariana Grande е  флорално плодов дамски  аромат . Това е нов парфюм , който стартира през 2019 година. Носът зад този аромат е Jerome Epinette. Thank U Next има наситен и сладък връх на бяла круша, а динамичното му сърце прелива от аромата на сочна и дива малина. Уникалната и незабравима роза се среща с тропическия кокос, а  в базата на аромата богатият кадифен мускус е украсен с фантастичните захарни френски макарони, които без съмнение приветстват сладостта в уханието. Уникален, модерен, смайващ и изключителен като самата Ariana Grande, Thank U Next ще Ви подари страхотно настроение и траен аромат!"
                  ,ImageUrl = "https://i.imgur.com/YLcvtU8.jpg"
                  ,Price = 75.99M
                  ,BrandId = 8
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Ariana Grande Thank U Next"
                  ,Desctription = "Thank U Next на Ariana Grande е  флорално плодов дамски  аромат . Това е нов парфюм , който стартира през 2019 година. Носът зад този аромат е Jerome Epinette. Thank U Next има наситен и сладък връх на бяла круша, а динамичното му сърце прелива от аромата на сочна и дива малина. Уникалната и незабравима роза се среща с тропическия кокос, а  в базата на аромата богатият кадифен мускус е украсен с фантастичните захарни френски макарони, които без съмнение приветстват сладостта в уханието. Уникален, модерен, смайващ и изключителен като самата Ariana Grande, Thank U Next ще Ви подари страхотно настроение и траен аромат!"
                  ,ImageUrl = "https://i.imgur.com/75rtlF5.jpg"
                  ,Price = 83.99M
                  ,BrandId = 8
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Christian Dior J`adore"
                  ,Desctription = "J'adore е модерен, бляскав, пищен  и изключително популярен за бранда аромат .  Ухание,  което носи светлина и символизира  жената с характер, елегантна  и стилна . Неговата богат и златен аромат блести върху кожата като слънчеви лъчи.  Флакона е оформен като гръцки амфори. J'adore представя нова концепция на Dior  за женствеността. Създаден през 1999г."
                  ,ImageUrl = "https://i.imgur.com/zm6mYTe.jpg"
                  ,Price = 148.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Christian Dior Joy"
                  ,Desctription = "Joy – новото слънчево предизвикателство от Christian Dior. Искряща радост, идеално сгушена в ароматното сърце на Dior. С уникално име и усмивка на цветя и цитрусови плодове, Joy опиянява сетивата. Хармонично и опияняващо ухание, което се разгръща с по-фини нотки, обгърнати от топла и кремообразна база. Нежно ароматно докосване, което носи уют и неописуемо щастие. Бутилката е семпла, изпълнена с розови цветове. Капачката е обвита с луксозен сребрист пръстен, с който Dior придава завършеност на парфюма. Модната къща дарява почитателите си с това бляскаво преживяване през месец август 2018 година."
                  ,ImageUrl = "https://i.imgur.com/laNXXkN.jpg"
                  ,Price = 199.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Christian Dior Miss Dior 2017"
                  ,Desctription = "Christian Dior Miss Dior 2017 е създаден за романтичните и модерни жени, които са готови на всичко в името на любовта! Новото издание получава официалното си представя през месец септември 2017 година и е дело на парфюмериста на марката - уникалния Francois Demachy. Съставът, който той разработва се определя като цветен и елегантен, с доминиращи акорди на роза Дамасцена и роза от Грас. Нежното флорално докосване е подчертано с божествени плодови нюанси и дървесни нотки. За много кратко време, новия парфюм се превръща в тотален хит, а всяка почитателка на колекцията определено оценява високо новата прелестна версия. Рекламно лице на кампанията Christian Dior Miss Dior 2017 отново е известната и обожавана актриса Натали Портман."
                  ,ImageUrl = "https://i.imgur.com/YwHMEk9.jpg"
                  ,Price = 194.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Christian Dior Addict"
                  ,Desctription = "Christian Dior Addict Eau de Parfum е ново променено издание на оригиналния аромат от 2012г. Представен е на пазара 2014година, а неговият създател е парфюмериста Francois Demanchy. Аромата се отваря с нотки на листа от мандарина счетани с портокалов цвят. Сърцето включва  жасмин Самбак, омайна  ванилия придава сладост на уханието в завършек и пленява със собствена харизма. Женствен, топъл, пикантен и магнетичен."
                  ,ImageUrl = "https://i.imgur.com/oMRFIRW.jpg"
                  ,Price = 149.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Christian Dior Hypnotic Poison"
                  ,Desctription = "Vanilla ориенталски аромат за жени представен на пазара 1998г. Секси, съблазнителен и скандален дамски парфюм към който никой не остава равнодушен. Създаден е  с много страст от парфюмериста Аnnick Menardo, той определено отваря сетивата и провокира въображението."
                  ,ImageUrl = "https://i.imgur.com/ZfrS3N8.jpg"
                  ,Price = 124.99M
                  ,BrandId = 1
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Giorgio Armani SI"
                  ,Desctription = "Giorgio Armani Si е аромат за силната жена. Тя има присъствие пълно с елегантност, чар и харизма ,  казва \"Да\" на живота с всичките му възможности. Това описва и самия аромат  - различните аспекти на една жена , което всъщност  представлява  и парфюмът Si. Чувственост и рационалност; Емпоции и интензивност; Всички тези противоречия намират израз както в елегантния флакон , така и в самото ухание. Представен на пазара 2013 година и негов създател  е парфюмериста Christine Nagel."
                  ,ImageUrl = "https://i.imgur.com/VEMyfbn.jpg"
                  ,Price = 179.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Acqua Di Gioia"
                  ,Desctription = "Giorgio Armani Acqua Di Gioia е един от най-възхитителните и прелестни аромати, които марката е лансирала някога. Той е толкова уникален парфюм, че дори дава начало на създаването на цяла ароматна колекцията. Съставът на Acqua Di Gioia е сравнен с жена, която притежава силен и свободен дух, която същевременно се намира в идеална хармония с природата. Композицията представлява идеята за \"бягство от ежедневието\" и е вдъхновена от летните дни на остров Пантелерия. Уханието ще Ви помогне да възстановите енергията си и да откриете баланса между душа и тяло, благодарение на свежите природни ухания. Парфюмът е дело на невероятното трио Loc Dong , Anne Flipo и Dominique Ropion! Появява се на пазара през 2010 година."
                  ,ImageUrl = "https://i.imgur.com/jnqlf7N.jpg"
                  ,Price = 119.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Armani Emporio She"
                  ,Desctription = "Дамския аромат Emporio Armani  She е чувствен и нежен, който говори на езика на любовта.  Парфюмът Armani She носи различни ароматни съставки, които се допълват перфектно и може да бъде много специално преживяване. Ориенталски-ванилов аромат за жени лансиран на пазара 1998 година. Секси, елегантен, топъл и с  лек намек за класика."
                  ,ImageUrl = "https://i.imgur.com/n1C79ed.jpg"
                  ,Price = 128.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Si Passione"
                  ,Desctription = "Giorgio Armani Si Passione е уникална интерпретация на класическото издание. Той крие в себе си сила, женственост и независим дух от едно съвсем различно измерение. Този разкошен и безкомпромисен аромат е създаден само и единствено за уверените жени. За тези от тях, които обуват високите токчета и слагат ярко червеното си червило - готови да покорят света!"
                  ,ImageUrl = "https://i.imgur.com/4f8rCli.jpg"
                  ,Price = 158.99M
                  ,BrandId = 9
                  ,CategoryId = 2
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Acqua di Gio Profumo"
                  ,Desctription = "Giorgio Armani Acqua di Gio Profumo е нова версия на емблематичния за бранда аромат Giorgio Armani Acqua di Gio. Създадена е от парфюмериста Alberto Morillas. Представена е на пазара 2015. Аромата символизира сливането на морските вълни и скалите. Определението за елегантен, ефирен и дълбок мъжки парфюм. Зрял и една идея по-елегантен прочит на основата на Acqua di Gio."
                  ,ImageUrl = "https://i.imgur.com/WHPpEqv.jpg"
                  ,Price = 158.99M
                  ,BrandId = 9
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Giorgio Armani Acqua di Gio"
                  ,Desctription = "Giorgio Armani Acqua di Gio е мъжки парфюм, превърнал се емблема на дизайнера. От 1996 година, до сега той се радва на изключителната любов на почитателите си, които стават все по-многобройни. Създаден е от изключителния парфюмерист Alberto Morillas. Това е аромат на свободата на духа и тялото, на безкрайната водна шир, вятъра и слънцето. Създава усещане за чистота, свежест, жизненост и енергия. Жените харесват мъжа който носи Giorgio Armani Acqua di Gio, защото той е елегантен, секси и изключително магнетичен. Еднакво добре ще изрази вашата индивидуалност, и в деловото ежедневие, и във времето в коетосе забавлявате."
                  ,ImageUrl = "https://i.imgur.com/cI5Jf7m.jpg"
                  ,Price = 109.99M
                  ,BrandId = 9
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Giorgio Armani Code Profumo"
                  ,Desctription = "През 2016 година ненадминатият моден дизайнер Giorgio Armani пуска нова мъжка парфюмна вода, част от колекцията \"Code\", Code Profumo. Един великолепен ароматен шедьовър с благородно и съвършено звучене! Ухание, което е в състояние да създаде образа на чувствения, сексуален и темпераментен човек, характеризиращ се с фини черти, добри маниери и галантност. Изискания дизайн на бутилка също подчертава уникалността на вкуса. С този аромат можете да изглеждате добре във всяка ситуация."
                  ,ImageUrl = "https://i.imgur.com/HERfZLp.jpg"
                  ,Price = 224.99M
                  ,BrandId = 9
                  ,CategoryId = 1
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Dolce & Gabbana Pour Homme 2012"
                  ,Desctription = "Dolce & Gabbana Pour Homme 2012 е връщане към корените, едно истинско прераждане и доказателство за еволюцията на бранда. Той е деликатен, изтънчен, мек, но и едновременно с това изключително мъжествен. Композицията се отключва със свежи и ободряващи нотки, в комбинация с остър мирис на лавандула, зелен чай и малка доза пикантност, която се носи в средата. Финалът на това пътешествие е подчертан с чувствен и омайващ съюз между тютюн, кедър и тонка. Dolce & Gabbana Pour Homme 2012 е представен на пазара 2012 година."
                  ,ImageUrl = "https://i.imgur.com/gHAzEwm.jpg"
                  ,Price = 114.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Dolce & Gabbana The One Royal Night"
                  ,Desctription = "Dolce & Gabbana The One Royal Night е новото ексклузивно творение на D&G, представено през 2015 година. Това чувствено ориенталско издание ще ви отведе на вълнуващо пътуване до Близкия Изток. С дървесните си ухания и вълшебни пикантни нюанси, то ще ви накара да се почувствате като герой от приказка на Шехерезада. Няма как да не бъде спомената и стъклената бутилка в преливащи тъмни нюанси, която е луксозно украсена със златни детайли. Името на аромата е изписано със златисти арабски букви, точно над логото на бранда."
                  ,ImageUrl = "https://i.imgur.com/pZwoN6E.jpg"
                  ,Price = 134.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Dolce & Gabbana Intenso"
                  ,Desctription = "Dolce & Gabbana Intenso e мъжки парфюм представен на пазара 2014 година. Определен е като изключително мъжествен и елегантен аромат. Ухание от ново поколение, което изразява инстинкти и емоции, силата на мъжа. Dolce & Gabbana Intenso е създаден за изискан мъж, около който витае мистерия и грабва женските сърца само с поглед. Композицията му е наситена с дървесни нотки, омайващо поръсени в неустоими подправки."
                  ,ImageUrl = "https://i.imgur.com/cIFpuaM.jpg"
                  ,Price = 74.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Dolce & Gabbana The One"
                  ,Desctription = "Dolce & Gabbana The One е аромат за мъже, представен на пазара 2008г. След изкючителния успех на The One за жени, известните дизайнери Dolce & Gabbana лансираха на пазара мъжката версия. Определя се, като съвременен, модерен класически аромат, зареден с усещане за стил и определена визия. Топлата дървесно ориенталска аура, много финно и меко се слива със ежедневния ви стайлинг, но може и прекрасно да изрази и допълни във вечерните часове, вашия неустоим мъжествен чар."
                  ,ImageUrl = "https://i.imgur.com/PgbFk9k.jpg"
                  ,Price = 68.99M
                  ,BrandId = 7
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Gucci Guilty Absolute"
                  ,Desctription = "Gucci Guilty Absolute е новото мъжко парфюмно издание на бранда, представено в началото на 2017 година. Ароматът е резултат от прекрасното сътрудничество между Alessandro Michele - творческия директор на Гучи и топ парфюмериста Alberto Morillas. Интензивното дървесно ухание се дължи на изисканата композиция, съставена от кожа, масло от пачули, кипарис, горски акорди и ветивер. Gucci Guilty Absolute е мъжествен аромат, създаден за зрелите и уравновесени господа, които обичат интересните и характерни ухания."
                  ,ImageUrl = "https://i.imgur.com/9pkWMfa.jpg"
                  ,Price = 179.99M
                  ,BrandId = 10
                  ,CategoryId = 1
                  ,Qunatity = 200
                },
                new Perfume{
                  Name = "Gucci by Gucci"
                  ,Desctription = "Gucci by Gucci EDT парфюм за мъже, достоен спътник на женския вариант от 2007 година. Подчератно модерен и елегантен аромат, предназначен за креативни и стилни мъже, с изтънчен вкус и добри обноски. Представен на пазара през 2008 година. Създаден е от Фрида Джанини и със съдействието на Givaudan и P&G. Изключително изискан аромат с много добри характеристики и трайност. Стилен и с подчертана класа. Бутилката е проектирана в строго елегантен дизай, излъчващ изисканост и добър вкус. Gucci by Gucci EDT - подписа на модерия човек!"
                  ,ImageUrl = "https://i.imgur.com/YtMxdsy.jpg"
                  ,Price = 84.99M
                  ,BrandId = 10
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Gucci Guilty"
                  ,Desctription = "Gucci Guilty e aромат, създаден за мъжете които знаят какво искат и за тези, които винаги получават това, което искат. Парфюм за мъжа лидър, той винаги доминира и печели. Провокативен, съблазнителен и много привлекателен за жените. Композицията е една невероятна селекция от компоненти, създаваща аура на мъжественост и авторитет. Gucci Guilty EDT притежава невероятен аромат, \"затворен\" в много атрактивен флакон. Gucci Guilty EDT - не се страхувайте да бъдете смели в желанията си! Презентиран е на пазара през 2011 година."
                  ,ImageUrl = "https://i.imgur.com/1vqeRXU.jpg"
                  ,Price = 104.99M
                  ,BrandId = 10
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Versace Pour Homme Oud Noir"
                  ,Desctription = "Versace Homme Oud Noir е чувственo опияняваща композиция действаща  почти като  афродизиак. Неговият ориенталски характер прави Versace Pour Homme Oud Noir един мъжки аромат за ценители с изразена индивидуалност. Интензивен аромат, който привлича със свояте пикантни дървесни нотки, фокусира  вниманието към себе си и остава траен спомен в  съзнанието. Лансиран на пазара през 2013 година."
                  ,ImageUrl = "https://i.imgur.com/uHhEpiT.jpg"
                  ,Price = 124.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
                new Perfume{
                  Name = "Versace Versus Blue Jeans"
                  ,Desctription = "Versace Versus Blue Jeans е аромат, към който носталгията винаги ще ви връща. Класически мъжки парфюм с характерна свежа, безгрижна и излъчваща чистота аура. Негов създател е парфюмериста Jean-Pierrre Bethouart, който съчетава ухание с дървесни, цитрусови нотки с пикантно сърце и затопляща основа. Представен е на пазара 1994 година."
                  ,ImageUrl = "https://i.imgur.com/JWID0KF.jpg"
                  ,Price = 24.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Eros Flame"
                  ,Desctription = "Versace Eros Flame е новото парфюмно творение на луксозния италиански бранд Versace. Наследникът на обичания от всички Eros е изпълнен с любов, страст и съблазън. Versace описват своя парфюм като леден и горещ, сладък и пикантен, светъл и мрачен. Парфюм с два противоположни характера, събрани в прекрасен огнено червен флакон с добре познатите златни елементи. Този пленителен аромат е насочен към силния, страстен и самоуверен мъж, който винаги е наясно със своите емоции и чувства. Парфюмната вода е дело на парфюмериста Olivier Pescheux и е лансиран през 2018 година."
                  ,ImageUrl = "https://i.imgur.com/H7UcRV5.jpg"
                  ,Price = 91.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 50
                },
                new Perfume{
                  Name = "Versace Pour Homme"
                  ,Desctription = "Versace Pour Homme е изключителен аромат, предназначен за елегантни и изискани мъже. Носител е на всички типични за бранда достойнства, а именно, собствен стил и неподражаема елегатнност. Представн е за продажба на пазара през 2008година. Създаден е от изключителния парфюмерист Alberto Morillas. Ако искате да сте желан, ако искате да сте привличащ, ако искате да ви харесват, и вие да харесвате себе си Versace Pour Homme е вашия аромат."
                  ,ImageUrl = "https://i.imgur.com/hWrhWWV.jpg"
                  ,Price = 89.99M
                  ,BrandId = 3
                  ,CategoryId = 1
                  ,Qunatity = 100
                },
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
         


            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@admin.com";
                    const string adminPassword = "admin123";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
