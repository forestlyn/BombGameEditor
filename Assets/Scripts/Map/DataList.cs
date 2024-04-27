using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "MyAsset/DataList")]
public class DataList : ScriptableObject
{
    public MyData[] datas;

    public MyData GetDataByName(string name)
    {
        foreach (var data in datas)
        {
            if (data.name == name)
            {
                return data;
            }
        }
        Debug.LogWarning($"no type named {name}");
        return null;
    }
}
