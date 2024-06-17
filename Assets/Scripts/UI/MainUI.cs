using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class MainUI : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;
    public Button createButton;
    public Button changeButton;

    public GameObject inputpanel;

    public InputField inputLength;
    public InputField inputWidth;
    public Button OkButton;
    public Button cancelButton;

    public GameObject changepanel;

    private void Start()
    {
        saveButton.onClick.AddListener(SaveFile);
        loadButton.onClick.AddListener(LoadFile);
        createButton.onClick.AddListener(OpenInputPanel);
        changeButton.onClick.AddListener(OpenChangePanel);

        OkButton.onClick.AddListener(CloseAndApplyPanel);
        cancelButton.onClick.AddListener(CloseAndCancelPanel);
    }

    private void CloseAndApplyPanel()
    {
        inputpanel.SetActive(false);
        int l = int.Parse(inputLength.text);
        int w = int.Parse(inputWidth.text);
        MapManager.Instance.CreateMap(l, w);
        MyMouse.HasOpenPanel = false;
    }
    private void CloseAndCancelPanel()
    {
        inputpanel.SetActive(false);
        MyMouse.HasOpenPanel = false;
    }

    private void OpenInputPanel()
    {
        MyMouse.HasOpenPanel = true;
        inputpanel.SetActive(true);
    }

    public void OpenChangePanel()
    {
        MyMouse.HasOpenPanel = true;
        changepanel.SetActive(true);
    }
    private void LoadFile()
    {
        FileOpenDialog dialog = new FileOpenDialog();
        dialog.structSize = Marshal.SizeOf(dialog);
        dialog.filter = "json files\0*.json\0All Files\0*.*\0\0";
        dialog.file = new string(new char[256]);
        dialog.maxFile = dialog.file.Length;
        dialog.fileTitle = new string(new char[64]);
        dialog.maxFileTitle = dialog.fileTitle.Length;
        dialog.initialDir = UnityEngine.Application.dataPath;  //默认路径
        dialog.title = "Open File Dialog";
        dialog.defExt = "json";//显示文件的类型
        //注意一下项目不一定要全选 但是0x00000008项不要缺少
        dialog.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;  //OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR

        if (DialogShow.GetOpenFileName(dialog))
        {
            Debug.Log(dialog.file);
            MapManager.Instance.LoadMapFromFile(dialog.file);
        }
    }
    private void SaveFile()
    {
        FileOpenDialog dialog = new FileOpenDialog();
        dialog.structSize = Marshal.SizeOf(dialog);

        dialog.filter = "json files\0*.json\0All Files\0*.*\0\0";
        dialog.file = new string(new char[256]);
        dialog.maxFile = dialog.file.Length;
        dialog.fileTitle = new string(new char[64]);
        dialog.maxFileTitle = dialog.fileTitle.Length;
        dialog.initialDir = UnityEngine.Application.dataPath;//默认路径ofn.title = "保存文件";
        dialog.defExt = ".json";//显示文件的类型
        dialog.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;

        if (DialogShow.GetSaveFileName(dialog))
        {
            Debug.Log(dialog.file);
            MapManager.Instance.SaveMapToFile(dialog.file);
        }
    }
}

