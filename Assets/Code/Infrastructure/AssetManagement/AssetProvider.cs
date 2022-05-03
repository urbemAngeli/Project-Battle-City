using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            GameObject prefab = Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public T Instantiate<T>(string path) where T : MonoBehaviour
        {
            GameObject go = Instantiate(path);
            return go?.GetComponent<T>();
        }

        public T Load<T>(string path) where T : Object => 
            Resources.Load<T>(path);
    }
}