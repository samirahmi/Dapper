using Day14_Dapper.Applications.Divisions.Dto;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Divisions
{
    public interface IDivisionAppService
    {
        void Insert(Division division);
        void Delete(Guid Id);
        void Update(Division division);
        List<DivisionDto> GetAllDivision();
        DivisionDto GetById(Guid Id);
        Division GetModelById(Guid Id);
    }
}
