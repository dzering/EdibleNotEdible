using CodeBase.Data;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Factories
{
    public interface IGameFactory : IService
    {
        GameObject CreateGameItem(Vector3 position);
        GameObject CreateBasket(Vector3 position, IProgressService progressService, Criterion criterion);
    }
}