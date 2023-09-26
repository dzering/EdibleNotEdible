using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadBaskets();
        BasketStaticData ForBasket(BasketTypeID basketTypeID);
        void LoadItems();
        ItemStaticData ForItem(ItemTypeID typeID);
    }
}