using EProjectNS;
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.IMGUI.Controls;
using UnityEngine;


public class TaskDialog : MonoBehaviour {

    public bool showTaskDialog = false;
    public bool showResultDialog = false;
    private string reportResult;

    public GUISkin skin;
    public MouseLook scriptMouseLook;
    // Use this for initialization
    public List<Item> items = new List<Item>();
    [HideInInspector] public Item currItem;
    //EProject eProject = new EProject();
    EProject eProject;
    void Start()
    {
        InitSceneScript scriptSetActive = gameObject.GetComponent<InitSceneScript>();
        eProject = scriptSetActive.eProject;
    }

	
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnGUI()
    {
        if (eProject != null && eProject.IsStart)
        {
            //int msc = DateTime.UtcNow.Second - eProject.DateTimeStart.Second;
           // GUI.Label(new Rect(Screen.width - 200, 10, 100, 450), "Время выполнения: " + msc.ToString() + "c");
        }

        if (showTaskDialog)
        {
            int dx = 800;
            GUI.skin = skin;
            GUI.Window(0, new Rect(Screen.width/2-dx/2, Screen.height/4, 800, Screen.height/2), CreateTaskDialog, "Панель управления заданием");
        }

        if (showResultDialog)
        {
            int x0 = 0;
            int y0 = 0;
            int dx = 1000;
            int dy = 800;
            GUI.skin = skin;
            GUI.Window(1, new Rect(x0, y0, dx, dy), CreateResultDialog, "Результат выполнения задания");
            //GUI.Box(new Rect(x0+margin, y0+margin, dx - 2*margin, dy - 300), reportResult);
            //GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), reportResult);



            //Tree tree = new Tree();
            //TreeViewItem  treeViewItem =
            //    TreeView

            //GUIStyle gUIStyle = new GUIStyle()
            //{
            //    fontSize = 16,
            //};
            //gUIStyle.normal.textColor = Color.white;
            //GUIStyle style = GUI.skin.GetStyle("label");
            ////gUIStyle.normal.
            //GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), reportResult, style);// "toggle");// gUIStyle);


            //GUIStyle style2 = new GUIStyle();
            //style2.richText = true;
            //GUILayout.Label("<size=30>Some <color=yellow>RICH</color> text</size>", style2);
        }
    }

   

    void CreateTaskDialog(int id)
    {
        int xC = 800/2;
        int dX = 200;

        InitSceneScript scriptSetActive = gameObject.GetComponent<InitSceneScript>();
        eProject = scriptSetActive.eProject;

        Help scriptHelp = gameObject.GetComponent<Help>();
        scriptHelp.enabled = false;


        if (!eProject.IsStart)
        {
            if (GUI.Button(new Rect(xC - dX / 2, 180f, dX, 50f), "Начать выполнение"))
            {
                
                eProject.Start();
                showTaskDialog = false;
                DestroyTaskDialog();
            }
        }
        else
        {
            if (GUI.Button(new Rect(xC - dX/2, 180f, dX, 50f), "Завершить выполнение"))
            {
                scriptMouseLook.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;


              //  eProject.DateTimeStart = DateTime.UtcNow;
                eProject.IsStart = false;
                showTaskDialog = false;

                reportResult = eProject.GetReport();
                showResultDialog = true;
            }
        }
        if (GUI.Button(new Rect(xC - dX / 2, 260f, dX, 50f), "Отмена"))
        {         
            DestroyTaskDialog();
        }
    }
    void DestroyTaskDialog()
    {
        showTaskDialog = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        scriptMouseLook.enabled = true;
        Help scriptHelp = gameObject.GetComponent<Help>();
        scriptHelp.enabled = true;
    }

    public void CreateResultDialog(int id)
    {
        int x0 = 0;
        int y0 = 0;
        int dx = 1000;
        int dy = 800;
        int margin = 20;
        GUIStyle style = GUI.skin.GetStyle("label");
        //gUIStyle.normal.
        // GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), reportResult, style);

        GUIStyle style2 = new GUIStyle()
        {
            richText = true,
        };


     //   GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), "<size=30>Some <color=yellow>RICH</color> text</size>", style2);

        GUI.Label(new Rect(x0 + margin, y0 + margin, dx - 2 * margin, dy - 300), reportResult, style2);
        if (GUI.Button(new Rect(900, 750, 70, 40f), "Выход"))
        {
            DestroyResultDialog();
        }
    }

    void DestroyResultDialog()
    {
        showResultDialog = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        scriptMouseLook.enabled = true;
        Help scriptHelp = gameObject.GetComponent<Help>();
        scriptHelp.enabled = true;
    }


}
