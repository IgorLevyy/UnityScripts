using EProjectNS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    public bool panelshow = true;
    public GUISkin skin;
    EProject eProject;
    private bool isShowDialogResult = false;
    string reportResult;


    // Use this for initialization
    void Start ()
    {
        InitSceneScript scriptSetActive = gameObject.GetComponent<InitSceneScript>();
        eProject = scriptSetActive.eProject;

    }

    // Update is called once per frame
    void Update ()
    {
        ManageTaskDialogInitProject();
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, Screen.height-50, 70, 40), "Звонок"))
        {
            eProject.GetLogActions();
        }

        if (panelshow && eProject != null)
        {
            int width = 350;
            int heightP1 = 200;
            int widthButton = 330;
            int border = 10;
            int borderText = 10;

        }
        else
        {
            InitSceneScript scriptSetActive = gameObject.GetComponent<InitSceneScript>();
            eProject = scriptSetActive.eProject;
        }

        if(isShowDialogResult)
        {
            GUI.color = Color.black;
            GUI.backgroundColor = Color.white;
            GUI.contentColor = Color.black;
           

            int xc = Screen.width / 2+100;
            int yc = Screen.height / 2;
            int dx = Screen.width - 210;
            int dy = Screen.height - 10;
            GUI.Window(1, new Rect(xc - dx / 2, yc - dy / 2, dx, dy), CreateResultDialog, "Результат выполнения задания");
        }
    }

    public void ManageTaskDialogInitProject()
    {
        if (eProject != null)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!eProject.IsStart)
                {
                    eProject.Start();
                }
                else
                {
                    FinishResult();
                }
            }
        }
        else
        {
            InitSceneScript scriptSetActive = gameObject.GetComponent<InitSceneScript>();
            eProject = scriptSetActive.eProject;
        }
    }

    public void FinishResult()
    {
        eProject.Stop();
        reportResult = eProject.GetReport();
        isShowDialogResult = true;

        MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
        scriptMouseLook.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void CreateResultDialog(int id)
    {
        int x0 = 10;
        int y0 = 10;
        int dx = Screen.width-200;
        int dy = Screen.height;
        int margin = 20;
        GUIStyle style = GUI.skin.GetStyle("label");
        //gUIStyle.normal.
        // GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), reportResult, style);

        GUIStyle style2 = new GUIStyle()
        {
            richText = true,
        };


        GUIStyle style3 = new GUIStyle()
        {
            
        };
        
        //   GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), "<size=30>Some <color=yellow>RICH</color> text</size>", style2);

        GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), reportResult, style2);
        if (GUI.Button(new Rect(Screen.width-400, Screen.height-100, 100, 40f), "Выход"))
        {
            DestroyResultDialog();
        }
    }


    void DestroyResultDialog()
    {
        isShowDialogResult = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
        scriptMouseLook.enabled = true;
        Help scriptHelp = gameObject.GetComponent<Help>();
        scriptHelp.enabled = true;
    }


}
