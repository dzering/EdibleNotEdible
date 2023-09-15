using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string prefabPath);
        GameObject Instantiate(string prefabPath, Vector3 position);
    }
}