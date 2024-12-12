using MunicipalityDebtsSystem.Core.Models.Payment;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Contracts
{
    public interface IPaymentService
    {
        Task AddPlannedPaymentAsync(AddPlannedPaymentViewModel model, string userId, int municipalityId, DateTime datePayment);
        Task<IEnumerable<PlannedPaymentListViewModel>> GetAllPlannedPaymentsAsync(int id);
        Task<bool> PlannedPaymentHasChildsAsync(int id);
        Task RemovePayment(int id);
        Task<Payment> GetPaymentEntityByIdAsync(int id);
    }
}
