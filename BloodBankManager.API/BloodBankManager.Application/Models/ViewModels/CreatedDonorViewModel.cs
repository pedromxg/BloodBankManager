using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class CreatedDonorViewModel
    {
        public CreatedDonorViewModel(Guid id)
        {
            Id = Convert.ToInt32(id);
        }

        public int Id { get; set; }
    }
}
