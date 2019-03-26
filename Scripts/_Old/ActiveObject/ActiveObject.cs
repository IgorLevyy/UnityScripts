using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EProjectNS;
using System.Linq;

public class ActiveObject : MonoBehaviour {


    public float smooth = 2.0f;
    public float angleOpened = 90.0f;
    public bool open = false;

    public static GameObject chosenGameObject;
    private bool isShowDialogActiveObject = false;
    public static MouseLook scriptMouseLook;
    public static Help scriptHelp;
    public static InitSceneScript scriptSetActive;
    EProject eProject;
    ModelTreeNode modelTreeNode;



    void Start ()
    {
        //chosenGameObject = gameObject;
    }
	

	void Update ()
    {

        //if (Input.GetKeyDown(KeyCode.F) && chosenGameObject == gameObject)//&& isActive
        //{
        //    print(string.Format("Rotate:"));
        //    GameObject gameObjectForRotate = GetRootRotateObject(gameObject, 10, "Switch");
        //    float angle;
        //    if (!open)
        //    {
        //        angle = angleOpened;
        //    }
        //    else
        //    {
        //        angle = -angleOpened;
        //    }

        //    gameObjectForRotate.transform.rotation *= Quaternion.Euler(0f, angle, 0f);
        //    print(string.Format("Rotate: open={0}, nameObject={1}, nameParent={2}", open, gameObject.name, gameObjectForRotate.name));
        //    open = !open;

        //    SetActive scriptSetActive = GameObject.Find("Player").GetComponent<SetActive>();
        //    eProject = scriptSetActive.eProject;
        //    ScenarioAction scenarioAction = eProject.GetScenarioActionByGameObjectTitle(gameObject.name);
        //    scenarioAction.DoIt();
        //}

        if (Input.GetMouseButtonDown(0) && chosenGameObject == gameObject)//&& isActive
        {
            isShowDialogActiveObject = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            scriptMouseLook.enabled = false;
            scriptHelp.enabled = false;
            eProject = scriptSetActive.eProject;
           
        }
    }


    void OnGUI()
    {
        OperationsWithGameObject.LightObject(gameObject, chosenGameObject);

        if (isShowDialogActiveObject)
        {
            int xc = Screen.width / 2;
            int yc = Screen.height / 2;
            int dx = 800;
            int dy = 500;
            GUI.Window(1, new Rect(xc-dx/2, yc-dy/2, dx, dy), CreateDialogActiveObject, "Варианты действия с выбранным объектом");
        }

     
        //if (chosenGameObject == gameObject)
        //{
        //    if (open)
        //    {
        //        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 300, 30), "Нажмите 'F', чтобы выключить" + gameObject.name);             
        //    }
        //    else
        //    {
        //        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 70, 300, 30), "Нажмите 'F', чтобы включить" + gameObject.name);
        //    }          
        //}
    }

    void CreateDialogActiveObject(int id)
    {
        
        int dx = 800;
        //int dy = 500;
        int xa = 15;
        int ya = 40;
        int yBetweenButton = 10;
        int yButton = 60;
        int countAction = 0;

        
    
        ya += (yBetweenButton + yButton);
        if (GUI.Button(new Rect(10, ya, dx - xa * 2, yButton), "Отмена"))
        {
            DestroyDialog();
        }

        //if (!eProject.IsStart)
        //{
        //    if (GUI.Button(new Rect(xC - dX / 2, 180f, dX, 50f), "Начать выполнение"))
        //    {

        //        eProject.Start();
        //        showTaskDialog = false;
        //        DestroyTaskDialog();
        //    }
        //}
        //else
        //{
        //    if (GUI.Button(new Rect(xC - dX / 2, 180f, dX, 50f), "Завершить выполнение"))
        //    {
        //        eProject.DateTimeStart = DateTime.UtcNow;
        //        eProject.IsStart = false;
        //        showTaskDialog = false;

        //        reportResult = eProject.GetReport();
        //        showResultDialog = true;
        //    }
        //}

    }
    void DestroyDialog()
    {
        isShowDialogActiveObject = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        scriptMouseLook.enabled = true;
        scriptHelp.enabled = true;
    }



}
