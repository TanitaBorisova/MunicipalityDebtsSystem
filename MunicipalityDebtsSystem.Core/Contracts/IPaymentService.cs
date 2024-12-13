using MunicipalityDebtsSystem.Core.Models.Draw;
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

        Task<List<PlannedPaymentDateViewModel>> GetAllPlannedPaymentDatesAsync(int id);

        Task AddRealAsync(AddPaymentViewModel model, string userId, int municipalityId, DateTime datePayment, int paymentParentId);

        Task<Payment> GetPlannedPaymentInfoByIdAsync(int id);

        Task<IEnumerable<PlannedPaymentListViewModel>> GetAllPaymentsAsync(int id);
    }
}
