using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        public CreditorType[] creditorTypeArr;
        public CreditType[] creditTypeArr;
        public CreditStatusType[] creditStatusTypeArr;
        public DebtType[] debtTypeArr;
        public DebtPurposeType[] debtPurposeTypeArr;
        public InterestType[] interestTypeArr;

        public SeedData()
        {
            SeedCreditorTypeList();
            SeedCreditTypeList();
            SeedCreditStatusTypeList();
            SeedDebtTypeList();
            SeedDebtPurposeTypeList();
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


    }
}
