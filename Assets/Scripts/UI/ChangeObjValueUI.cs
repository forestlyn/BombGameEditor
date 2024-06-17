using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeObjValueUI : MonoBehaviour
{
    private static ChangeObjValueUI instance;
    public static ChangeObjValueUI Instance { get=>instance; }

    public MapObjUI mapObjUI;
    public Button Apply;
    public Button Cancel;
    public GameObject ChangeObjValueUIPanel;

    private MapObject mapObject;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log("too much ChangeObjValueUI");
        }
    }

    private void Start()
    {
        Apply.onClick.AddListener(OnClickApply);
        Cancel.onClick.AddListener(OnClickCancel);
        ChangeObjValueUIPanel.SetActive(false);
    }
    public void OnRightClick(MapObject mapObj)
    {
        mapObject = mapObj;
        MyData data = mapObj.Data.Find(x => x.type == MapObjectType.Box);
        if (data != null)
        {
            MyMouse.HasOpenPanel = true;
            ChangeObjValueUIPanel.SetActive(true);
            mapObjUI.Open(data);
        }
    }

    public void OnClickApply()
    {
        ChangeObjValueUIPanel.SetActive(false);
        mapObjUI.Close();
        mapObject?.RefreshSprite();
        mapObject = null;
        MyMouse.HasOpenPanel = false;
    }
    public void OnClickCancel()
    {
        ChangeObjValueUIPanel.SetActive(false);
        mapObjUI.Clear();
        MyMouse.HasOpenPanel = false;
    }
}
