using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMouse : MonoBehaviour
{
    private UIMapObjectData nowData;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            HitLeft(hit);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            HitRight(hit);
        }
    }

    public void HitLeft(RaycastHit2D hit)
    {
        if (hit.collider == null) { return; }
        //Debug.Log(hit.collider.tag);
        switch (hit.collider.tag)
        {
            case "UIMapObject":
                nowData = hit.collider.GetComponent<UIMapObject>().GetData();
                EventManager.InvokeChooseUIObjectEvent(hit.collider.GetComponent<UIMapObject>().GetInstanceID());
                break;
            case "MapObject":
                if (nowData == null)
                {
                    Debug.Log("nowData is null");
                    return;
                }
                hit.collider.GetComponent<MapObject>().SetData(nowData.Name, nowData.datas);
                break;
        }
    }
    public void HitRight(RaycastHit2D hit)
    {
        if (hit.collider == null) { return; }
        Debug.Log("HitRight:"+hit.collider.tag);
        switch (hit.collider.tag)
        {
            //case "UIMapObject":
            //    nowData = hit.collider.GetComponent<UIMapObject>().GetData();
            //    EventManager.InvokeChooseUIObjectEvent(hit.collider.GetComponent<UIMapObject>().GetInstanceID());
            //    break;
            case "MapObject":
                var datas = hit.collider.GetComponent<MapObject>().data;
                ChangeObjValueUI.Instance.OnRightClick(datas);
                break;
        }
    }
}
