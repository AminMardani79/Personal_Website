using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IMajorRepository
    {
        Task<IEnumerable<Major>> GetMajoresList(string search, int skip, int take);
        Task<Major> GetMajorById(int majorId);
        void CreateMajor(Major major);
        void DeleteMajor(Major major);
        void UpdateMajor(Major major);
        void Save();
        Task<IEnumerable<Major>> ShowMajors();
    }
}