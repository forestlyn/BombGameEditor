using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChangeMapType
{
    AddLeft, RemoveLeft,
    AddRight, RemoveRight,
    AddUp, RemoveUp,
    AddDown, RemoveDown,
    Cancel
}

public class ChangeMapUI : MonoBehaviour
{
    public Button[] changeButtons;
    void Start()
    {
        if(changeButtons == null || changeButtons.Length != 9)
        {
            Debug.Log("changeButtons err");
        }
        for(int i = 0; i < changeButtons.Length; i++)
        {
            var button = changeButtons[i];
            int idx = i;
            button.onClick.AddListener(delegate { ChangeMap((ChangeMapType)idx); });
        }
        gameObject.SetActive(false);
    }

    private void ChangeMap(ChangeMapType type)
    {
        Debug.Log(type);
        MapManager.Instance.ReChangeMap(type);
        gameObject.SetActive(false);
        MyMouse.HasOpenPanel = false;
    }
}
