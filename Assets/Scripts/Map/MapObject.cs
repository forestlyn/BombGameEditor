using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    public TextMeshProUGUI text;
    public List<MyData> data;
    public int x, y;
    private void Awake()
    {
        if (text == null)
        {
            Debug.LogError("err:text == null");
        }

        //SetData("Ground", data);
        //Debug.Log(data.Count);
    }

    public void SetData(string name,List<MyData> data)
    {
        Debug.Log(data.Count + "name:" + name);
        if (data == null || data.Count == 0)
            return;
        this.data = data;
        text.text = name;
        MapManager.Instance.SetMapStateData(x, y, name, data);
    }
    public void SetPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

}