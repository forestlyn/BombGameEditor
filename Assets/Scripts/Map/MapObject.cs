using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapObject : MonoBehaviour
{
    //public TextMeshProUGUI text;
    public SpriteRenderer sr;
    private List<MyData> data;
    public string objname;
    public List<MyData> Data { get => data; }
    public int x, y;
    private void Awake()
    {
        if (sr == null)
        {
            Debug.LogError("err:sr == null");
        }

        //SetData("Ground", data);
        //Debug.Log(data.Count);
    }

    public void SetData(string name, List<MyData> data)
    {
        //Debug.Log(data.Count + "name:" + name);
        if (data == null || data.Count == 0)
            return;
        List<MyData> value = new List<MyData>();
        foreach (var item in data)
        {
            var newItem = item.Copy();
            value.Add(newItem);
        }
        this.data = value;
        //text.text = name;
        objname = name;
        RefreshSprite();
        MapManager.Instance.SetMapStateData(x, y, name, value);
    }
    public void RefreshSprite()
    {
        sr.sprite = GetSprites.Instance.GetSprite(data[^1]);
        var angle = 0;
        if (data[^1].type == MapObjectType.Box && data[^1].boxKEType == KEDeliverType.StaticDir)
        {
            switch (data[^1].boxDir)
            {
                case Dir.Left:
                    angle = 180;
                    break;
                case Dir.Up:
                    angle = 90;
                    break;
                case Dir.Right:
                    break;
                case Dir.Down:
                    angle = -90;
                    break;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void SetPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}
