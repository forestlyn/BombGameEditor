using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMouse : MonoBehaviour
{
    private UIMapObjectData nowData;

    public static bool HasOpenPanel { get; set; }

    public UIMapObjectData defaultData;
    private void Start()
    {
    }
    private void Update()
    {
        if (HasOpenPanel) { return; }
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            HitLeft(hit);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            HitRight(hit);
        }
        else if (Input.GetMouseButtonDown(2))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            HitMid(hit);
        }
    }

    public void HitLeft(RaycastHit2D hit)
    {
        if (hit.collider == null) { return; }
        Debug.Log(hit.collider.tag);
        switch (hit.collider.tag)
        {
            case "UIMapObject":
                nowData = hit.collider.GetComponent<UIMapObject>().GetData();
                EventManager.InvokeChooseUIObjectEvent(hit.collider.GetComponent<UIMapObject>().GetInstanceID());
                break;
            case "MapObject":
                if (nowData == null)
                {
                    //Debug.Log("nowData is null");
                    return;
                }
                hit.collider.GetComponent<MapObject>().SetData(nowData.Name, nowData.datas);
                break;
        }
    }
    public void HitMid(RaycastHit2D hit)
    {
        if (hit.collider == null) { return; }
        //Debug.Log("HitRight:"+hit.collider.tag);
        switch (hit.collider.tag)
        {
            //case "UIMapObject":
            //    nowData = hit.collider.GetComponent<UIMapObject>().GetData();
            //    EventManager.InvokeChooseUIObjectEvent(hit.collider.GetComponent<UIMapObject>().GetInstanceID());
            //    break;
            case "MapObject":
                var mapobj = hit.collider.GetComponent<MapObject>();
                ChangeObjValueUI.Instance.OnRightClick(mapobj);
                break;
        }
    }
    public void HitRight(RaycastHit2D hit)
    {
        if (hit.collider == null) { return; }
        //Debug.Log("HitRight:"+hit.collider.tag);
        switch (hit.collider.tag)
        {
            //case "UIMapObject":
            //    nowData = hit.collider.GetComponent<UIMapObject>().GetData();
            //    EventManager.InvokeChooseUIObjectEvent(hit.collider.GetComponent<UIMapObject>().GetInstanceID());
            //    break;
            case "MapObject":
                hit.collider.GetComponent<MapObject>().SetData(MapManager.Instance.defaultName, 
                    new List<MyData> { MapManager.Instance.defaultData });
                break;
        }
    }
}
