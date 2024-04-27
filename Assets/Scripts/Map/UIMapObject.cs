using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIMapObject : MonoBehaviour
{
    private UIMapObjectData m_MapObjectData;
    public TextMeshProUGUI text;

    private void OnEnable()
    {
        EventManager.ChooseUIObjectEvent += OnChooseUIObjectEvent;
    }



    private void OnDisable()
    {
        EventManager.ChooseUIObjectEvent -= OnChooseUIObjectEvent;
    }

    public void SetData(UIMapObjectData mapObjectData)
    {
        //Debug.Log("setdata null?"+(mapObjectData==null));
        m_MapObjectData = mapObjectData;
        text.text = mapObjectData.Name;
    }
    public UIMapObjectData GetData()
    {
        //Debug.Log("getdata null?" + (m_MapObjectData == null));

        return m_MapObjectData;
    }

    private void OnChooseUIObjectEvent(int instanceId)
    {
        if (this.GetInstanceID() == instanceId)
        {
            SetTextColor(Color.red);
        }
        else
            SetTextColor(Color.black);
    }

    public void SetTextColor(Color color)
    {
        text.color = color;
    }
}
