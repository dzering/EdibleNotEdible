using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory : IService
    {
        Task<GameObject> CreateGameItemAsync(ItemTypeID typeID, Vector3 position);
        GameObject CreateBasket(Vector3 position, IProgressService progressService, BasketTypeID basketTypeID);
    }
}