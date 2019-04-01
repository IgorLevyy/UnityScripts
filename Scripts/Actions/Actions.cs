using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using EProjectNS;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ObjectClick")]
public class ObjectClick
{
    [XmlArray("InventoryItems")]
    [XmlArrayItem("InventoryItem")]
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public static ObjectClick Load(TextAsset textAsset)
    {
        //TextAsset xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(ObjectClick));

        StringReader reader = new StringReader(textAsset.text);

        ObjectClick objectClick = serializer.Deserialize(reader) as ObjectClick;

        reader.Close();

        return objectClick;
    }
}

public class InventoryItem
{
    [XmlElement("InventoryName")]
    public string inventoryName;

    [XmlArray("Options")]
    [XmlArrayItem("Option")]
    public List<Option> options = new List<Option>();
}

public class Option
{
    [XmlElement("TargetObject")]
    public string targetObject;

    [XmlArray("Actions")]
    [XmlArrayItem("ActionWithObject")]
    public List<ActionWithObject> actions = new List<ActionWithObject>();
}

public class ActionWithObject
{
    [XmlElement("Name")]
    public string name;

    [XmlElement("ObjectName")]
    public string objectName;
    //public string invenrotyId;
    //public string actionName;
    [XmlElement("TypeEvent")]
    public string typeEvent;

    [XmlElement("Parameter")]
    public string parameter;

    [XmlElement("LogName")]
    public string logName;

    [XmlAttribute("ElementRef")]
    public string ElementRef;

    [XmlAttribute("ActionRef")]
    public string ActionRef;

    [XmlAttribute("InventoryItemRef")]
    public string InventoryItemRef;
}

public class Actions : MonoBehaviour
{

    public static bool showAction = false;
    public GUISkin skin;
    Vector2 scrollPosition;
    public Font font;

    public static ObjectClick objectClickList;
    //public static List<InventoryItem> inventoryTable = new List<InventoryItem>();

    public static string currentObject;
    public static string currentInventory;
    public static Option option;
    private int currentAction = 0;
    private float zom;
    //public List<ActionWithObject> actions = new List<ActionWithObject>();

    // Use this for initialization
    //void Start()
    //{
    //    var act1 = new ActionWithObject
    //    {
    //        name = "Включить QF1",
    //        objectName = "key",
    //        logName = "Включен ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, 25)),

    //        ActionRef = "0d97e02a-1d60-4d7d-b980-8f7737e55a6e",
    //        ElementRef = "128650fb-bfcf-425c-921a-f000412369a8",
    //        InventoryItemRef = "",
    //    };
    //    var act2 = new ActionWithObject
    //    {
    //        name = "Выключить QF1",
    //        objectName = "key",
    //        logName = "Выключен ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, -25)),

    //        ActionRef = "4b46ad1e-5cc8-41cd-8dd1-272f6bd385ab",
    //        ElementRef = "128650fb-bfcf-425c-921a-f000412369a8",
    //        InventoryItemRef = "",
    //    };

    //    var optionWithrotateQF1 = new Option()
    //    {
    //        targetObject = "key"
    //    };

    //    optionWithrotateQF1.actions.Add(act1);
    //    optionWithrotateQF1.actions.Add(act2);

    //    var invItem = new InventoryItem()
    //    {
    //        inventoryName = string.Empty,
    //    };

    //    invItem.options.Add(optionWithrotateQF1);

    //    var act3 = new ActionWithObject
    //    {
    //        name = "Включить QF2",
    //        objectName = "Твердое тело1 1638",
    //        logName = "Включен ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, 25)),

    //        ActionRef = "0d97e02a-1d60-4d7d-b980-8f7737e55a6e",
    //        ElementRef = "f72f3d59-82e5-4da4-87f0-4d6ce0b63a13",
    //        InventoryItemRef = "",
    //    };

    //    var act4 = new ActionWithObject
    //    {
    //        name = "Выключить QF2",
    //        objectName = "Твердое тело1 1638",
    //        logName = "Выключен ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, -25)),

    //        ActionRef = "4b46ad1e-5cc8-41cd-8dd1-272f6bd385ab",
    //        ElementRef = "f72f3d59-82e5-4da4-87f0-4d6ce0b63a13",
    //        InventoryItemRef = "",
    //    };

    //    var optionWithrotateQF2 = new Option()
    //    {
    //        targetObject = "Твердое тело1 1638"
    //    };

    //    optionWithrotateQF2.actions.Add(act3);
    //    optionWithrotateQF2.actions.Add(act4);

    //    invItem.options.Add(optionWithrotateQF2);



    //    var act5 = new ActionWithObject
    //    {
    //        name = "Включить QF3",
    //        objectName = "Твердое тело1 1639",
    //        logName = "Включен ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, 25)),

    //        ActionRef = "0d97e02a-1d60-4d7d-b980-8f7737e55a6e",
    //        ElementRef = "edec83c7-e3b3-4576-af92-53bee28a03d1",
    //        InventoryItemRef = "",
    //    };

    //    var act6 = new ActionWithObject
    //    {
    //        name = "Выключить QF3",
    //        objectName = "Твердое тело1 1639",
    //        logName = "Выключен ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, -25)),

    //        ActionRef = "4b46ad1e-5cc8-41cd-8dd1-272f6bd385ab",
    //        ElementRef = "edec83c7-e3b3-4576-af92-53bee28a03d1",
    //        InventoryItemRef = "",
    //    };

    //    var optionWithrotateQF3 = new Option()
    //    {
    //        targetObject = "Твердое тело1 1639"
    //    };

    //    optionWithrotateQF3.actions.Add(act5);
    //    optionWithrotateQF3.actions.Add(act6);

    //    invItem.options.Add(optionWithrotateQF3);

    //    var act7 = new ActionWithObject
    //    {
    //        name = "Подсветить инструмент",
    //        //objectName = "Ñêðóãëåíèå2",
    //        logName = "Включена подсветка объекта ",
    //        typeEvent = "ChangeShader",
    //        parameter = "Custom/NewSurfaceShader",

    //        ActionRef = "c79b77e8-63b7-40d0-b483-091fd4e05575",
    //        ElementRef = "",
    //        InventoryItemRef = "",
    //    };

    //    var act8 = new ActionWithObject
    //    {
    //        name = "Убрать подсветку инструмента",
    //        //objectName = "Ñêðóãëåíèå2",
    //        logName = "Выключена подсветка объекта ",
    //        typeEvent = "ChangeShader",
    //        parameter = "Standard",

    //        ActionRef = "c79b77e8-63b7-40d0-b483-091fd4e05575",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var act9 = new ActionWithObject
    //    {
    //        name = "Отключить выносной разъединитель 10 кв ВЛ-10 кв № 1 (QS1)",
    //        //objectName = "RotateQS1",
    //        logName = "Отключён ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 180, 180)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var act10 = new ActionWithObject
    //    {
    //        name = "Подключить выносной разъединитель 10 кв ВЛ-10 кв № 1 (QS1)",
    //        //objectName = "RotateQS1",
    //        logName = "Подключён ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 180, -90)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };
    //    var act11 = new ActionWithObject
    //    {
    //        name = "Отключить выносной разъединитель 10 кв ВЛ-10 кв № 1 (QS2)",
    //        //objectName = "RotateQS2",
    //        logName = "Отключён ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, 180)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var act12 = new ActionWithObject
    //    {
    //        name = "Подключить выносной разъединитель 10 кв ВЛ-10 кв № 1 (QS2)",
    //        //objectName = "RotateQS2",
    //        logName = "Подключён ",
    //        typeEvent = "Rotate",
    //        parameter = JsonUtility.ToJson(new Vector3(0, 0, -90)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };
    //    var act13 = new ActionWithObject
    //    {
    //        name = "Заблокировать выносной разъединитель 10 кв ВЛ-10 кв № 1 (QS1)",
    //        //objectName = "BlockQS1",
    //        logName = "Активировано ",
    //        typeEvent = "ChangePositionObject",
    //        parameter = JsonUtility.ToJson(new Vector3( 0f, 0f, -0.00801f)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };
    //    var act14 = new ActionWithObject
    //    {
    //        name = "Заблокировать выносной разъединитель 10 кв ВЛ-10 кв № 1 (QS2)",
    //        //objectName = "BlockQS2",
    //        logName = "Активировано ",
    //        typeEvent = "ChangePositionObject",
    //        parameter = JsonUtility.ToJson(new Vector3(0f, 0f, -0.00801f)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var act15 = new ActionWithObject
    //    {
    //        name = "Привод запереть на замок(PRNZ-10)",
    //        objectName = "Замок",
    //        logName = "Привод заперт на ",
    //        typeEvent = "ChangePositionObject",
    //        parameter = JsonUtility.ToJson(new Vector3(-0.2141f, -0.7f, 3.8229f)),

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var act16 = new ActionWithObject
    //    {
    //        name = "На автоматы 0,4 кв (QF1 QF2 QF3 ) вывесить плакат \"Не включать - работают люди\"",
    //       // objectName = "Табличка <Не включать, работают люди>",
    //        logName = "На автоматы 0,4 кв (QF1 QF2 QF3 ) прикреплена ",
    //        typeEvent = "ChangePositionObject",
    //        parameter = JsonUtility.ToJson(new Vector3(0f, 0f, 5.519f)),

    //        ActionRef = "44dfc5e7-1da0-48c6-b0b3-ce2e3367db17",
    //        ElementRef = "f72f3d59-82e5-4da4-87f0-4d6ce0b63a13",
    //        InventoryItemRef = "e090b2c4-5f70-4674-be3f-c373589fd82d"
    //    };

    //    var act17 = new ActionWithObject
    //    {
    //        name = "Вытащить предохранитель 0,4 кв трансформатора FU4",
    //        objectName = "Твердое тело1 1513",
    //        logName = "Скрыто ",
    //        typeEvent = "HideObject",
    //        //parameter = JsonUtility.ToJson(new Vector3(0f, 0f, 5.519f))

    //        ActionRef = "4b583a91-ebea-45ad-9540-a34b3486a500",
    //        ElementRef = "441cf9b5-c234-4c62-9b58-be019c92faec",
    //        InventoryItemRef = ""
    //    };

    //    var optionHideFU4 = new Option()
    //    {
    //        targetObject = "Твердое тело1 1513"
    //    };

    //    optionHideFU4.actions.Add(act17);
    //    invItem.options.Add(optionHideFU4);


    //    var act18 = new ActionWithObject
    //    {
    //        name = "Вытащить предохранитель 0,4 кв трансформатора FU5",
    //        objectName = "Твердое тело1 1536",
    //        logName = "Скрыто ",
    //        typeEvent = "HideObject",

    //        ActionRef = "4b583a91-ebea-45ad-9540-a34b3486a500",
    //        ElementRef = "5c545b9b-9e83-43f0-a4e2-fcc69698421b",
    //        InventoryItemRef = ""
    //    };

    //    var optionHideFU5 = new Option()
    //    {
    //        targetObject = "Твердое тело1 1536"
    //    };

    //    optionHideFU5.actions.Add(act18);
    //    invItem.options.Add(optionHideFU5);

    //    var act19 = new ActionWithObject
    //    {
    //        name = "Вытащить предохранитель 0,4 кв трансформатора FU6",
    //        objectName = "Твердое тело1 1559",
    //        logName = "Скрыто ",
    //        typeEvent = "HideObject",

    //        ActionRef = "4b583a91-ebea-45ad-9540-a34b3486a500",
    //        ElementRef = "e12d72dc-4ad9-411a-afba-c6c80823fa9c",
    //        InventoryItemRef = ""
    //    };

    //    var optionHideFU6 = new Option()
    //    {
    //        targetObject = "Твердое тело1 1559"
    //    };

    //    optionHideFU6.actions.Add(act19);
    //    invItem.options.Add(optionHideFU6);

    //    var act20 = new ActionWithObject
    //    {
    //        name = "Поставить на место предохранитель 0,4 кв трансформатора FU4",
    //        objectName = "Твердое тело1 1513",
    //        logName = "Отображено ",
    //        typeEvent = "UnHideObject",

    //        ActionRef = "f9f88514-a069-40d3-900d-b6415ec30baa",
    //        ElementRef = "441cf9b5-c234-4c62-9b58-be019c92faec",
    //        InventoryItemRef = "ed5353fa-53bd-4e20-ae4c-0d3ea960936b"
    //    };

    //    var optionUnHideFU4 = new Option()
    //    {
    //        targetObject = "предох прозр1"
    //    };

    //    optionUnHideFU4.actions.Add(act20);

    //    var act21 = new ActionWithObject
    //    {
    //        name = "Поставить на место предохранитель 0,4 кв трансформатора FU5",
    //        objectName = "Твердое тело1 1536",
    //        logName = "Отображено ",
    //        typeEvent = "UnHideObject",

    //        ActionRef = "f9f88514-a069-40d3-900d-b6415ec30baa",
    //        ElementRef = "5c545b9b-9e83-43f0-a4e2-fcc69698421b",
    //        InventoryItemRef = "ed5353fa-53bd-4e20-ae4c-0d3ea960936b"
    //    };

    //    var optionUnHideFU5 = new Option()
    //    {
    //        targetObject = "предох прозр2"
    //    };

    //    optionUnHideFU5.actions.Add(act21);

    //    var act22 = new ActionWithObject
    //    {
    //        name = "Поставить на место предохранитель 0,4 кв трансформатора FU6",
    //        objectName = "Твердое тело1 1559",
    //        logName = "Отображено ",
    //        typeEvent = "UnHideObject",

    //        ActionRef = "f9f88514-a069-40d3-900d-b6415ec30baa",
    //        ElementRef = "e12d72dc-4ad9-411a-afba-c6c80823fa9c",
    //        InventoryItemRef = "ed5353fa-53bd-4e20-ae4c-0d3ea960936b"
    //    };

    //    var optionUnHideFU6 = new Option()
    //    {
    //        targetObject = "предох прозр3"
    //    };

    //    optionUnHideFU6.actions.Add(act22);

    //    var invPred = new InventoryItem()
    //    {
    //        inventoryName = "Патрон предохранителя_инвентарь",
    //    };
    //    invPred.options.Add(optionUnHideFU4);
    //    invPred.options.Add(optionUnHideFU5);
    //    invPred.options.Add(optionUnHideFU6);

    //    var invItemTable1 = new InventoryItem()
    //    {
    //        inventoryName = "Табличка <Не включать, работают люди>",
    //    };

    //    var act23 = new ActionWithObject
    //    {
    //        name = "Вывесить плакат Не включать - работают люди",
    //        objectName = "Табличка <Не включать, работают люди>",
    //        logName = "Повесить ",
    //        typeEvent = "UseTable",
    //        parameter = "SRF3 2",

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var optionUse = new Option()
    //    {
    //        targetObject = "SRF3 2"
    //    };

    //    optionUse.actions.Add(act23);
    //    invItemTable1.options.Add(optionUse);


    //    var act24 = new ActionWithObject
    //    {
    //        name = "Убрать плакать Не включать - работают люди",
    //        objectName = "Табличка <Не включать, работают люди> SRF3 2",
    //        logName = "Убрать ",
    //        typeEvent = "DestroyObject",
    //        parameter = "",

    //        ActionRef = "a81d97af-164e-4fa6-8d22-10c011f74b25",
    //        ElementRef = "f72f3d59-82e5-4da4-87f0-4d6ce0b63a13",
    //        InventoryItemRef = ""
    //    };

    //    var optionDestroyTable = new Option()
    //    {
    //        targetObject = "Табличка <Не включать, работают люди> SRF3 2"
    //    };

    //    optionDestroyTable.actions.Add(act24);
    //    invItem.options.Add(optionDestroyTable);


    //    var invItemLadder = new InventoryItem()
    //    {
    //        inventoryName = "Лестница",
    //    };

    //    var act25 = new ActionWithObject
    //    {
    //        name = "Поставить лестницу",
    //        objectName = "Лестница",
    //        logName = "Поставить ",
    //        typeEvent = "UseTable",
    //        parameter = "Твердое тело1 1087",

    //        ActionRef = "864677cd-7673-4ead-b78c-caba4f7e1ff9",
    //        ElementRef = "b55f81bb-f4aa-40ef-928f-388b63789540",
    //        InventoryItemRef = "69b27162-b364-43d2-ba19-71d07b560fbf"
    //    };

    //    var optionUseLadder = new Option()
    //    {
    //        targetObject = "Твердое тело1 1087"
    //    };

    //    optionUseLadder.actions.Add(act25);
    //    invItemLadder.options.Add(optionUseLadder);

    //    var act26 = new ActionWithObject
    //    {
    //        name = "Убрать лестницу",
    //        objectName = "Лестница Твердое тело1 1087",
    //        logName = "Убрать ",
    //        typeEvent = "DestroyObject",
    //        parameter = "",

    //        ActionRef = "",
    //        ElementRef = "",
    //        InventoryItemRef = ""
    //    };

    //    var optionDestroyLadder = new Option()
    //    {
    //        targetObject = "Лестница Твердое тело1 1087"
    //    };

    //    //optionDestroyTable.actions.Add(act26);
    //    //invItem.options.Add(optionDestroyTable);

    //    inventoryTable.Add(invItem);
    //    inventoryTable.Add(invPred);
    //    inventoryTable.Add(invItemTable1);
    //    inventoryTable.Add(invItemLadder);
    //    //actions.Add(act1);
    //    //actions.Add(act2);
    //    //actions.Add(act3);
    //    //actions.Add(act4);
    //    //actions.Add(act5);
    //    //actions.Add(act6);
    //    //actions.Add(act7);
    //    //actions.Add(act8);
    //    //actions.Add(act9);
    //    //actions.Add(act10);
    //    //actions.Add(act11);
    //    //actions.Add(act12);
    //    //actions.Add(act13);
    //    //actions.Add(act14);
    //    //actions.Add(act15);
    //    //actions.Add(act16);
    //    //actions.Add(act17);
    //    //actions.Add(act18);
    //    //actions.Add(act19);
    //}

    void Start()
    {
        TextAsset xmlAsset = Resources.Load("UnityInventory") as TextAsset;

        objectClickList = ObjectClick.Load(xmlAsset);
    }

    // Update is called once per frame
    void Update()
    {
        zom = Input.GetAxis("Mouse ScrollWheel");

        if (zom < 0)
        {
            //print(currentButton);
            if (option != null)
            {
                if (currentAction < option.actions.Count - 1)
                {
                    currentAction++;
                }
            }
            // currItem = items[currentButton];
        }

        if (zom > 0)
        {
            //print(currentButton);
            if (currentAction > 0)
            {
                currentAction--;
            }
            //currItem = items[currentButton];
        }
        if (Input.GetMouseButtonDown(0) && showAction && !GameObject.Find("Player").GetComponent<Zoom>().enabled)
        {
            int i = currentAction;

            DoAction(option.actions[i]);
        }
    }

    void OnGUI()
    {
        if (showAction)
        {
            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            Zoom scriptZoom = GameObject.Find("Player").GetComponent<Zoom>();
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
            scriptMouseLook.enabled = false;
            scriptZoom.enabled = false;

            GUI.skin = skin;
            GUI.skin.font = font;
            GUI.Window(0, new Rect(Screen.width / 3, Screen.height / 3, 700, 200), ActionsBody, "Выберите действие");
        }
    }

    void ActionsBody(int id)
    {
        scrollPosition = GUILayout.BeginScrollView(
           scrollPosition, GUILayout.Width(690), GUILayout.Height(180));

        Color color = GUI.backgroundColor;

        for (int i = 0; i < option.actions.Count; i++)
        {
            if (i != currentAction)
            {
                if (option.actions[i] != null)
                {
                    if (GUILayout.Button(option.actions[i].name))
                    {
                        DoAction(option.actions[i]);
                    }
                }
                else
                {
                    GUILayout.Box("", GUILayout.Width(100f), GUILayout.Height(100f));
                }
            } else
            {
                GUI.backgroundColor = Color.green;
                if (option.actions[i] != null)
                {
                    if (GUILayout.Button(option.actions[i].name))
                    {
                        DoAction(option.actions[i]);
                    }
                }
                else
                {
                    GUILayout.Box("", GUILayout.Width(100f), GUILayout.Height(100f));
                }
                GUI.backgroundColor = color;

            }
        }
                       
        GUILayout.EndScrollView();
    }

    public static void DoAction(ActionWithObject action)
    {
        Stopwatch SW = new Stopwatch();
        SW.Start();

        MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
        Zoom scriptZoom = GameObject.Find("Player").GetComponent<Zoom>();
        scriptMouseLook.enabled = true;
        scriptZoom.enabled = true;
       //Cursor.visible = false;
       //Cursor.lockState = CursorLockMode.Locked;

        GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
        UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

        var gameObject = GameObject.Find("UnityAPI");
        Logging log = gameObject.GetComponent<Logging>();

        switch (action.typeEvent)
        {
            case "Rotate":
                var jsonParametersRotateGameObject = new JsonParametersRotateGameObject
                {
                    ObjectName = action.objectName,
                    Angle = JsonUtility.FromJson<Vector3>(action.parameter),
                    IsSpecific = true,
                    IsLocal = true
                };

                string json = JsonUtility.ToJson(jsonParametersRotateGameObject);
                unityApiScript.RotateGameObject(json);

                SW.Stop();

                break;

            case "ChangeShader":
                var jsonParametersShaderGameObject = new JsonParametersShaderGameObject
                {
                    ObjectName = action.objectName,
                    shaderName = action.parameter
                };

                string json1 = JsonUtility.ToJson(jsonParametersShaderGameObject);
                unityApiScript.ChangeShader(json1);

                SW.Stop();

                break;

            case "ChangePositionObject":
                var param = JsonUtility.FromJson<Vector3>(action.parameter);
                var jsonParametersPositionGameObject = new JsonParametersPositionGameObject
                {
                    ObjectName = action.objectName,
                    Position = param,
                    SetNew = true
                };

                string json2 = JsonUtility.ToJson(jsonParametersPositionGameObject);
                unityApiScript.ChangePositionObject(json2);

                SW.Stop();

                break;

            case "HideObject":
                var jsonParametersHideGameObject = new BaseJsonParametrs
                {
                    ObjectName = action.objectName
                };

                string json3 = JsonUtility.ToJson(jsonParametersHideGameObject);

                unityApiScript.HighGameObject(json3);

                SW.Stop();

                break;

            case "UnHideObject":
                var jsonParametersUnHideGameObject = new BaseJsonParametrs
                {
                    ObjectName = action.objectName
                };

                string json4 = JsonUtility.ToJson(jsonParametersUnHideGameObject);

                unityApiScript.UnHighGameObject(json4);

                SW.Stop();

                break;

            case "UseTable":
                //var param1 = JsonUtility.FromJson<Vector3[]>(action.parameter);
                //var jsonParametersUseGameObject = new JsonParametersUseTableGameObject
                //{
                //    Angle = param1[1],
                //    Position = param1[0]
                //};

                //string json4 = JsonUtility.ToJson(jsonParametersUseGameObject);

                //unityApiScript.RotateGameObject(json4);
                //GameObject.Find(action.parameter).transform.eulerAngles
                var targetGO = GameObject.Find(action.parameter);
                TablesScript tablesScript = targetGO.GetComponent<TablesScript>();

                if (GameObject.Find(action.objectName + action.parameter) != null)
                {
                    break;
                }
                GameObject newTable = Instantiate(GameObject.Find(action.objectName));
                newTable.name = action.objectName + " " + action.parameter;
                newTable.transform.parent = targetGO.transform;
               // BoxCollider box = newTable.AddComponent<BoxCollider>();
                OnChose onChose = newTable.transform.GetChild(0).GetChild(0).GetComponent<OnChose>();
                if (onChose)
                {
                    onChose.enabled = false;
                }

                var boxCollider = newTable.transform.GetChild(0).GetChild(0).transform.GetComponent<BoxCollider>();
                //boxCollider.enabled = false;
                
                //newTable.transform.eulerAngles = new Vector3(-90f, -90f, 270f);
                //newTable.transform.eulerAngles = new Vector3(-0,3641f, 0,2124f, 0,102f);

                var jsonParametersRotateGameObject1 = new JsonParametersRotateGameObject
                {
                    ObjectName = newTable.name,//action.objectName,
                    Angle = tablesScript.localRotation,//new Vector3(-180f, -1.525879e-05f, -1.525879e-05f),//GameObject.Find(action.parameter).transform.eulerAngles
                    IsSpecific = true,
                    IsLocal = true
                };

                string json5 = JsonUtility.ToJson(jsonParametersRotateGameObject1);
                unityApiScript.RotateGameObject(json5);

                var jsonParametersPositionGameObject1 = new JsonParametersPositionGameObject
                {
                    ObjectName = newTable.name,//action.objectName,
                    Position = tablesScript.localPosition,//new Vector3(-0.121457f, 1.350971f, 3.714326f),//GameObject.Find(action.parameter).transform.position
                    SetNew = true
                };

                

                string json6 = JsonUtility.ToJson(jsonParametersPositionGameObject1);
                unityApiScript.ChangePositionObject(json6);

                InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
                EProject eProject = scriptSetActive.eProject;

                eProject.InventoryItemCurrent = null;
                if (eProject.GameObjectInventoryItemCurrent)
                    GameObject.Destroy(eProject.GameObjectInventoryItemCurrent);

                //InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
                //EProject eProject = scriptSetActive.eProject;
                //eProject.InventoryItemCurrent = null;

                SW.Stop();

                break;

            case "DestroyObject":
                var jsonParametersDestroyGameObject = new BaseJsonParametrs
                {
                    ObjectName = action.objectName
                };

                string json7 = JsonUtility.ToJson(jsonParametersDestroyGameObject);

                unityApiScript.DestroyGameObject(json7);

                SW.Stop();

                break;

            case "Check":


                UnityEngine.Debug.Log("ПРОВЕРКА");

                break;
        }

        InitSceneScript initSceneScript = GameObject.Find("Player").GetComponent<InitSceneScript>();
        initSceneScript._eventListener.SendMessageToSR(action.ElementRef, action.ActionRef, action.InventoryItemRef);

        log.logs.Add(new LogElement
        {
            dataTime = DateTime.Now,
            name = action.logName,
            objName = action.objectName,
            timeExecution = SW.ElapsedMilliseconds.ToString()
        });

        showAction = false;
        
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
        
    }

}

