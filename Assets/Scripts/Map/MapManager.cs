using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    public MyData defaultData;
    public string defaultName = "Ground";
    private MapState mapState;

    private static MapManager instance;
    public static MapManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        //CreateMap(9, 9);
    }

    public void CreateMap(int l,int w)
    {
        mapState = new MapState(l, w, defaultData, defaultName);
        Map.Instance.MapState = mapState;
    }

    public void LoadMapFromFile(string path)
    {
        Debug.Log(path);

        mapState = JsonConvert.DeserializeObject<MapState>(File.ReadAllText(path));

        //Debug.Log("l:" + mapState.length + "w:" + mapState.width);

        Map.Instance.MapState = mapState;
    }
    public void SaveMapToFile(string path)
    {
        Debug.Log(path);
        var text = JsonConvert.SerializeObject(mapState);
        Debug.Log(text);
        for (int i = 0; i < mapState.length; i++)
        {
            for (int j = 0; j < mapState.width; j++)
            {
                Debug.Log("mapcount:" + mapState.Map[i, j].Count);
            }
        }
        if (File.Exists(path))
        {
            File.WriteAllText(path, text);
        }
        else
        {
            var fs = File.Create(path);
            fs.Close();
            File.WriteAllText(path, text);
        }
    }
    private void DeleteMap()
    {
        Map.Instance.MapState = null;
    }

    public void SetMapStateData(int x,int y,string name, List<MyData> myData)
    {
        mapState.Set(x, y, name, myData);
    }
}
