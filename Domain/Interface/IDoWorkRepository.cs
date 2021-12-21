using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDoWorkRepository
    {
        Task<IEnumerable<DoWork>> GetDoWorksList(string search,int skip,int take);
        Task<DoWork> GetDoWorkById(int workId);
        void CreateDoWork(DoWork work);
        void DeleteDoWork(DoWork work);
        void UpdateDoWork(DoWork work);
        void Save();

        Task<IEnumerable<DoWork>> ShowDoWorks();
        Task<int> GetDoWorksCount();
    }
}