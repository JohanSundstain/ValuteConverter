using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankConverter.Model;

namespace BankConverter.Repository
{
    public interface IRestRepository
    {

        Task<ValCurs> GetCurs(DateTime? selectedDate);

        Task<ValCurs> GetCurs();
    }
}
