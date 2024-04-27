using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class UIMapObjectData
{
    public string Name; 
    public List<MyData> datas;
    public UIMapObjectData(string name,List<MyData> datas)
    {
        Name = name;
        this.datas = datas;
    }
}

public class UIData
{
    public Dictionary<string, List<string>> UIObjectDatasInJson;
    [JsonIgnore]
    public List<UIMapObjectData> UIObjectDatas;

    public void Init(DataList dataList)
    {
        UIObjectDatas = new List<UIMapObjectData>();
        foreach (var kv in UIObjectDatasInJson) 
        { 
            List<MyData> myDatas = new List<MyData>();
            foreach (var name in kv.Value)
            {
                myDatas.Add(dataList.GetDataByName(name));
            }
            UIObjectDatas.Add(new UIMapObjectData(kv.Key, myDatas));
        }
    }

}

public class CreateUI : MonoBehaviour
{
    public TextAsset UIJson;
    private UIData uiData;
    public DataList dataList;
    public GameObject UIMapObjectPrefab;
    void Start()
    {
        uiData = new UIData();
        JsonConvert.PopulateObject(UIJson.text, uiData);
        uiData.Init(dataList);

        DrawUI();
        //foreach (var obj in uiData.UIObjectDatasInJson)
        //{
        //    Debug.Log(obj.Key);
        //    foreach (var item in obj.Value)
        //    {
        //        Debug.Log(" " + item);
        //    }
        //}
    }

    private void DrawUI()
    {
        int i = 0, j = 0;
        Debug.Log(uiData.UIObjectDatas.Count);
        foreach(UIMapObjectData data in uiData.UIObjectDatas)
        {
            GameObject obj = Instantiate(UIMapObjectPrefab, this.transform);
            obj.GetComponent<UIMapObject>().SetData(data);
            //Debug.Log("data is null?" + (data == null));
            obj.transform.localPosition = new Vector2(i, j);
            i++;
            j += i / 2;
            i %= 2;
        }
    }
}
