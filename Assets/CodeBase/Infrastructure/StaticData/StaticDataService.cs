using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string STATIC_DATA_BASKETS = "StaticData/Baskets";
        private const string STATIC_DATA_ITEMS = "StaticData/Items";
        private Dictionary<BasketTypeID, BasketStaticData> _baskets;
        private Dictionary<ItemTypeID, ItemStaticData> _items;

        public void LoadItems()
        {
            _items = Resources
                .LoadAll<ItemStaticData>(STATIC_DATA_ITEMS)
                .ToDictionary(x => x.ItemTypeID, x => x);
        }

        public ItemStaticData ForItem(ItemTypeID typeID)
        {
            return _items.TryGetValue(typeID, out ItemStaticData itemStaticData)
                ? itemStaticData
                : null;
        }

        public void LoadBaskets()
        {
            _baskets = Resources
                .LoadAll<BasketStaticData>(STATIC_DATA_BASKETS)
                .ToDictionary(x => x._basketTypeID, x => x);
        }

        public BasketStaticData ForBasket(BasketTypeID basketTypeID)
        {
            return _baskets.TryGetValue(basketTypeID, out BasketStaticData staticData)
                ? staticData
                : null;
        }
    }
}