using UnityEngine;
using UnityEngine.Pool;



public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] public ObjectPool<GameObject> objectpool;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        objectpool = new ObjectPool<GameObject>(
            createFunc: CreateObject,
            actionOnGet: GetObject,
            actionOnRelease: ReturnObject,
            actionOnDestroy: DestroyObject,
            collectionCheck: false,
            defaultCapacity: size,
            maxSize: size
            );
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        return obj;
    }

    void GetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }

     void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
