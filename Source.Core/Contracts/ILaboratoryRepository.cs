using Source.Core.Objects;
using Source.Core.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Core.Contracts
{
    public interface ILaboratoryRepository
    {
        Task<List<LabTest>> GetAll(LabTestParameter param);
        Task Import(LabTest obj, string userName);
        Task<int> CheckItemColorCode(string ItemColorCode);
    }
}
