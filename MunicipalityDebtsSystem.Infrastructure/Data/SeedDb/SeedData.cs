using Microsoft.AspNetCore.Identity;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.CustomClaims;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class SeedData

    {
       //public UserManager<ApplicationUser> userManager;
       //public RoleManager<IdentityRole> roleManager;
        public SeedUsers users;
        public CreditorType[] creditorTypeArr;
        public CreditType[] creditTypeArr;
        public CreditStatusType[] creditStatusTypeArr;
        public DebtType[] debtTypeArr;
        public DebtPurposeType[] debtPurposeTypeArr;
        public InterestType[] interestTypeArr;
        public CoverType[] coverTypeArr;
        public OperationType[] operationTypeArr;
        public MunicipalCenter[] municipalCenterArr;
        public Municipality[] municipalityArr;
        public Currency[] currencyArr;
        public CurrencyRate[] currencyRateArr;
      
        public ApplicationUser adminUser { get; set; }
        public IdentityUserClaim<string> AdminUserClaim { get; set; }
        public ApplicationUser BurgasMunicipalityUser { get; set; }
        public IdentityUserClaim<string> BurgasUserClaim { get; set; }
        public ApplicationUser VarnaMunicipalityUser { get; set; }
        public IdentityUserClaim<string> VarnaUserClaim { get; set; }

        public SeedData(//SeedUsers _users 
                        //UserManager<ApplicationUser> _userManager,
                        //RoleManager<IdentityRole> _roleManager
                        )
       
        {
            //users = _users;
            //userManager = _userManager;
            //roleManager = _roleManager;

            SeedCreditorTypeList();
            SeedCreditTypeList();
            SeedCreditStatusTypeList();
            SeedDebtTypeList();
            SeedDebtPurposeTypeList();
            SeedInterestTypeList();
            SeedCoverTypeList();
            SeedОperationTypeList();
            SeedMunicipalCenterList();
            SeedMunicipalityList();
            SeedCurrencyList();
            SeedCurrencyRateList();
            //users.SeedRoles();
            //SeedUsers();
        }

        public void SeedCreditorTypeList()
        {
            
            creditorTypeArr = new CreditorType[]
            {
                new CreditorType() { Id = 1, Name = "Правителство" },
                new CreditorType() { Id = 2, Name = "МФ" },
                new CreditorType() { Id = 3, Name = "Кредитна институция - банка" },
                new CreditorType() { Id = 4, Name = "Финансова институция" },
                new CreditorType() { Id = 5, Name = "Община" },
                new CreditorType() { Id = 6, Name = "Българска банка за развитие АД" },
                new CreditorType() { Id = 7, Name = "Други" },

            };
        }

        public void SeedCreditTypeList()
        {

            creditTypeArr = new CreditType[]
            {
                new CreditType() { Id = 1, Name = "Изискуема общинска гаранция" },
                new CreditType() { Id = 2, Name = "Безлихвени заеми, отпуснати по реда на ЗПФ" },
                new CreditType() { Id = 3, Name = "Търговски кредити" },
                new CreditType() { Id = 4, Name = "Финансов лизинг" },
                new CreditType() { Id = 5, Name = "Останали форми на дълг" },
                new CreditType() { Id = 6, Name = "Възмездно финансиране по чл.103, ал.3 от ЗПФ" },
                new CreditType() { Id = 7, Name = "Договор за общински заем" },
                new CreditType() { Id = 8, Name = "Общинските предприятия по чл. 52 от ЗОС" },
                new CreditType() { Id = 9, Name = "Безлихвени заеми от ЦБ по чл.43 ал.1 от ЗУДБ" },
                new CreditType() { Id = 10, Name = "Търговски кредити над две години" },
                new CreditType() { Id = 11, Name = "Финансов лизинг над две години" },

            };
        }

        public void SeedCreditStatusTypeList()
        {

            creditStatusTypeArr = new CreditStatusType[]
            {
                new CreditStatusType() { Id = 1, Name = "Непотвърден" },
                new CreditStatusType() { Id = 2, Name = "Потвърден" },
                new CreditStatusType() { Id = 3, Name = "Приключен" },
                new CreditStatusType() { Id = 4, Name = "Предоговорен" },
                new CreditStatusType() { Id = 5, Name = "Предоговорен/Приключен" }
               
               
            };
        }
        public void SeedDebtTypeList()
        {

            debtTypeArr = new DebtType[]
            {
                new DebtType() { Id = 1, Name = "Краткосрочен" },
                new DebtType() { Id = 2, Name = "Дългосрочен" }
               
            };
        }
        public void SeedDebtPurposeTypeList()
        {

            debtPurposeTypeArr = new DebtPurposeType[]
            {
                new DebtPurposeType() { Id = 1, Name = "Инвестиционни проекти", DebtTypeId = 2 },
                new DebtPurposeType() { Id = 2, Name = "Рефинансиране на съществуващ дълг", DebtTypeId = 2},
                new DebtPurposeType() { Id = 3, Name = "Форсмажорни обстоятелства", DebtTypeId = 2},
                new DebtPurposeType() { Id = 4, Name = "Изискуеми общински гаранции", DebtTypeId = 2},
                new DebtPurposeType() { Id = 5, Name = "Временен недостиг на средства", DebtTypeId = 1},
                new DebtPurposeType() { Id = 6, Name = "Капиталови разходи", DebtTypeId = 1},
                new DebtPurposeType() { Id = 7, Name = "Неотложни разходи", DebtTypeId = 2},
                new DebtPurposeType() { Id = 8, Name = "Закупуване на ДМА", DebtTypeId = 2},
                new DebtPurposeType() { Id = 9, Name = "Плащания по проекти, финансирани с ЕС", DebtTypeId = 1}

            };
        }

        public void SeedInterestTypeList()
        {

            interestTypeArr = new InterestType[]
            {
                new InterestType() { Id = 1, Name = "С отстъпка"},
                new InterestType() { Id = 2, Name = "Фиксиран"},
                new InterestType() { Id = 3, Name = "Плаващ"},
                new InterestType() { Id = 4, Name = "Нулев"},
                
            };
        }

        public void SeedCoverTypeList()
        {

            coverTypeArr = new CoverType[]
            {
                new CoverType() { Id = 1, Name = "Парични средства"},
                new CoverType() { Id = 2, Name = "Непарични средства"}
              
            };
        }

        public void SeedОperationTypeList()
        {

            operationTypeArr = new OperationType[]
            {
                new OperationType() { Id = 1, Name = "Плащане"},
                new OperationType() { Id = 2, Name = "Планирано плащане"},
                new OperationType() { Id = 3, Name = "Усвояване"},
                new OperationType() { Id = 4, Name = "Прогнозно усвояване"}

            };
        }

        public void SeedMunicipalCenterList()
        {

            municipalCenterArr = new MunicipalCenter[]
            {
                new MunicipalCenter() { Id = 1, Name = "Благоевград", MunicipalCenterCode = "51"},
                new MunicipalCenter() { Id = 2, Name = "Бургас",MunicipalCenterCode = "52"},
                new MunicipalCenter() { Id = 3, Name = "Варна", MunicipalCenterCode = "53" },
                new MunicipalCenter() { Id = 4, Name = "Велико Търново", MunicipalCenterCode = "54"},
                new MunicipalCenter() { Id = 5, Name = "Видин", MunicipalCenterCode = "55"},
                new MunicipalCenter() { Id = 6, Name = "Враца", MunicipalCenterCode = "56"},
                new MunicipalCenter() { Id = 7, Name = "Габрово", MunicipalCenterCode = "57"},
                new MunicipalCenter() { Id = 8, Name = "Добрич", MunicipalCenterCode = "58"},
                new MunicipalCenter() { Id = 9, Name = "Кърджали", MunicipalCenterCode = "59"},
                new MunicipalCenter() { Id = 10, Name = "Кюстендил", MunicipalCenterCode = "60"},
                new MunicipalCenter() { Id = 11, Name = "Ловеч", MunicipalCenterCode = "61"},
                new MunicipalCenter() { Id = 12, Name = "Монтана", MunicipalCenterCode = "62"},
                new MunicipalCenter() { Id = 13, Name = "Пазарджик", MunicipalCenterCode = "63"},
                new MunicipalCenter() { Id = 14, Name = "Перник", MunicipalCenterCode = "64"},
                new MunicipalCenter() { Id = 15, Name = "Плевен", MunicipalCenterCode = "65"},
                new MunicipalCenter() { Id = 16, Name = "Пловдив", MunicipalCenterCode = "66"},
                new MunicipalCenter() { Id = 17, Name = "Разград", MunicipalCenterCode = "67"},
                new MunicipalCenter() { Id = 18, Name = "Русе", MunicipalCenterCode = "68"},
                new MunicipalCenter() { Id = 19, Name = "Силистра", MunicipalCenterCode = "69"},
                new MunicipalCenter() { Id = 20, Name = "Сливен", MunicipalCenterCode = "70"},
                new MunicipalCenter() { Id = 21, Name = "Смолян", MunicipalCenterCode = "71"},
                new MunicipalCenter() { Id = 22, Name = "София - град", MunicipalCenterCode = "72"},
                new MunicipalCenter() { Id = 23, Name = "София", MunicipalCenterCode = "73"},
                new MunicipalCenter() { Id = 24, Name = "Стара Загора", MunicipalCenterCode = "74"},
                new MunicipalCenter() { Id = 25, Name = "Търговище", MunicipalCenterCode = "75"},
                new MunicipalCenter() { Id = 26, Name = "Хасково", MunicipalCenterCode = "76"},
                new MunicipalCenter() { Id = 27, Name = "Шумен", MunicipalCenterCode = "77"},
                new MunicipalCenter() { Id = 28, Name = "Ямбол", MunicipalCenterCode = "78"},

            };


        }



        public void SeedMunicipalityList()
        {

            municipalityArr = new Municipality[]
            {
                new Municipality() { Id = 1, Name = "Банско", MunicipalCode = "5101", MunicipalCenterId = 1},
                new Municipality() { Id = 2, Name = "Белица", MunicipalCode = "5102", MunicipalCenterId = 1},
                new Municipality() { Id = 3, Name = "Благоевград", MunicipalCode = "5103", MunicipalCenterId = 1},
                new Municipality() { Id = 4, Name = "Гоце Делчев", MunicipalCode = "5104", MunicipalCenterId = 1},
                new Municipality() { Id = 5, Name = "Гърмен", MunicipalCode = "5105", MunicipalCenterId = 1},
                new Municipality() { Id = 6, Name = "Кресна", MunicipalCode = "5106", MunicipalCenterId = 1},
                new Municipality() { Id = 7, Name = "Петрич", MunicipalCode = "5107", MunicipalCenterId = 1},
                new Municipality() { Id = 8, Name = "Разлог", MunicipalCode = "5108", MunicipalCenterId = 1},
                new Municipality() { Id = 9, Name = "Сандански", MunicipalCode = "5109", MunicipalCenterId = 1},
                new Municipality() { Id = 10, Name = "Сатовча", MunicipalCode = "5110", MunicipalCenterId = 1},
                new Municipality() { Id = 11, Name = "Симитли", MunicipalCode = "5111", MunicipalCenterId = 1},
                new Municipality() { Id = 12, Name = "Струмяни", MunicipalCode = "5112", MunicipalCenterId = 1},
                new Municipality() { Id = 13, Name = "Хаджидимово", MunicipalCode = "5113", MunicipalCenterId = 1},
                new Municipality() { Id = 14, Name = "Якоруда", MunicipalCode = "5114", MunicipalCenterId = 1},

                new Municipality() { Id = 15, Name = "Айтос", MunicipalCode = "5201", MunicipalCenterId = 2},
                new Municipality() { Id = 16, Name = "Бургас", MunicipalCode = "5202", MunicipalCenterId = 2},
                new Municipality() { Id = 17, Name = "Камено", MunicipalCode = "5203", MunicipalCenterId = 2},
                new Municipality() { Id = 18, Name = "Карнобат", MunicipalCode = "5204", MunicipalCenterId = 2},
                new Municipality() { Id = 19, Name = "Малко Търново", MunicipalCode = "5205", MunicipalCenterId = 2},
                new Municipality() { Id = 20, Name = "Несебър", MunicipalCode = "5206", MunicipalCenterId = 2},
                new Municipality() { Id = 21, Name = "Поморие", MunicipalCode = "5207", MunicipalCenterId = 2},
                new Municipality() { Id = 22, Name = "Приморско", MunicipalCode = "5208", MunicipalCenterId = 2},
                new Municipality() { Id = 23, Name = "Руен", MunicipalCode = "5209", MunicipalCenterId = 2},
                new Municipality() { Id = 24, Name = "Созопол", MunicipalCode = "5210", MunicipalCenterId = 2},
                new Municipality() { Id = 25, Name = "Средец", MunicipalCode = "5211", MunicipalCenterId = 2},
                new Municipality() { Id = 26, Name = "Сунгурларе", MunicipalCode = "5212", MunicipalCenterId = 2},
                new Municipality() { Id = 27, Name = "Царево", MunicipalCode = "5213", MunicipalCenterId = 2},

                new Municipality() { Id = 28, Name = "Аврен", MunicipalCode = "5301", MunicipalCenterId = 3},
                new Municipality() { Id = 29, Name = "Аксаково", MunicipalCode = "5302", MunicipalCenterId = 3},
                new Municipality() { Id = 30, Name = "Белослав", MunicipalCode = "5303", MunicipalCenterId = 3},
                new Municipality() { Id = 31, Name = "Бяла", MunicipalCode = "5304", MunicipalCenterId = 3},
                new Municipality() { Id = 32, Name = "Варна", MunicipalCode = "5305", MunicipalCenterId = 3},
                new Municipality() { Id = 33, Name = "Ветрино", MunicipalCode = "5306", MunicipalCenterId = 3},
                new Municipality() { Id = 34, Name = "Вълчидол", MunicipalCode = "5307", MunicipalCenterId = 3},
                new Municipality() { Id = 35, Name = "Девня", MunicipalCode = "5308", MunicipalCenterId = 3},
                new Municipality() { Id = 36, Name = "Долни Чифлик", MunicipalCode = "5309", MunicipalCenterId = 3},
                new Municipality() { Id = 37, Name = "Дългопол", MunicipalCode = "5310", MunicipalCenterId = 3},
                new Municipality() { Id = 38, Name = "Провадия", MunicipalCode = "5311", MunicipalCenterId = 3},
                new Municipality() { Id = 39, Name = "Суворово", MunicipalCode = "5312", MunicipalCenterId = 3},

                new Municipality() { Id = 40, Name = "Велико Търново", MunicipalCode = "5401", MunicipalCenterId = 4},
                new Municipality() { Id = 41, Name = "Горна Оряховица", MunicipalCode = "5402", MunicipalCenterId = 4},
                new Municipality() { Id = 42, Name = "Елена", MunicipalCode = "5403", MunicipalCenterId = 4},
                new Municipality() { Id = 43, Name = "Златарица", MunicipalCode = "5404", MunicipalCenterId = 4},
                new Municipality() { Id = 44, Name = "Лясковец", MunicipalCode = "5405", MunicipalCenterId = 4},
                new Municipality() { Id = 45, Name = "Павликени", MunicipalCode = "5406", MunicipalCenterId = 4},
                new Municipality() { Id = 46, Name = "Полски Тръмбеш", MunicipalCode = "5407", MunicipalCenterId = 4},
                new Municipality() { Id = 47, Name = "Свищов", MunicipalCode = "5408", MunicipalCenterId = 4},
                new Municipality() { Id = 48, Name = "Стражица", MunicipalCode = "5409", MunicipalCenterId = 4},
                new Municipality() { Id = 49, Name = "Сухиндол", MunicipalCode = "5410", MunicipalCenterId = 4},


                new Municipality() { Id = 50, Name = "Белоградчик", MunicipalCode = "5501", MunicipalCenterId = 5},
                new Municipality() { Id = 51, Name = "Бойница", MunicipalCode = "5502", MunicipalCenterId = 5},
                new Municipality() { Id = 52, Name = "Брегово", MunicipalCode = "5503", MunicipalCenterId = 5},
                new Municipality() { Id = 53, Name = "Видин", MunicipalCode = "5504", MunicipalCenterId = 5},
                new Municipality() { Id = 54, Name = "Грамада", MunicipalCode = "5505", MunicipalCenterId = 5},
                new Municipality() { Id = 55, Name = "Димово", MunicipalCode = "5506", MunicipalCenterId = 5},
                new Municipality() { Id = 56, Name = "Кула", MunicipalCode = "5507", MunicipalCenterId = 5},
                new Municipality() { Id = 57, Name = "Макреш", MunicipalCode = "5508", MunicipalCenterId = 5},
                new Municipality() { Id = 58, Name = "Ново село", MunicipalCode = "5509", MunicipalCenterId = 5},
                new Municipality() { Id = 59, Name = "Ружинци", MunicipalCode = "5510", MunicipalCenterId = 5},
                new Municipality() { Id = 60, Name = "Чупрене", MunicipalCode = "5511", MunicipalCenterId = 5},

                new Municipality() { Id = 61, Name = "Борован", MunicipalCode = "5601", MunicipalCenterId = 6},
                new Municipality() { Id = 62, Name = "Бяла Слатина", MunicipalCode = "5602", MunicipalCenterId = 6},
                new Municipality() { Id = 63, Name = "Враца", MunicipalCode = "5603", MunicipalCenterId = 6},
                new Municipality() { Id = 64, Name = "Козлодуй", MunicipalCode = "5604", MunicipalCenterId = 6},
                new Municipality() { Id = 65, Name = "Криводол", MunicipalCode = "5605", MunicipalCenterId = 6},
                new Municipality() { Id = 66, Name = "Мездра", MunicipalCode = "5606", MunicipalCenterId = 6},
                new Municipality() { Id = 67, Name = "Мизия", MunicipalCode = "5607", MunicipalCenterId = 6},
                new Municipality() { Id = 68, Name = "Оряхово", MunicipalCode = "5608", MunicipalCenterId = 6},
                new Municipality() { Id = 69, Name = "Роман", MunicipalCode = "5609", MunicipalCenterId = 6},
                new Municipality() { Id = 70, Name = "Хайредин", MunicipalCode = "5610", MunicipalCenterId = 6},

                new Municipality() { Id = 71, Name = "Габрово", MunicipalCode = "5701", MunicipalCenterId = 7},
                new Municipality() { Id = 72, Name = "Дряново", MunicipalCode = "5702", MunicipalCenterId = 7},
                new Municipality() { Id = 73, Name = "Севлиево", MunicipalCode = "5703", MunicipalCenterId = 7},
                new Municipality() { Id = 74, Name = "Трявна", MunicipalCode = "5704", MunicipalCenterId = 7},

                new Municipality() { Id = 75, Name = "Балчик", MunicipalCode = "5801", MunicipalCenterId = 8},
                new Municipality() { Id = 76, Name = "Генерал Тошево", MunicipalCode = "5802", MunicipalCenterId = 8},
                new Municipality() { Id = 77, Name = "Добрич", MunicipalCode = "5803", MunicipalCenterId = 8},
                new Municipality() { Id = 78, Name = "Каварна", MunicipalCode = "5804", MunicipalCenterId = 8},
                new Municipality() { Id = 79, Name = "Крушари", MunicipalCode = "5805", MunicipalCenterId = 8},
                new Municipality() { Id = 80, Name = "Тервел", MunicipalCode = "5806", MunicipalCenterId = 8},
                new Municipality() { Id = 81, Name = "Шабла", MunicipalCode = "5807", MunicipalCenterId = 8},
                new Municipality() { Id = 82, Name = "Добричка", MunicipalCode = "5808", MunicipalCenterId = 8},

                new Municipality() { Id = 83, Name = "Ардино", MunicipalCode = "5901", MunicipalCenterId = 9},
                new Municipality() { Id = 84, Name = "Джебел", MunicipalCode = "5902", MunicipalCenterId = 9},
                new Municipality() { Id = 85, Name = "Кирково", MunicipalCode = "5903", MunicipalCenterId = 9},
                new Municipality() { Id = 86, Name = "Крумовград", MunicipalCode = "5904", MunicipalCenterId = 9},
                new Municipality() { Id = 87, Name = "Кърджали", MunicipalCode = "5905", MunicipalCenterId = 9},
                new Municipality() { Id = 88, Name = "Момчилград", MunicipalCode = "5906", MunicipalCenterId = 9},
                new Municipality() { Id = 89, Name = "Черноочене", MunicipalCode = "5907", MunicipalCenterId = 9},

                new Municipality() { Id = 90, Name = "Бобовдол", MunicipalCode = "6001", MunicipalCenterId = 10},
                new Municipality() { Id = 91, Name = "Бобошево", MunicipalCode = "6002", MunicipalCenterId = 10},
                new Municipality() { Id = 92, Name = "Дупница", MunicipalCode = "6003", MunicipalCenterId = 10},
                new Municipality() { Id = 93, Name = "Кочериново", MunicipalCode = "6004", MunicipalCenterId = 10},
                new Municipality() { Id = 94, Name = "Кюстендил", MunicipalCode = "6005", MunicipalCenterId = 10},
                new Municipality() { Id = 95, Name = "Невестино", MunicipalCode = "6006", MunicipalCenterId = 10},
                new Municipality() { Id = 96, Name = "Рила", MunicipalCode = "6007", MunicipalCenterId = 10},
                new Municipality() { Id = 97, Name = "Сапарева баня", MunicipalCode = "6008", MunicipalCenterId = 10},
                new Municipality() { Id = 98, Name = "Трекляно", MunicipalCode = "6009", MunicipalCenterId = 10},

                new Municipality() { Id = 99, Name = "Априлци", MunicipalCode = "6101", MunicipalCenterId = 11},
                new Municipality() { Id = 100, Name = "Летница", MunicipalCode = "6102", MunicipalCenterId = 11},
                new Municipality() { Id = 101, Name = "Ловеч", MunicipalCode = "6103", MunicipalCenterId = 11},
                new Municipality() { Id = 102, Name = "Луковит", MunicipalCode = "6104", MunicipalCenterId = 11},
                new Municipality() { Id = 103, Name = "Тетевен", MunicipalCode = "6105", MunicipalCenterId = 11},
                new Municipality() { Id = 104, Name = "Троян", MunicipalCode = "6106", MunicipalCenterId = 11},
                new Municipality() { Id = 105, Name = "Угърчин", MunicipalCode = "6107", MunicipalCenterId = 11},
                new Municipality() { Id = 106, Name = "Ябланица", MunicipalCode = "6108", MunicipalCenterId = 11},

                new Municipality() { Id = 107, Name = "Берковица", MunicipalCode = "6201", MunicipalCenterId = 12},
                new Municipality() { Id = 108, Name = "Бойчиновци", MunicipalCode = "6202", MunicipalCenterId = 12},
                new Municipality() { Id = 109, Name = "Брусарци", MunicipalCode = "6203", MunicipalCenterId = 12},
                new Municipality() { Id = 110, Name = "Вълчедръм", MunicipalCode = "6204", MunicipalCenterId = 12},
                new Municipality() { Id = 111, Name = "Вършец", MunicipalCode = "6205", MunicipalCenterId = 12},
                new Municipality() { Id = 112, Name = "Георги Дамяново", MunicipalCode = "6206", MunicipalCenterId = 12},
                new Municipality() { Id = 113, Name = "Лом", MunicipalCode = "6207", MunicipalCenterId = 12},
                new Municipality() { Id = 114, Name = "Медковец", MunicipalCode = "6208", MunicipalCenterId = 12},
                new Municipality() { Id = 115, Name = "Монтана", MunicipalCode = "6209", MunicipalCenterId = 12},
                new Municipality() { Id = 116, Name = "Чипровци", MunicipalCode = "6210", MunicipalCenterId = 12},
                new Municipality() { Id = 117, Name = "Якимово", MunicipalCode = "6211", MunicipalCenterId = 12},

                new Municipality() { Id = 118, Name = "Батак", MunicipalCode = "6301", MunicipalCenterId = 13},
                new Municipality() { Id = 119, Name = "Белово", MunicipalCode = "6302", MunicipalCenterId = 13},
                new Municipality() { Id = 120, Name = "Брацигово", MunicipalCode = "6303", MunicipalCenterId = 13},
                new Municipality() { Id = 121, Name = "Велинград", MunicipalCode = "6304", MunicipalCenterId = 13},
                new Municipality() { Id = 122, Name = "Лесичево", MunicipalCode = "6305", MunicipalCenterId = 13},
                new Municipality() { Id = 123, Name = "Пазарджик", MunicipalCode = "6306", MunicipalCenterId = 13},
                new Municipality() { Id = 124, Name = "Панагюрище", MunicipalCode = "6307", MunicipalCenterId = 13},
                new Municipality() { Id = 125, Name = "Пещера", MunicipalCode = "6308", MunicipalCenterId = 13},
                new Municipality() { Id = 126, Name = "Ракитово", MunicipalCode = "6309", MunicipalCenterId = 13},
                new Municipality() { Id = 127, Name = "Септември", MunicipalCode = "6310", MunicipalCenterId = 13},
                new Municipality() { Id = 128, Name = "Стрелча", MunicipalCode = "6311", MunicipalCenterId = 13},
                new Municipality() { Id = 129, Name = "Сърница", MunicipalCode = "6312", MunicipalCenterId = 13},

                new Municipality() { Id = 130, Name = "Брезник", MunicipalCode = "6401", MunicipalCenterId = 14},
                new Municipality() { Id = 131, Name = "Земен", MunicipalCode = "6402", MunicipalCenterId = 14},
                new Municipality() { Id = 132, Name = "Ковачевци", MunicipalCode = "6403", MunicipalCenterId = 14},
                new Municipality() { Id = 133, Name = "Перник", MunicipalCode = "6404", MunicipalCenterId = 14},
                new Municipality() { Id = 134, Name = "Радомир", MunicipalCode = "6405", MunicipalCenterId = 14},
                new Municipality() { Id = 135, Name = "Трън", MunicipalCode = "6406", MunicipalCenterId = 14},

                new Municipality() { Id = 136, Name = "Белене", MunicipalCode = "6501", MunicipalCenterId = 15},
                new Municipality() { Id = 137, Name = "Гулянци", MunicipalCode = "6502", MunicipalCenterId = 15},
                new Municipality() { Id = 138, Name = "Долна Митрополия", MunicipalCode = "6503", MunicipalCenterId = 15},
                new Municipality() { Id = 139, Name = "Долни Дъбник", MunicipalCode = "6504", MunicipalCenterId = 15},
                new Municipality() { Id = 140, Name = "Искър", MunicipalCode = "6505", MunicipalCenterId = 15},
                new Municipality() { Id = 141, Name = "Левски", MunicipalCode = "6506", MunicipalCenterId = 15},
                new Municipality() { Id = 142, Name = "Никопол", MunicipalCode = "6507", MunicipalCenterId = 15},
                new Municipality() { Id = 143, Name = "Плевен", MunicipalCode = "6508", MunicipalCenterId = 15},
                new Municipality() { Id = 144, Name = "Пордим", MunicipalCode = "6509", MunicipalCenterId = 15},
                new Municipality() { Id = 145, Name = "Червен бряг", MunicipalCode = "6510", MunicipalCenterId = 15},
                new Municipality() { Id = 146, Name = "Кнежа", MunicipalCode = "6511", MunicipalCenterId = 15},

                new Municipality() { Id = 147, Name = "Асеновград", MunicipalCode = "6601", MunicipalCenterId = 16},
                new Municipality() { Id = 148, Name = "Брезово", MunicipalCode = "6602", MunicipalCenterId = 16},
                new Municipality() { Id = 149, Name = "Калояново", MunicipalCode = "6603", MunicipalCenterId = 16},
                new Municipality() { Id = 150, Name = "Карлово", MunicipalCode = "6604", MunicipalCenterId = 16},
                new Municipality() { Id = 151, Name = "Кричим", MunicipalCode = "6605", MunicipalCenterId = 16},
                new Municipality() { Id = 152, Name = "Лъки", MunicipalCode = "6606", MunicipalCenterId = 16},
                new Municipality() { Id = 153, Name = "Марица", MunicipalCode = "6607", MunicipalCenterId = 16},
                new Municipality() { Id = 154, Name = "Перущица", MunicipalCode = "6608", MunicipalCenterId = 16},
                new Municipality() { Id = 155, Name = "Пловдив", MunicipalCode = "6609", MunicipalCenterId = 16},
                new Municipality() { Id = 156, Name = "Първомай", MunicipalCode = "6610", MunicipalCenterId = 16},
                new Municipality() { Id = 157, Name = "Раковски", MunicipalCode = "6611", MunicipalCenterId = 16},
                new Municipality() { Id = 158, Name = "Родопи", MunicipalCode = "6612", MunicipalCenterId = 16},
                new Municipality() { Id = 159, Name = "Садово", MunicipalCode = "6613", MunicipalCenterId = 16},
                new Municipality() { Id = 160, Name = "Стамболийски", MunicipalCode = "6614", MunicipalCenterId = 16},
                new Municipality() { Id = 161, Name = "Съединение", MunicipalCode = "6615", MunicipalCenterId = 16},
                new Municipality() { Id = 162, Name = "Хисаря", MunicipalCode = "6616", MunicipalCenterId = 16},
                new Municipality() { Id = 163, Name = "Куклен", MunicipalCode = "6617", MunicipalCenterId = 16},
                new Municipality() { Id = 164, Name = "Сопот", MunicipalCode = "6618", MunicipalCenterId = 16},

                new Municipality() { Id = 165, Name = "Завет", MunicipalCode = "6701", MunicipalCenterId = 17},
                new Municipality() { Id = 166, Name = "Исперих", MunicipalCode = "6702", MunicipalCenterId = 17},
                new Municipality() { Id = 167, Name = "Кубрат", MunicipalCode = "6703", MunicipalCenterId = 17},
                new Municipality() { Id = 168, Name = "Лозница", MunicipalCode = "6704", MunicipalCenterId = 17},
                new Municipality() { Id = 169, Name = "Разград", MunicipalCode = "6705", MunicipalCenterId = 17},
                new Municipality() { Id = 170, Name = "Самуил", MunicipalCode = "6706", MunicipalCenterId = 17},
                new Municipality() { Id = 171, Name = "Цар Калоян", MunicipalCode = "6707", MunicipalCenterId = 17},

                new Municipality() { Id = 172, Name = "Борово", MunicipalCode = "6801", MunicipalCenterId = 18},
                new Municipality() { Id = 173, Name = "Бяла", MunicipalCode = "6802", MunicipalCenterId = 18},
                new Municipality() { Id = 174, Name = "Ветово", MunicipalCode = "6803", MunicipalCenterId = 18},
                new Municipality() { Id = 175, Name = "Две могили", MunicipalCode = "6804", MunicipalCenterId = 18},
                new Municipality() { Id = 176, Name = "Иваново", MunicipalCode = "6805", MunicipalCenterId = 18},
                new Municipality() { Id = 177, Name = "Русе", MunicipalCode = "6806", MunicipalCenterId = 18},
                new Municipality() { Id = 178, Name = "Сливо поле", MunicipalCode = "6807", MunicipalCenterId = 18},
                new Municipality() { Id = 179, Name = "Ценово", MunicipalCode = "6808", MunicipalCenterId = 18},

                new Municipality() { Id = 180, Name = "Алфатар", MunicipalCode = "6901", MunicipalCenterId = 19},
                new Municipality() { Id = 181, Name = "Главиница", MunicipalCode = "6902", MunicipalCenterId = 19},
                new Municipality() { Id = 182, Name = "Дулово", MunicipalCode = "6903", MunicipalCenterId = 19},
                new Municipality() { Id = 183, Name = "Кайнарджа", MunicipalCode = "6904", MunicipalCenterId = 19},
                new Municipality() { Id = 184, Name = "Силистра", MunicipalCode = "6905", MunicipalCenterId = 19},
                new Municipality() { Id = 185, Name = "Ситово", MunicipalCode = "6906", MunicipalCenterId = 19},
                new Municipality() { Id = 186, Name = "Тутракан", MunicipalCode = "6907", MunicipalCenterId = 19},

                new Municipality() { Id = 187, Name = "Котел", MunicipalCode = "7001", MunicipalCenterId = 20},
                new Municipality() { Id = 188, Name = "Нова Загора", MunicipalCode = "7002", MunicipalCenterId = 20},
                new Municipality() { Id = 189, Name = "Сливен", MunicipalCode = "7003", MunicipalCenterId = 20},
                new Municipality() { Id = 190, Name = "Твърдица", MunicipalCode = "7004", MunicipalCenterId = 20},

                new Municipality() { Id = 191, Name = "Баните", MunicipalCode = "7101", MunicipalCenterId = 21},
                new Municipality() { Id = 192, Name = "Борино", MunicipalCode = "7102", MunicipalCenterId = 21},
                new Municipality() { Id = 193, Name = "Девин", MunicipalCode = "7103", MunicipalCenterId = 21},
                new Municipality() { Id = 194, Name = "Доспат", MunicipalCode = "7104", MunicipalCenterId = 21},
                new Municipality() { Id = 195, Name = "Златоград", MunicipalCode = "7105", MunicipalCenterId = 21},
                new Municipality() { Id = 196, Name = "Мадан", MunicipalCode = "7106", MunicipalCenterId = 21},
                new Municipality() { Id = 197, Name = "Неделино", MunicipalCode = "7107", MunicipalCenterId = 21},
                new Municipality() { Id = 198, Name = "Рудозем", MunicipalCode = "7108", MunicipalCenterId = 21},
                new Municipality() { Id = 199, Name = "Смолян", MunicipalCode = "7109", MunicipalCenterId = 21},
                new Municipality() { Id = 200, Name = "Чепеларе", MunicipalCode = "7110", MunicipalCenterId = 21},

                new Municipality() { Id = 201, Name = "Район Банкя", MunicipalCode = "7201", MunicipalCenterId = 22},
                new Municipality() { Id = 202, Name = "Район Витоша", MunicipalCode = "7202", MunicipalCenterId = 22},
                new Municipality() { Id = 203, Name = "Район Възраждане", MunicipalCode = "7203", MunicipalCenterId = 22},
                new Municipality() { Id = 204, Name = "Район Връбница", MunicipalCode = "7204", MunicipalCenterId = 22},
                new Municipality() { Id = 205, Name = "Район Илинден", MunicipalCode = "7205", MunicipalCenterId = 22},
                new Municipality() { Id = 206, Name = "Район Искър", MunicipalCode = "7206", MunicipalCenterId = 22},
                new Municipality() { Id = 207, Name = "Район Изгрев", MunicipalCode = "7207", MunicipalCenterId = 22},
                new Municipality() { Id = 208, Name = "Район Красна Поляна", MunicipalCode = "7208", MunicipalCenterId = 22},
                new Municipality() { Id = 209, Name = "Район Красно село", MunicipalCode = "7209", MunicipalCenterId = 22},
                new Municipality() { Id = 210, Name = "Район Кремиковци", MunicipalCode = "7210", MunicipalCenterId = 22},
                new Municipality() { Id = 211, Name = "Район Лозенец", MunicipalCode = "7211", MunicipalCenterId = 22},
                new Municipality() { Id = 212, Name = "Район Люлин", MunicipalCode = "7212", MunicipalCenterId = 22},
                new Municipality() { Id = 213, Name = "Район Младост", MunicipalCode = "7213", MunicipalCenterId = 22},
                new Municipality() { Id = 214, Name = "Район Надежда", MunicipalCode = "7214", MunicipalCenterId = 22},
                new Municipality() { Id = 215, Name = "Район Нови Искър", MunicipalCode = "7215", MunicipalCenterId = 22},
                new Municipality() { Id = 216, Name = "Район Оборище", MunicipalCode = "7216", MunicipalCenterId = 22},
                new Municipality() { Id = 217, Name = "Район Овча Купел", MunicipalCode = "7217", MunicipalCenterId = 22},
                new Municipality() { Id = 218, Name = "Район Панчарево", MunicipalCode = "7218", MunicipalCenterId = 22},
                new Municipality() { Id = 219, Name = "Район Подуяне", MunicipalCode = "7219", MunicipalCenterId = 22},
                new Municipality() { Id = 220, Name = "Район Сердика", MunicipalCode = "7220", MunicipalCenterId = 22},
                new Municipality() { Id = 221, Name = "Район Слатина", MunicipalCode = "7221", MunicipalCenterId = 22},
                new Municipality() { Id = 222, Name = "Район Средец", MunicipalCode = "7222", MunicipalCenterId = 22},
                new Municipality() { Id = 223, Name = "Район Студентска", MunicipalCode = "7223", MunicipalCenterId = 22},
                new Municipality() { Id = 224, Name = "Район Триадица", MunicipalCode = "7224", MunicipalCenterId = 22},
                new Municipality() { Id = 225, Name = "Столична община", MunicipalCode = "7225", MunicipalCenterId = 22},

                new Municipality() { Id = 226, Name = "Антон", MunicipalCode = "7301", MunicipalCenterId = 23},
                new Municipality() { Id = 227, Name = "Божурище", MunicipalCode = "7202", MunicipalCenterId = 23},
                new Municipality() { Id = 228, Name = "Ботевград", MunicipalCode = "7303", MunicipalCenterId = 23},
                new Municipality() { Id = 229, Name = "Годеч", MunicipalCode = "7304", MunicipalCenterId = 23},
                new Municipality() { Id = 230, Name = "Горна Малина", MunicipalCode = "7305", MunicipalCenterId = 23},
                new Municipality() { Id = 231, Name = "Долна Баня", MunicipalCode = "7306", MunicipalCenterId = 23},
                new Municipality() { Id = 232, Name = "Драгоман", MunicipalCode = "7307", MunicipalCenterId = 23},
                new Municipality() { Id = 233, Name = "Елин Пелин", MunicipalCode = "7308", MunicipalCenterId = 23},
                new Municipality() { Id = 234, Name = "Етрополе", MunicipalCode = "7309", MunicipalCenterId = 23},
                new Municipality() { Id = 235, Name = "Златица", MunicipalCode = "7310", MunicipalCenterId = 23},
                new Municipality() { Id = 236, Name = "Ихтиман", MunicipalCode = "7311", MunicipalCenterId = 23},
                new Municipality() { Id = 237, Name = "Копривщица", MunicipalCode = "7312", MunicipalCenterId = 23},
                new Municipality() { Id = 238, Name = "Костенец", MunicipalCode = "7313", MunicipalCenterId = 23},
                new Municipality() { Id = 239, Name = "Костинброд", MunicipalCode = "7314", MunicipalCenterId = 23},
                new Municipality() { Id = 240, Name = "Мирково", MunicipalCode = "7315", MunicipalCenterId = 23},
                new Municipality() { Id = 241, Name = "Пирдоп", MunicipalCode = "7316", MunicipalCenterId = 23},
                new Municipality() { Id = 242, Name = "Правец", MunicipalCode = "7317", MunicipalCenterId = 23},
                new Municipality() { Id = 243, Name = "Самоков", MunicipalCode = "7318", MunicipalCenterId = 23},
                new Municipality() { Id = 244, Name = "Своге", MunicipalCode = "7319", MunicipalCenterId = 23},
                new Municipality() { Id = 245, Name = "Сливница", MunicipalCode = "7320", MunicipalCenterId = 23},
                new Municipality() { Id = 246, Name = "Чавдар", MunicipalCode = "7321", MunicipalCenterId = 23},
                new Municipality() { Id = 247, Name = "Челопеч", MunicipalCode = "7322", MunicipalCenterId = 23},

                new Municipality() { Id = 248, Name = "Братя Даскалови", MunicipalCode = "7401", MunicipalCenterId = 24},
                new Municipality() { Id = 249, Name = "Гурково", MunicipalCode = "7432", MunicipalCenterId = 24},
                new Municipality() { Id = 250, Name = "Гълъбово", MunicipalCode = "7403", MunicipalCenterId = 24},
                new Municipality() { Id = 251, Name = "Казанлък", MunicipalCode = "7404", MunicipalCenterId = 24},
                new Municipality() { Id = 252, Name = "Мъглиж", MunicipalCode = "7405", MunicipalCenterId = 24},
                new Municipality() { Id = 253, Name = "Николаево", MunicipalCode = "7406", MunicipalCenterId = 24},
                new Municipality() { Id = 254, Name = "Опан", MunicipalCode = "7407", MunicipalCenterId = 24},
                new Municipality() { Id = 255, Name = "Павел баня", MunicipalCode = "7408", MunicipalCenterId = 24},
                new Municipality() { Id = 256, Name = "Раднево", MunicipalCode = "7409", MunicipalCenterId = 24},
                new Municipality() { Id = 257, Name = "Стара Загора", MunicipalCode = "7410", MunicipalCenterId = 24},
                new Municipality() { Id = 258, Name = "Чирпан", MunicipalCode = "7411", MunicipalCenterId = 24},

                new Municipality() { Id = 259, Name = "Антоново", MunicipalCode = "7501", MunicipalCenterId = 25},
                new Municipality() { Id = 260, Name = "Омуртаг", MunicipalCode = "7502", MunicipalCenterId = 25},
                new Municipality() { Id = 261, Name = "Опака", MunicipalCode = "7503", MunicipalCenterId = 25},
                new Municipality() { Id = 262, Name = "Попово", MunicipalCode = "7504", MunicipalCenterId = 25},
                new Municipality() { Id = 263, Name = "Търговище", MunicipalCode = "7505", MunicipalCenterId = 25},

                new Municipality() { Id = 264, Name = "Димитровград", MunicipalCode = "7601", MunicipalCenterId = 26},
                new Municipality() { Id = 265, Name = "Ивайловград", MunicipalCode = "7602", MunicipalCenterId = 26},
                new Municipality() { Id = 266, Name = "Любимец", MunicipalCode = "7603", MunicipalCenterId = 26},
                new Municipality() { Id = 267, Name = "Маджарово", MunicipalCode = "7604", MunicipalCenterId = 26},
                new Municipality() { Id = 268, Name = "Минерални Бани", MunicipalCode = "7605", MunicipalCenterId = 26},
                new Municipality() { Id = 269, Name = "Свиленград", MunicipalCode = "7606", MunicipalCenterId = 26},
                new Municipality() { Id = 270, Name = "Симеоновград", MunicipalCode = "7607", MunicipalCenterId = 26},
                new Municipality() { Id = 271, Name = "Стамболово", MunicipalCode = "7608", MunicipalCenterId = 26},
                new Municipality() { Id = 272, Name = "Тополовград", MunicipalCode = "7609", MunicipalCenterId = 26},
                new Municipality() { Id = 273, Name = "Харманли", MunicipalCode = "7610", MunicipalCenterId = 26},
                new Municipality() { Id = 274, Name = "Хасково", MunicipalCode = "7611", MunicipalCenterId = 26},

                new Municipality() { Id = 275, Name = "Велики Преслав", MunicipalCode = "7701", MunicipalCenterId = 27},
                new Municipality() { Id = 276, Name = "Венец", MunicipalCode = "7702", MunicipalCenterId = 27},
                new Municipality() { Id = 277, Name = "Върбица", MunicipalCode = "7703", MunicipalCenterId = 27},
                new Municipality() { Id = 278, Name = "Каолиново", MunicipalCode = "7704", MunicipalCenterId = 27},
                new Municipality() { Id = 279, Name = "Каспичан", MunicipalCode = "7705", MunicipalCenterId = 27},
                new Municipality() { Id = 280, Name = "Никола Козлево", MunicipalCode = "7706", MunicipalCenterId = 27},
                new Municipality() { Id = 281, Name = "Нови пазар", MunicipalCode = "7707", MunicipalCenterId = 27},
                new Municipality() { Id = 282, Name = "Смядово", MunicipalCode = "7708", MunicipalCenterId = 27},
                new Municipality() { Id = 283, Name = "Хитрино", MunicipalCode = "7709", MunicipalCenterId = 27},
                new Municipality() { Id = 284, Name = "Шумен", MunicipalCode = "7710", MunicipalCenterId = 27},

                new Municipality() { Id = 285, Name = "Болярово", MunicipalCode = "7801", MunicipalCenterId = 28},
                new Municipality() { Id = 286, Name = "Елхово", MunicipalCode = "7802", MunicipalCenterId = 28},
                new Municipality() { Id = 287, Name = "Стралджа", MunicipalCode = "7803", MunicipalCenterId = 28},
                new Municipality() { Id = 288, Name = "Тунджа", MunicipalCode = "7804", MunicipalCenterId = 28},
                new Municipality() { Id = 289, Name = "Ямбол", MunicipalCode = "7805", MunicipalCenterId = 28},

            };


        }


        public void SeedCurrencyList()
        {

            currencyArr = new Currency[]
            {
                new Currency() { Id = 1, Name = "Български лев", CurrencyCode = "BGN"},
                new Currency() { Id = 2, Name = "Евро", CurrencyCode = "EUR"},
                new Currency() { Id = 3, Name = "Kанaдски долар", CurrencyCode = "CAD"},
                new Currency() { Id = 4, Name = "Швейцарски франк", CurrencyCode = "CHF"},
                new Currency() { Id = 5, Name = "Британски паунд", CurrencyCode = "GBP"},
                new Currency() { Id = 6, Name = "Японска йена", CurrencyCode = "JPY"},
                new Currency() { Id = 7, Name = "Румънска лея", CurrencyCode = "RON"},
                new Currency() { Id = 8, Name = "Американски долар", CurrencyCode = "USD"},
            };
        }

        public void SeedCurrencyRateList()
        {

            currencyRateArr = new CurrencyRate[]
            {
                new CurrencyRate() { Id = 1, CurrencyId = 1, RateToBGN = 1M, RateFromBGN = 1M},
                new CurrencyRate() { Id = 2, CurrencyId = 2, RateToBGN = 1.9558M, RateFromBGN = 0.5112M},
                new CurrencyRate() { Id = 3, CurrencyId = 3, RateToBGN = 1.3164M, RateFromBGN = 0.7593M},
                new CurrencyRate() { Id = 4, CurrencyId = 4, RateToBGN = 2.0893M, RateFromBGN = 0.4786M},
                new CurrencyRate() { Id = 5, CurrencyId = 5, RateToBGN = 2.3413M, RateFromBGN = 0.4271M},
                new CurrencyRate() { Id = 6, CurrencyId = 6, RateToBGN = 0.0120M, RateFromBGN = 83.2126M},
                new CurrencyRate() { Id = 7, CurrencyId = 7, RateToBGN = 0.3928M, RateFromBGN = 2.5448M},
                new CurrencyRate() { Id = 8, CurrencyId = 8, RateToBGN = 1.8552M, RateFromBGN = 0.5388M},
            };
        }

        //private async Task SeedRole()
        //{
        //    bool roleAdminExists = await roleManager.RoleExistsAsync("Administrator");

        //    if (roleAdminExists == false)
        //    {
        //        var role = new IdentityRole("Administrator");
        //        await roleManager.CreateAsync(role);

        //    }

        //    bool roleMunicipalExists = await roleManager.RoleExistsAsync("UserMun");

        //    if (roleMunicipalExists == false)
        //    {
        //        var role = new IdentityRole("UserMun");
        //        await roleManager.CreateAsync(role);

        //    }


            //var admin = await userManager.FindByEmailAsync("adminDebt@mail.bg");

            //if (admin != null)
            //{
            //    await userManager.AddToRoleAsync(admin, "Administrator");
            //}

           
        //}

        //private void SeedUsers()
        //{
        //    var hasher = new PasswordHasher<ApplicationUser>();

        //    adminUser = new ApplicationUser()
        //    {
        //        Id = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3", 
        //        UserName = "adminDebt@mail.bg",
        //        NormalizedUserName = "admindebt@mail.com",
        //        Email = "adminDebt@mail.bg",
        //        NormalizedEmail = "admindebt@mail.bg",
        //        FirstName = "Иван",
        //        LastName = "Петров",
        //        MunicipalityId = null
        //    };

        //    AdminUserClaim = new IdentityUserClaim<string>()
        //    {
        //        Id = 1,
        //        ClaimType = UserFullNameClaim,
        //        ClaimValue = "Иван Петров",
        //        UserId = "c398bf2f-e8b0-4c64-a99b-492c8c29e9c3" 
        //    };

        //    adminUser.PasswordHash =
        //         hasher.HashPassword(adminUser, "DebtAdmin123");

        //    BurgasMunicipalityUser = new ApplicationUser()
        //    {
        //        Id = "22ad10a0-2f69-4735-bd2c-9e944cd80baf", 
        //        UserName = "burgas_municipal@mail.bg",
        //        NormalizedUserName = "burgas_municipal@mail.bg",
        //        Email = "burgas_municipal@mail.bg",
        //        NormalizedEmail = "burgas_municipal@mail.bg",
        //        FirstName = "Стоян",
        //        LastName = "Георгиев",
        //        MunicipalityId = 16
        //    };
            
        //    BurgasUserClaim = new IdentityUserClaim<string>()
        //    {
        //        Id = 2,
        //        ClaimType = UserFullNameClaim,
        //        ClaimValue = "Стоян Георгиев",
        //        UserId = "22ad10a0-2f69-4735-bd2c-9e944cd80baf"  
        //    };

        //    BurgasMunicipalityUser.PasswordHash =
        //    hasher.HashPassword(BurgasMunicipalityUser, "BurgasMun123");

        //    VarnaMunicipalityUser = new ApplicationUser()
        //    {
        //        Id = "faf648ad-8f38-459d-909f-256f9a167a44",  
        //        UserName = "VarnaMun@mail.com",
        //        NormalizedUserName = "varnamun@mail.com",
        //        Email = "VarnaMun@mail.com",
        //        NormalizedEmail = "varnamun@mail.com",
        //        FirstName = "Георги",
        //        LastName = "Василев"
        //    };

        //    VarnaUserClaim = new IdentityUserClaim<string>()
        //    {
        //        Id = 3,
        //        ClaimType = UserFullNameClaim,
        //        UserId = "faf648ad-8f38-459d-909f-256f9a167a44", 
        //        ClaimValue = "Георги Василев"
        //    };

        //    adminUser.PasswordHash =
        //    hasher.HashPassword(VarnaMunicipalityUser, "VarnaMun123");
        //}

        //private async Task SeedRolesToUsers()
        //{
        //    var admin = await userManager.FindByEmailAsync("adminDebt@mail.bg");

        //    if (admin != null)
        //    {
        //        await userManager.AddToRoleAsync(admin, "Administrator");
        //    }

            
        //}

    }
}
