using EProjectNS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class JsonButton
//{
//    public string Name;
//    public int Value;
//}
public class CodeValuePair
{
    public string Value;
    public int Code;
}

[Serializable]
public class DialogData
{
    public string DialogTitle;
    public int DialogCode;
    // public Dictionary<int, string> KeyValuePairs;
    [SerializeField]
    // public List<CodeValuePair> CodeValuePairs;
    public List<int> Codes;
    public List<string> Values;
}

public class DialogScript : MonoBehaviour
{
    private bool isShowPanel = false;
    //private List<JsonButton> buttons;
    private DialogData _dialogData;

    public delegate void SelectDialogItemEventHandler(int dialogCode, int keyItem);
    public static event SelectDialogItemEventHandler SelectDialogItemEvent;

    void OnGUI()
    {
        int xc = Screen.width / 2;
        int yc = Screen.height / 2;
        int dx = 800;
        int dy = 500;

        if (isShowPanel == true)
        {
            GUI.Window(1, new Rect(xc - dx / 2, yc - dy / 2, dx, dy), DrawDialogActiveObject, _dialogData.DialogTitle);
        }
    }

    public void CreateDialog(DialogData dialogData)
    {
        _dialogData = dialogData;
        isShowPanel = true;
    }

    void DrawDialogActiveObject(int id)
    {
        int dx = 800;
        //int dy = 500;
        int xa = 15;
        int ya = 40;
        int yBetweenButton = 10;
        int yButton = 60;
        //int countAction = 0;
        for (int i = 0; i < _dialogData.Codes.Count; i++)
        {
            if (GUI.Button(new Rect(10, ya + (yButton + yBetweenButton) * i, dx - xa * 2, yButton), _dialogData.Values[i]))
            {
                SelectDialogItemEvent?.Invoke(_dialogData.DialogCode, _dialogData.Codes[i]);
            }
        }
    }

}
