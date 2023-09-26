using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string prefabPath);
        GameObject Instantiate(string prefabPath, Vector3 position);
        Task<T> Load<T>(AssetReference assetReference) where T : class;
    }
}