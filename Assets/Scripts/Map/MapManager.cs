using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
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

    public void CreateMap(int l, int w)
    {
        mapState = new MapState(l, w, defaultData, defaultName);
        Map.Instance.MapState = mapState;
    }
    public void ReChangeMap(ChangeMapType type)
    {
        if (mapState == null)
        {
            Debug.Log("mapstate is null");
            return;
        }
        int l = mapState.length;
        int w = mapState.width;
        switch (type)
        {
            case ChangeMapType.AddLeft:
                ReChangeMap(l + 1, w, 1, 0);
                break;
            case ChangeMapType.RemoveLeft:
                ReChangeMap(l - 1, w, -1, 0);
                break;
            case ChangeMapType.AddRight:
                ReChangeMap(l + 1, w, 0, 0);
                break;
            case ChangeMapType.RemoveRight:
                ReChangeMap(l - 1, w, 0, 0);
                break;
            case ChangeMapType.AddUp:
                ReChangeMap(l, w + 1, 0, 0);
                break;
            case ChangeMapType.RemoveUp:
                ReChangeMap(l, w - 1, 0, 0);
                break;
            case ChangeMapType.AddDown:
                ReChangeMap(l, w + 1, 0, 1);
                break;
            case ChangeMapType.RemoveDown:
                ReChangeMap(l, w - 1, 0, -1);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 改变地图 (x,y)代表原本地图（0，0）位置放在新地图的（x，y)位置
    /// </summary>
    /// <param name="l"></param>
    /// <param name="w"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void ReChangeMap(int l, int w, int x, int y)
    {
        var newMap = new MapState(l, w, defaultData, defaultName);
        for (int i = x >= 0 ? x : 0; i < newMap.length && i < x + mapState.length; i++)
        {
            for (int j = y >= 0 ? y : 0; j < newMap.width && j < y + mapState.width; j++)
            {
                //Debug.Log(i + " " + j + " " + x + " " + y + mapState.MapName[i - x, j - y]);
                newMap.Set(i, j, mapState.MapName[i - x, j - y], mapState.Map[i - x, j - y]);
            }
        }
        //Debug.Log(newMap.MapName[0, 0]);
        //Debug.Log(l + " " + w + " " + x + " " + y);
        mapState = newMap;
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
        //for (int i = 0; i < mapState.length; i++)
        //{
        //    for (int j = 0; j < mapState.width; j++)
        //    {
        //        Debug.Log("mapcount:" + mapState.Map[i, j].Count);
        //    }
        //}
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

    public void SetMapStateData(int x, int y, string name, List<MyData> myData)
    {
        mapState.Set(x, y, name, myData);
    }


}
