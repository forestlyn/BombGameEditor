using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyData", menuName = "MyAsset/MyData")]
public class MyData : ScriptableObject
{
    public string Name;
    public MapObjectType type;
    public int height;
    public int id;
    public bool open;

    //box
    public BoxMaterialType boxMaterialType;
    public KEDeliverType boxKEType;
    public Dir boxDir;
    public int boxRotateAngle;
    public int boxAdd;
    public int boxMulti;

    public MyData Copy()
    {
        string s = JsonConvert.SerializeObject(this);
        MyData newData = JsonConvert.DeserializeObject<MyData>(s);
        return newData;
    }
}