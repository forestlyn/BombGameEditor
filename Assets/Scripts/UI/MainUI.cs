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

    public GameObject panel;

    public InputField inputLength;
    public InputField inputWidth;
    public Button OkButton;
    private void Start()
    {
        saveButton.onClick.AddListener(SaveFile);
        loadButton.onClick.AddListener(LoadFile);
        createButton.onClick.AddListener(OpenPanel);

        OkButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        panel.SetActive(false);
        int l = int.Parse(inputLength.text);
        int w = int.Parse(inputWidth.text);
        MapManager.Instance.CreateMap(l, w);
    }

    private void OpenPanel()
    {
        panel.SetActive(true);
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
        dialog.initialDir = UnityEngine.Application.dataPath;  //Ĭ��·��
        dialog.title = "Open File Dialog";
        dialog.defExt = "json";//��ʾ�ļ�������
        //ע��һ����Ŀ��һ��Ҫȫѡ ����0x00000008�Ҫȱ��
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
        dialog.initialDir = UnityEngine.Application.dataPath;//Ĭ��·��ofn.title = "�����ļ�";
        dialog.defExt = ".json";//��ʾ�ļ�������
        dialog.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;

        if (DialogShow.GetSaveFileName(dialog))
        {
            Debug.Log(dialog.file);
            MapManager.Instance.SaveMapToFile(dialog.file);
        }
    }
}

