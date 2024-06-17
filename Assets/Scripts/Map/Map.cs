using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public MapObject prefab;

    MapState mapState;
    public MapState MapState
    {
        get { return mapState; }
        set
        {
            if (value == null)
            {
                DeleteMap();
            }
            else
            {
                DeleteMap();
                mapState = value;
                CreateMap();
            }
        }
    }

    public static Map Instance
    {
        get; private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void CreateMap()
    {
        float l, w;
        l = mapState.length;
        w = mapState.width;
        Debug.Log("l:" + l + "w:" + w);

        float offset_x, offset_y;
        offset_x = -l / 2 + 0.5f;
        offset_y = -w / 2 + 0.5f;
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < w; j++)
            {
                GameObject obj = Instantiate(prefab.gameObject, this.transform);
                if (obj != null)
                {
                    obj.transform.position = new Vector2(i + offset_x, j + offset_y);
                    var map = obj.GetComponent<MapObject>();
                    map.SetPos(i, j);
                    map.SetData(mapState.MapName[i, j], mapState.Map[i, j]);
                }
                else
                {
                    Debug.LogError("no GameObject");
                }
            }
        }
    }
    private void DeleteMap()
    {
        foreach (var gb in GetComponentsInChildren<MapObject>())
        {
            Destroy(gb.gameObject);
        }
    }
}
