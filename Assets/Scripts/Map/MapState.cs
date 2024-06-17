using System.Collections.Generic;
using UnityEngine;

public class MapState
{
    public int length, width;

    public List<MyData>[,] Map;
    public string[,] MapName;
    public MapState(int l, int w,MyData defaultData,string defaultName)
    {
        length = l;
        width = w;
        Map = new List<MyData>[length, width];
        MapName = new string[length, width];
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Map[i, j] = new List<MyData>
                {
                    defaultData
                };
                MapName[i, j] = defaultName;
            }
        }
    }

    public void Set(int x, int y, string name, List<MyData> value)
    {
        MapName[x, y] = name;
        Map[x, y] = value;
        Debug.Log(x + " " + y + name + "set:" + (value == null ? 0 : value.Count));
    }
}