using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();
    static PoolManager _instance;
    [HideInInspector]public GameObject newObject;
    [HideInInspector] public ParticleSystem newParticle;
    public GameObject storage;
    [HideInInspector]public float time;
    public static PoolManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>();
            }
            return _instance;
        }
    }
    void Update()
    {
        time += Time.deltaTime;
    }
    public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();
        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());

            for (int i =0;i < poolSize; i++)
            {
                this.newObject = (Instantiate(prefab,this.transform) as GameObject);
                newObject.SetActive(false);
                poolDictionary[poolKey].Enqueue(newObject);
                newObject.transform.SetParent(storage.transform) ;
            }
        }
    }

    public void ReusePool(GameObject prefab, Vector3 position , Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        if (poolDictionary.ContainsKey(poolKey))
        {
            GameObject objectToReuse = poolDictionary[poolKey].Dequeue();
            poolDictionary[poolKey].Enqueue(objectToReuse);

            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
        }
    }


    //IEnumerator OpenParticle(GameObject prefab)
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    prefab.SetActive(true);
    //}

    //public class ObjectInstance
    //{
    //    GameObject gameObject;
    //    Transform transform;

    //    bool hasPoolObjectComponent;
    //    PoolObject poolObjectScript;
    //    public ObjectInstance(GameObject objectInstance)
    //    {
    //        gameObject = objectInstance;
    //        transform = gameObject.transform;
    //        gameObject.SetActive(false);
    //        if (gameObject.GetComponent<PoolObject>())
    //        {
    //            hasPoolObjectComponent = true;
    //            poolObjectScript = gameObject.GetComponent<PoolObject>();
    //        }
    //    }
    //}
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}
