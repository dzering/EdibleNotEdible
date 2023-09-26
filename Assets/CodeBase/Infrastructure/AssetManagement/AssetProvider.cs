using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCash = new Dictionary<string, AsyncOperationHandle>();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

        public async Task<T> Load<T>(AssetReference prefabReference) where T : class
        {
            if (_completedCash.TryGetValue(prefabReference.AssetGUID, out AsyncOperationHandle handleCompleted))
                return handleCompleted.Result as T;
            
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(prefabReference);

            handle.Completed += h =>
            {
                _completedCash[prefabReference.AssetGUID] = h;
            };
            AddHandle(prefabReference.AssetGUID, handle);

            return await handle.Task;
        }

        public void CleanUp()
        {
            foreach (KeyValuePair<string,List<AsyncOperationHandle>> resourceHandle in _handles)
            foreach (AsyncOperationHandle handle in resourceHandle.Value)
                Addressables.Release(handle);
        }

        private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[key] = resourceHandles;
            }

            resourceHandles.Add(handle);
        }

        public GameObject Instantiate(string prefabPath)
        {
            var pref = Resources.Load<GameObject>(prefabPath);
            return Object.Instantiate(pref);
        }

        public GameObject Instantiate(string prefabPath, Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(prefabPath);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}