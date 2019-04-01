using UnityEngine;
using EProjectNS;
using System;
using UnityEvent_Api;

using System.Reflection;
using System.Collections.Generic;
//using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity;
//using System.Collections;
//using UnityEditor;
//using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;
//using Newtonsoft.Json;
//using System.Runtime.Serialization;


public class InitSceneScript : MonoBehaviour {
	public Texture2D CursoreTexture;
	public Transform RaycastS;
	private RaycastHit Hit;
    public EProject eProject;

    public TaskDialog taskDialog;
    public GameObject gameObjectLight;
    public bool isEnableLight;
    public UnityApiScript unityApi;
    public IUnityEventListener _eventListener;

    public GUISkin skin;
    public Font font;

    //public List<InventoryItem> inventoryTable = new List<InventoryItem>();

    void Start ()
    {
		Cursor.visible = false;
        eProject = new EProject();
        eProject.Init();


        
        //var container = new Microsoft.Practices.Unity.UnityContainer();
        //container.RegisterType<IUnityEventListener, UnityEventListenerJs>(new ContainerControlledLifetimeManager());
        //_eventListener = container.Resolve<IUnityEventListener>();
        //_eventListener.OnEnable();

        //ContainerBuilder builder = new ContainerBuilder();
        //builder.RegisterType<UnityEventListenerJs>()
        //    .As<IUnityEventListener>();
        ////    .WithParameter("connectionString", Configuration.GetConnectionString("SomeConnectionString"));
        //builder.Build();

        // _eventListener = new UnityEventListenerJs();


        _eventListener = UnityEventServer.GetUnityEventListener();
        _eventListener.OnEnable();

        unityApi = new UnityApiScript();

        taskDialog = gameObject.GetComponent<TaskDialog>();
        MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
        Help scriptHelp = gameObject.GetComponent<Help>();
        //taskDialog.scriptMouseLook = scriptMouseLook;
        gameObjectLight.SetActive(false);

        //GameObject hazardObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //hazardObject.name = "hazard";
        //hazardObject.tag = "hazard";
        //hazardObject.transform.localPosition += new Vector3((float)0.1561335, 0, (float)3.699453);//((float)0.1561335, 0, (float)3.699453);

        ActiveObject.scriptMouseLook = scriptMouseLook;
        ActiveObject.scriptHelp = scriptHelp;
        ActiveObject.scriptSetActive = this;

        //Вот тут должно быть заполнение таблицы InventoryTable из xml, но пока забито вручную
        //var invItem1 = new InventoryItem
        //{
        //    inventoryName = "Табличка <Не включать, работают люди>",
        //    targetObjects = new List<string>()
        //};
        //invItem1.targetObjects.Add("SRF3 2");
        //inventoryTable.Add(invItem1);



        //Отображение предметов инвентаря на столе
        GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
        UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();


        //Список предметов, которых, необходимо отобразить на столе.
        string gOb = "Табличка <Не влезай, убьет>|Табличка <Заземлено>|УВНУ-10 ДК_2019_01_28|УНН-1ДС3|Патрон предохранителя_инвентарь|Табличка <Не включать, работают люди>";
        unityApiScript.GetInventory(gOb);
    }

    void Update()
    {
        opendoor.gameObjectForOpen = null;
        Using1.gameObjectForShader = null;
        Switch.chosenGameObject = null;
        ActiveObject.chosenGameObject = null;
        OnDoor.chosenGameObject = null;
        ActivateScript.chosenGameObject = null;
        OnChose.chosenGameObject = null;
        ObjectClicker.chosenGameObject = null;

        Vector3 Direction = RaycastS.TransformDirection(Vector3.forward);
        if (Physics.Raycast(RaycastS.position, Direction, out Hit, 1000f))
        {

            if (Hit.collider.material.staticFriction == 0.2f)
            {
                //Using1 usingScript = Hit.collider.gameObject.GetComponent<Using1>();
                //if (usingScript)
                //{
                //    Using1.gameObjectForShader = Hit.collider.gameObject;
                //}

                opendoor opendoorScript = Hit.collider.gameObject.GetComponent<opendoor>();
                if (opendoorScript)
                {
                    opendoor.gameObjectForOpen = Hit.collider.gameObject;
                    
                }

                Switch switchScript = Hit.collider.gameObject.GetComponent<Switch>();
                if (switchScript)
                {
                    Switch.chosenGameObject = Hit.collider.gameObject;
                }
            }

            ActiveObject activeObjectScript = Hit.collider.gameObject.GetComponent<ActiveObject>();
            if (activeObjectScript)
            {
                ActiveObject.chosenGameObject = Hit.collider.gameObject;
            }

            OnDoor onDoorScript = Hit.collider.gameObject.GetComponent<OnDoor>();
            if (onDoorScript)
            {
                OnDoor.chosenGameObject = Hit.collider.gameObject;
            }
            OnChose onChoseScript = Hit.collider.gameObject.GetComponent<OnChose>();
            if (onChoseScript)
            {
                OnChose.chosenGameObject = Hit.collider.gameObject;
            }
            ObjectClicker onClikerScript = Hit.collider.gameObject.GetComponent<ObjectClicker>();
            if (onClikerScript)
            {
                ObjectClicker.chosenGameObject = Hit.collider.gameObject;
            }

            ActivateScript activateScript = Hit.collider.gameObject.GetComponent<ActivateScript>();
            if (activateScript)
            {
                ActivateScript.chosenGameObject = Hit.collider.gameObject;
            }



        }
      //  ManageTaskDialog();

        //if (Input.GetMouseButtonDown(0)) //left
        //{
        //    eProject.CallServerMethod_DoAction("1e106acb-e6d3-41f5-865e-4eafb8b329d5", "c176dc43-0a07-4ae7-ba40-556735982901", 1);
        //}
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Cursor.visible = !Cursor.visible;

            //if(Cursor.lockState == CursorLockMode.None)
            //    Cursor.lockState = CursorLockMode.Locked;
            //else if (Cursor.lockState == CursorLockMode.Locked)
            //    Cursor.lockState = CursorLockMode.None;

            //MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
            //scriptMouseLook.enabled = !(scriptMouseLook.enabled);

            MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
            if (Cursor.visible == true)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                scriptMouseLook.enabled = true;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                scriptMouseLook.enabled = false;
            }
           

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameObjectLight.SetActive(!gameObjectLight.activeSelf);

            //var listener = new UnityEventListener
            //{
            //    EventType = "keyDown",
            //    IdObject = Guid.Empty,
            //    KeyCode = "L"
            //};
            //listener.SendEvent();

            GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            JsonParametersRotateGameObject jsonParametersRotateGameObject = new JsonParametersRotateGameObject
            {
                ObjectName = "Door_Дверь РУВН",
                Angle = new Vector3(0, 20, 0),
                IsSpecific = true
            };
            string json = JsonUtility.ToJson(jsonParametersRotateGameObject);

            unityApiScript.RotateGameObject(json);


            //List<JsonButton> btns = new List<JsonButton>();
            //for (int i=0; i<5; i++)
            //{
            //    JsonButton jsonButton = new JsonButton
            //    {
            //        Name = "Команда № " + i.ToString(),
            //        Value = i
            //    };
            //    btns.Add(jsonButton);
            //}

            //unityApiScript.CreateDialog(btns);


            List<CodeValuePair> codeValuePairs = new List<CodeValuePair>();
            List<int> codes = new List<int>();
            List<string> values = new List<string>();
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            for (int i = 0; i < 5; i++)
            {
                int key = i;
                string value = "Команда № " + i.ToString();
                keyValuePairs.Add(key, value);
                codeValuePairs.Add(new CodeValuePair { Code = key, Value = value });
                codes.Add(key);
                values.Add(value);
            }


            DialogData jsonDialog = new DialogData
            {
                DialogCode = 1,
                DialogTitle = "Сумка с причиндалами",
                //    KeyValuePairs = keyValuePairs,
                //   CodeValuePairs = codeValuePairs
                Codes = codes,
                Values = values
            };
            string strJsonDialog = JsonUtility.ToJson(jsonDialog);
            

            unityApiScript.CreateDialog(strJsonDialog);

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            //GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            //UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            //JsonParametersRotateGameObject jsonParametersRotateGameObject = new JsonParametersRotateGameObject
            //{
            //    ObjectName = "Door_Дверь РУВН",
            //    Angle = 135f,
            //    IsSpecific = true
            //};
            //string json = JsonUtility.ToJson(jsonParametersRotateGameObject);

            //unityApiScript.RotateGameObject(json);

            GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            JsonParametersLightGameObject jsonParametersLightGameObject = new JsonParametersLightGameObject
            {
                ObjectName = "Твердое тело1 818",
                IsLight = true
            };
            string json1 = JsonUtility.ToJson(jsonParametersLightGameObject);

            unityApiScript.LightGameObject(json1);


        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            //UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            //JsonParametersRotateGameObject jsonParametersRotateGameObject = new JsonParametersRotateGameObject
            //{
            //    ObjectName = "Door_Дверь РУВН",
            //    Angle = 135f,
            //    IsSpecific = true
            //};
            //string json = JsonUtility.ToJson(jsonParametersRotateGameObject);

            //unityApiScript.RotateGameObject(json);

            //GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            //UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            //JsonParametersLightGameObject jsonParametersLightGameObject = new JsonParametersLightGameObject
            //{
            //    ObjectName = "Твердое тело1 818",
            //    IsLight = false
            //};
            //string json1 = JsonUtility.ToJson(jsonParametersLightGameObject);

            //unityApiScript.LightGameObject(json1);

            GameObject AssetManager = GameObject.Find("AssetManager");
            NonCachingLoadExample NonCachingLoadExample = AssetManager.GetComponent<NonCachingLoadExample>();
            AddAssetParameter addAssetParameter = new AddAssetParameter
            {
                bundleURL = "D:/Training3dProjects/Training_v7/Assets/AssetBundles/cubeasset",
                assetName = "D:/Training3dProjects/Training_v7/Assets/Scenes/Resources_2018.12.26/Cube.prefab"//"A20", };
            };

            string json1 = JsonUtility.ToJson(addAssetParameter);
            NonCachingLoadExample.LoadAsset(json1);

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            //GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            //UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            //JsonParametersRotateGameObject jsonParametersRotateGameObject = new JsonParametersRotateGameObject
            //{
            //    ObjectName = "Door_Дверь РУВН",
            //    Angle = 135f,
            //    IsSpecific = true
            //};
            //string json = JsonUtility.ToJson(jsonParametersRotateGameObject);

            //unityApiScript.RotateGameObject(json);

            GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            JsonParametersPositionGameObject jsonParametersPositionGameObject = new JsonParametersPositionGameObject
            {
                ObjectName = "Твердое тело1 88",
                Position = new Vector3(0.5f, 0f, 0f),
                SetNew = false
            };
            string json = JsonUtility.ToJson(jsonParametersPositionGameObject);

            unityApiScript.ChangePositionObject(json);


        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
            Zoom scriptZoom = GameObject.Find("Player").GetComponent<Zoom>();


            GameObject mainCamera = GameObject.Find("Main Camera");
            Dialogue dialogueScript = mainCamera.GetComponent<Dialogue>();

            if (dialogueScript.ShowDialogue == true)
            {
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
                scriptMouseLook.enabled = true;
                scriptZoom.enabled = true;
            }
            else
            {
               // Cursor.visible = true;
               // Cursor.lockState = CursorLockMode.None;
                scriptMouseLook.enabled = false;
                scriptZoom.enabled = false;
            }

          

            if (dialogueScript.ShowDialogue == true)
            {
                dialogueScript.ShowDialogue = false;
            }
            else
            {
                DialogueNode node0 = new DialogueNode();
                node0.NpcText = "Я: -Здравствуйте, диспетчерская?\n";
                node0.NpcText += "Диспетчер: -Здравствуйте, диспетчер Иванов, слушаю.";
                Answer ans0_1 = new Answer
                {
                    Text = "Я: - Прошу снять напряжение с КТП-10/0,4 с номером 86732. Потребители уведомлены о снятии напряжения.\nДиспетчер: - Снимаю напряжение с КТП-10/0,4 с номером 86732.",
                    ToNode = 0,
                    SpeakEnd = true,

                    ActionRef = "e9477766-93dc-497d-a7e0-91ab73dcaab5",
                    ElementRef = Guid.Empty.ToString(),
                    InventoryItemRef = "41a454ad-e7cb-4785-a4d5-d969f42abb81"
                };
                Answer ans0_2 = new Answer
                {
                    Text = "Я: - Вы сняли напряжение?\nДиспетчер: - Да, напряжение с КТП-10/0,4 снято.",
                    ToNode = 0,
                    SpeakEnd = true,

                    ActionRef = "e474abb8-b273-48ec-b138-131c28ca0826",
                    ElementRef = Guid.Empty.ToString(),
                    InventoryItemRef = "41a454ad-e7cb-4785-a4d5-d969f42abb81"
                };
                Answer ans0_3 = new Answer
                {
                    Text = "Я: - Прошу подать напряжение на КТП 10/0,4. с номером 86732 \"Считаю, КТП 10/0.4 под напряжением\"\nДиспетчер: - Напряжение подано",
                    ToNode = 0,
                    SpeakEnd = true,

                    ActionRef = "e20b60e8-b7a1-4ed0-ba4b-c315c0d20149",
                    ElementRef = Guid.Empty.ToString(),
                    InventoryItemRef = "41a454ad-e7cb-4785-a4d5-d969f42abb81"
                };
                Answer ans0_4 = new Answer
                {
                    Text = "Я: - Прошу снять напряжение с КТП-10/0,4 с номером 843432. Потребители уведомлены о снятии напряжения.\nДиспетчер: - Снимаю напряжение с КТП-10/0,4 с номером 843432.",
                    ToNode = 0,
                    SpeakEnd = true,

                    ActionRef = "06a9e850-b562-4209-b98d-765fa8b7d071",
                    ElementRef = "",
                    InventoryItemRef = "41a454ad-e7cb-4785-a4d5-d969f42abb81"
                };
                Answer ans0_5 = new Answer
                {
                    Text = "Я: - Прошу подать напряжение на КТП-10/0,4 с номером 321455. \"Считаю, КТП 10 / 0.4 под напряжением\"\nДиспетчер: - Напряжение подано",
                    ToNode = 0,
                    SpeakEnd = true,

                    ActionRef = "604640b3-f525-4e48-a051-8e008d9dd286",
                    ElementRef = "",
                    InventoryItemRef = "41a454ad-e7cb-4785-a4d5-d969f42abb81"
                };
                node0.PlayerAnswer = new Answer[] { ans0_1, ans0_2, ans0_3, ans0_4, ans0_5 };

                //DialogueNode node1 = new DialogueNode();
                //node1.NpcText = "Выполняю снятие напряжения с КТП-10/0,4.";
                //node1.PlayerAnswer = new Answer[] { ans0_2, ans0_3, ans0_4, ans0_5 };

                //DialogueNode node2 = new DialogueNode();
                //node2.NpcText = "Подтверждаю о снятии напряжения с КТП-10/0,4.";
                //node2.PlayerAnswer = new Answer[] { ans0_3, ans0_4, ans0_5 };

                //DialogueNode node3 = new DialogueNode();
                //node3.NpcText = "Подано напряжение на КТП 10/0,4.";
                //node3.PlayerAnswer = new Answer[] { ans0_5 };

                dialogueScript._currentNode = 0;
                dialogueScript.node = new DialogueNode[] { node0 };
                dialogueScript.ShowDialogue = true;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MouseLook scriptMouseLook = gameObject.GetComponent<MouseLook>();
        //    if (Cursor.visible == true)
        //    {
        //        Cursor.visible = false;
        //        Cursor.lockState = CursorLockMode.Locked;
        //        scriptMouseLook.enabled = true;
        //    }
        //    else
        //    {
        //        Cursor.visible = true;
        //        Cursor.lockState = CursorLockMode.None;
        //        scriptMouseLook.enabled = false;
        //    }
        //
        //
        //    GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
        //    Actions unityApiScript = gameObjectUnityApi.GetComponent<Actions>();
        //    Actions.show = !Actions.show;
        //
        //}


    }


    public void ManageTaskDialog()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            taskDialog.showTaskDialog = !taskDialog.showTaskDialog;
            if (taskDialog.showTaskDialog)
            {
                taskDialog.scriptMouseLook.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                taskDialog.scriptMouseLook.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Help scriptHelp = gameObject.GetComponent<Help>();
                scriptHelp.enabled = true;
            }
        }
       
    }


    void OnGUI()
	{
        GUI.skin = skin;
        GUI.skin.font = font;

        GUI.DrawTexture (new Rect (Screen.width / 2, Screen.height / 2, 15, 15), CursoreTexture);


     //   GameObject gObjectStolb = GameObject.Find("Stolb");
     //   GameObject gObjectCube = GameObject.Find("Cube");
     //   // GameObject.GetComponent

     //   Material materialCube = gObjectCube.GetComponent<MeshRenderer>().material;

     //   //gObject.GetComponent<MeshRenderer>().material = materialCube;
     //   //Resources.LoadAssetAtPath
     //   Material materialStolb = gObjectStolb.GetComponent<MeshRenderer>().material;
     //   materialStolb.mainTexture = materialCube.mainTexture;

     //   Material myMaterial = Resources.Load("Пол1") as Material;

     //   materialStolb = myMaterial;
     //   //Material materialCube2 = JsonUtility.FromJson<Material>(materialCube.name);// PlayerPrefs.GetString("color"));

     //   // UnityEditor.GameObjectUtility  gameObjectUtility;


     //   //EditorUtility.sa

     //   //  PlayerPrefs.SetString("color", JsonUtility.ToJson(myColor));

     //   //Undo.RecordObject(target, GetType().Name);

     //   //if (GUI.changed)
     //   //{
     //   //    EditorUtility.SetDirty(target);
     //   //}
        

     ////   EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
     //   EditorUtility.SetDirty(gObjectStolb);
    }
}
