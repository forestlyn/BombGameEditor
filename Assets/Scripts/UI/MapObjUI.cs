using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapObjUI : MonoBehaviour
{
    public Text objname;
    public InputField id;
    public Text type;
    public TMP_Dropdown open;
    public TMP_Dropdown boxMaterial;
    public TMP_Dropdown boxKEtype;
    public TMP_Dropdown boxDir;
    public TMP_Dropdown boxRotateAngle;
    public InputField boxAdd;
    public InputField boxMulti;

    MyData data;
    public void Clear()
    {
        data = null;
    }
    public void Open(MyData data)
    {
        if (data == null) 
        { 
            Debug.Log("open data is null"); 
            return; 
        }
        Debug.Log(JsonUtility.ToJson(data));
        this.data = data;
        objname.text = data.name;
        id.text = data.id.ToString();
        type.text = data.type.ToString();
        open.value = data.open == true ? 0 : 1;
        boxMaterial.value = (int)data.boxMaterialType;
        boxKEtype.value = (int)data.boxKEType;
        boxDir.value = (int)data.boxDir;
        boxRotateAngle.value = (int)data.boxRotateAngle;
        boxAdd.text = data.boxAdd.ToString();
        boxMulti.text = data.boxMulti.ToString();
    }

    public void Close()
    {
        try
        {
            if (data == null) return;
            data.id = int.Parse(id.text);
            data.open = open.value == 0 ? true : false;
            data.boxMaterialType = (BoxMaterialType)boxMaterial.value;
            data.boxKEType = (KEDeliverType)boxKEtype.value;
            data.boxDir = (Dir)boxDir.value;
            data.boxRotateAngle = (int)boxRotateAngle.value;
            data.boxAdd = 1;
            data.boxMulti = int.Parse(boxMulti.text);
        }
        catch
        {
            Debug.Log("MapObjUI Close err");
        }
    }
}
