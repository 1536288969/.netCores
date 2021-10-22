using Common.AutofacManager;
using Common.Repository;
using Entity;
using Entity.Manage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IService.IManagers
{
   public interface IManagerService
    {
        Manager Find(int id);
        List<Manager> Query();
        int Add(Manager information);
        int Modify(Manager information);
        int Remove(List<int> ID);
    }
}
