using System;
using System.Linq;
using Wellmer.Domain.Entities;

namespace Wellmer.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository        //Paslugu CRUD operacijos
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
