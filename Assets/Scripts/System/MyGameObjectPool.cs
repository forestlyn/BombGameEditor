//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MyGameObjectPool : MonoBehaviour
//{
//    private Queue<GameObject> m_pool;
//    public DataList dataList;
//    public GameObject prefab;
//    private static MyGameObjectPool instance;
//    public static MyGameObjectPool Instance { get { return instance; } }

//    private void Awake()
//    {
//        instance = this;
//        m_pool = new Queue<GameObject>();
//        if (dataList == null)
//        {
//            Debug.LogError("dataList is null");
//        }
//    }
//    /// <summary>
//    /// 根据MapObjectType从对象池中获得物体，可能为空
//    /// </summary>
//    /// <param name="type"></param>
//    /// <returns></returns>
//    public GameObject GetByMapObjectType(MapObjectType type)
//    {
        
//        return null;
//    }
//    /// <summary>
//    /// 从对象池中获得物体，可能为空
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <returns></returns>
//    public GameObject Get<T>() where T : class
//    {
//        //Type t = typeof(T);
//        //string name = t.Name;
//        //if (m_pool.ContainsKey(name))
//        //{
//        //    if (m_pool[name].Count > 0)
//        //    {
//        //        GameObject obj = m_pool[name].Dequeue();
//        //        obj.SetActive(true);
//        //        return obj;
//        //    }
//        //    else
//        //    {
//        //        GameObject obj = dataList.GetData<T>();
//        //        obj = Instantiate(obj);
//        //        return obj;
//        //    }
//        //}
//        //else
//        //{
//        //    GameObject obj = dataList.GetData<T>();

//        //    if (obj != null)
//        //    {
//        //        Debug.Log($"create {name} poll");
//        //        m_pool.Add(name, new Queue<GameObject>());
//        //        obj = Instantiate(obj);
//        //        return obj;
//        //    }
//        //    else { return null; }
//        //}
//        return null;
//    }
//    /// <summary>
//    /// 归还物体
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <param name="obj"></param>
//    public void Return<T>(GameObject obj) where T : class
//    {
//        Type t = typeof(T);
//        string name = t.Name;
//        if (m_pool.ContainsKey(name))
//        {
//            obj.SetActive(false);
//            m_pool[name].Enqueue(obj);
//        }
//    }

//}
