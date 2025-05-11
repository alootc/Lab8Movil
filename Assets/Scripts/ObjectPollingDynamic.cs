using System.Collections.Generic;
using UnityEngine;

public class ObjectPollingDynamic : MonoBehaviour
{
    public List<GameObject> object_pool = new();
    public GameObject prefab;

    public static ObjectPollingDynamic instace = null;

    private void Awake()
    {
        instace = this; 
    }
    public void GetObject(Vector3 position)
    {
        GameObject tmp;
        if(object_pool.Count > 0)
        {
            tmp = object_pool[0];
            object_pool.Remove(tmp);

            tmp.SetActive(true);
            tmp.GetComponent<Bullet>().Init(position); 
        }
        else
        {
            tmp = Instantiate(prefab, transform.position, transform.rotation);
            //tmp.GetComponent <Bullet>().SetObjectPool(this);
            tmp.GetComponent<Bullet>().Init(position);
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(true);
        }
    }

    public void SetObject(GameObject obj)
    {
        object_pool.Add(obj);
    }
}
