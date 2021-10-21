using Entity.Manage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.AutofacManager;
using Service.IService;
using Utility;
using Common;
using Common.Repository;
using Common.OrderByExpressions;
using Service.IService.IManagers;

namespace Service.Service.Managers
{
   public  class ManagerService:IManagerService
    {
       
        private readonly IRepository<Manager> _manager;
        //private readonly IOrderByExpression<Manager>[] _orderbyinfo =
        //{
        //    new OrderByExpression<Manager, DateTime>(u => u.CreatedTime, true)
        //};

        public ManagerService(IRepository<Manager> manager)
        {
            _manager = manager;
        }


        public int Add(Entity.Manage.Manager manager)
        {
            _manager.Add(manager);
            return _manager.Save() > 0 ? 1 : 0;
        }
        public List<Manager> Query()
        {
            // var ListModel = _manager.Query(null, _orderbyinfo).ToList();
            //return ListModel;
            return null;
        }
        public Manager Find(int id)
        {
            var ListModel = _manager.Find(s=>s.ID==id);
            if (ListModel != null)
                return ListModel;
            
            return null;
        }
        public int Modify(Entity.Manage.Manager information)
        {
            throw new NotImplementedException();
        }

        public int Remove(List<int> ID)
        {
            throw new NotImplementedException();
        }
    }
}
