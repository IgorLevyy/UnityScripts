using EProjectNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public delegate void StartInventoryEventHandler();
    public static event StartInventoryEventHandler StartInventoryEvent;

    public bool show = false;
    public GUISkin skin;
    public MouseLook mouseLook;
    // Use this for initialization
    public List<Item> items = new List<Item>();
    public float maxMass = 50f;
    public float currMass = 0f;
    [HideInInspector] public Item currItem;
    //EProject eProject = new EProject();
    public Transform RaycastS;
    private RaycastHit Hit;
    private GameObject[] targetAll;

    private GameObject useGameObject;
    private GameObject useGameObjectPrev;
    private float zom;
    private int number = 0;

    private int itemCount = 0; // Количество элементов в инвентаре


    void Start()
    {
        //RebuilMase();



        //eProject.Init();
    }

    void AddMass(float mass)
    {
        currMass += mass;
    }
    //void RebuilMase()
    //{
    //    currMass = 0f;
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        if (items[i] != null)
    //        {
    //            if (items[i].count > 0)
    //            {
    //                currMass += items[i].count * items[i].mass;
    //            }
    //        }
    //    }
    //}
    int countItems(List<Item> items) //Подсчет элементов в инвентаре
    {
        int count = 0;
        foreach(var i in items)
        {
            if(i != null)
            {
                count++;
            }
        }

        
        return count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            StartInventoryEvent?.Invoke();

            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            Zoom scriptZoom = GameObject.Find("Player").GetComponent<Zoom>();

            show = !show;
            if (show)
            {
                scriptMouseLook.enabled = false;
                scriptZoom.enabled = false;
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
                currItem = items[0]; //Показывать в инвентаре первый предмет
            }
            else
            {
                scriptMouseLook.enabled = true;
                scriptZoom.enabled = true;
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
                currItem = items[0]; //Показывать в инвентаре первый предмет
            }

            itemCount = countItems(items);
        }

        zom = Input.GetAxis("Mouse ScrollWheel");

        if (zom > 0)
        {

            if (number < itemCount - 1)
            {
                number++;
            }
            currItem = items[number];
        }

        if (zom < 0)
        {
            if (number > 0)
            {
                number--;
            }
            currItem = items[number];
        }

        if (Input.GetMouseButtonDown(0) && show)
        {
            InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
            EProject eProject = scriptSetActive.eProject;
            //Debug.Log(currItem.name);
            //Debug.Log(currItem.texture);
            //GameObject gameObjectChild;
            //InventoryItems = new List<InventoryItem>();
            //gameObjectChild = transform.GetChild(i).gameObject;
            //InventoryItem inventoryItem = new InventoryItem
            //{
            //    Id = gameObjectChild.name,
            //    Title = gameObjectChild.name,
            //};
            //InventoryItems.Add(inventoryItem);
            eProject.InventoryItemCurrent = new EProjectNS.InventoryItem();
            eProject.InventoryItemCurrent.Id = currItem.name;
            eProject.InventoryItemCurrent.Title = currItem.name;
            eProject.InventoryItemCurrent.Texture = currItem.texture;
            //Debug.Log("eProject: " + eProject);
            // Debug.Log("eProject.InventoryItemCurrent: " + eProject.InventoryItemCurrent);
            //Debug.Log(currItem.name);
            GameObject gameObjectInventory = GameObject.Find(currItem.name);
            Item item = gameObjectInventory.GetComponent<Item>();


            show = false;
            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            scriptMouseLook.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            currItem = null;

            if (useGameObjectPrev != null)
            {
                Destroy(useGameObjectPrev);

            }

            //Debug.Log("QWEEIYQGI: " + GameObject.Find("Табличка <Не включать, работают люди> Inventory").transform.localRotation);
            //Debug.Log("QWEEIYQGIweqeqeeqewq: " + GameObject.Find("Табличка <Не включать, работают люди> Inventory").transform.rotation);

            GameObject newGameObject = Instantiate(gameObjectInventory);
            newGameObject.transform.parent = GameObject.Find("Main Camera").transform;
            // newGameObject.transform.localRotation.x;
            //GameObject newGameObject = gameObjectInventory
            newGameObject.transform.localEulerAngles = item.rotarion;
            newGameObject.transform.localScale = item.scale;
            newGameObject.transform.localPosition = item.position;
            //Debug.Log("NameGameObject: " + gameObjectInventory);
            //Debug.Log(gameObjectInventory);
            //Debug.Log(gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject);

            // GameObject gameObject = GameObject.Find("Заземлено");//eProject.InventoryItemCurrent.Title);
            //GameObject gameObjectCamera = GameObject.Find("Player");.
            //Debug.Log(gameObject);
            //Debug.Log("CHILD_COUNT " + GameObject.Find(eProject.InventoryItemCurrent.Title).transform.childCount);
            //Debug.Log("CHILD_COUNT " + GameObject.Find(eProject.InventoryItemCurrent.Title));

            if (newGameObject.transform.childCount > 1)
            {
                //Debug.Log("NOT TABLE");
                Debug.Log(newGameObject.transform.GetChild(0).gameObject.GetComponent<Use>().enabled = true);
            }
            // if (GameObject.Find(eProject.InventoryItemCurrent.Title).transform.childCount > 1)
            // {
            //     gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
            //     gameObjectInventory.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>().enabled = true;
            // } else
            // {
            //     gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
            //    // Debug.Log("123213213");
            // }
            // useGameObject = gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject;
            //

            useGameObjectPrev = newGameObject;
            eProject.GameObjectInventoryItemCurrent = newGameObject;
            //Debug.Log(GameObject.Find("Table12"));


            //newGameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            //newGameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
            //gameObject.transform.parent = gameObjectCamera.transform;
            newGameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
            GameObject.Find("Player").GetComponent<Zoom>().enabled = true;
        }

        if (Input.GetMouseButtonDown(1) && show)
        {
            InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
            EProject eProject = scriptSetActive.eProject;


            eProject.InventoryItemCurrent = null;//eProject.Inventory.GetInventoryItem(currItem.name);
            eProject.GameObjectInventoryItemCurrent = null;
            //eProject.InventoryItemCurrent.Texture = null;//currItem.texture;

            show = false;
            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            scriptMouseLook.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            currItem = items[0];

            //Debug.Log("USE");
            //useGameObject.GetComponent<Renderer>().enabled = false;
            //if (useGameObject.transform.parent.parent.childCount > 1)
            //{
            //    useGameObject.transform.parent.GetChild(1).GetComponent<Renderer>().enabled = false;
            //}
            Destroy(useGameObjectPrev);
            GameObject.Find("Player").GetComponent<Zoom>().enabled = true;

        }
        //Vector3 Direction = RaycastS.TransformDirection(Vector3.forward);
        //if (Physics.Raycast(RaycastS.position, Direction, out Hit, 1000f))
        //{
        //
        //    if (Hit.collider.material.name == "KTP5-3886|:|B8A4396250C5687B1D31E70758B30729E1AC4426")
        //    {
        //        //Using1 usingScript = Hit.collider.gameObject.GetComponent<Using1>();
        //        //if (usingScript)
        //        //{
        //        //    Using1.gameObjectForShader = Hit.collider.gameObject;
        //        //}
        //
        //        print(Hit.collider.material.name);
        //    }
        //}
    }
    void OnGUI()
    {
        if (show)
        {
            GUI.skin = skin;
            //GUI.Window(0, new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), InventoryBody, "Inventory");
            //GUI.Window(0, new Rect(1000, 500, 500, 500), InventoryBody, "Inventory");
            GUI.Window(0, new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), InventoryBody, "Inventory");
        }
    }
    public void Use(Item item)
    {
        item.count--;
        RemoveItem(item);
        currItem = null;
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
            }
        }
    }

    void InventoryBody(int id)
    {
        InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
        EProject eProject = scriptSetActive.eProject;

        if (currItem)
        {

            GUI.Box(new Rect(Screen.width / 4.75f, Screen.height / 15f, Screen.width / 6.33f, Screen.height / 7f), "");
            GUI.DrawTexture(new Rect(Screen.width / 4.6f, Screen.height / 13.8f, Screen.width / 23.75f, Screen.height / 9), currItem.texture);
            //GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 3.8f, Screen.height / 13.85f, Screen.width / 9.5f, Screen.height / 24f), "Название: " + currItem.name);
            //GUI.color = Color.white;
            GUI.Label(new Rect(Screen.width / 3.8f, Screen.height / 8, Screen.width / 9.5f, Screen.height / 9), "Описание: " + currItem.discription);
            /*
            if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 3.83f, Screen.width / 12.7f, Screen.height / 18), "Отмена"))
            {
                currItem = null;
            } */

            /*
            if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 5, Screen.width / 12.7f, Screen.height / 18), "Использовать"))
            {
                //Debug.Log(currItem.name);
                //Debug.Log(currItem.texture);
                //GameObject gameObjectChild;
                //InventoryItems = new List<InventoryItem>();
                //gameObjectChild = transform.GetChild(i).gameObject;
                //InventoryItem inventoryItem = new InventoryItem
                //{
                //    Id = gameObjectChild.name,
                //    Title = gameObjectChild.name,
                //};
                //InventoryItems.Add(inventoryItem);
                eProject.InventoryItemCurrent = new EProjectNS.InventoryItem();
                eProject.InventoryItemCurrent.Id = currItem.name;
                eProject.InventoryItemCurrent.Title = currItem.name;
                eProject.InventoryItemCurrent.Texture = currItem.texture;
                //Debug.Log("eProject: " + eProject);
               // Debug.Log("eProject.InventoryItemCurrent: " + eProject.InventoryItemCurrent);
                //Debug.Log(currItem.name);
                GameObject gameObjectInventory = GameObject.Find(currItem.name);
                Item item = gameObjectInventory.GetComponent<Item>();
                

                show = false;
                MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
                scriptMouseLook.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                currItem = null;

                if (useGameObjectPrev != null)
                {
                    Destroy(useGameObjectPrev);

                }

               //Debug.Log("QWEEIYQGI: " + GameObject.Find("Табличка <Не включать, работают люди> Inventory").transform.localRotation);
               //Debug.Log("QWEEIYQGIweqeqeeqewq: " + GameObject.Find("Табличка <Не включать, работают люди> Inventory").transform.rotation);

                GameObject newGameObject = Instantiate(gameObjectInventory);
                newGameObject.transform.parent = GameObject.Find("Main Camera").transform;
                // newGameObject.transform.localRotation.x;
                //GameObject newGameObject = gameObjectInventory
                newGameObject.transform.localEulerAngles = item.rotarion; 
                newGameObject.transform.localScale = item.scale;
                newGameObject.transform.localPosition = item.position;
                //Debug.Log("NameGameObject: " + gameObjectInventory);
                //Debug.Log(gameObjectInventory);
                //Debug.Log(gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject);

                // GameObject gameObject = GameObject.Find("Заземлено");//eProject.InventoryItemCurrent.Title);
                //GameObject gameObjectCamera = GameObject.Find("Player");.
                //Debug.Log(gameObject);
                //Debug.Log("CHILD_COUNT " + GameObject.Find(eProject.InventoryItemCurrent.Title).transform.childCount);
                //Debug.Log("CHILD_COUNT " + GameObject.Find(eProject.InventoryItemCurrent.Title));
               
                if(newGameObject.transform.childCount > 1)
                {
                    //Debug.Log("NOT TABLE");
                    Debug.Log(newGameObject.transform.GetChild(0).gameObject.GetComponent<Use>().enabled = true);
                }
                // if (GameObject.Find(eProject.InventoryItemCurrent.Title).transform.childCount > 1)
               // {
               //     gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
               //     gameObjectInventory.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Renderer>().enabled = true;
               // } else
               // {
               //     gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
               //    // Debug.Log("123213213");
               // }
               // useGameObject = gameObjectInventory.transform.GetChild(0).GetChild(0).gameObject;
               //

                useGameObjectPrev = newGameObject;
                eProject.GameObjectInventoryItemCurrent = newGameObject;
                //Debug.Log(GameObject.Find("Table12"));


                //newGameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                //newGameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;
                //gameObject.transform.parent = gameObjectCamera.transform;
                newGameObject.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = true;

            } */


        }
        GUILayout.BeginArea(new Rect(Screen.width / 31.66f, Screen.height / 15f, Screen.width / 19f, Screen.height / 1.5f));
        for (int i = 0; i < 3; i++)
        {
            if (items[i] != null)
            {
                if (i != number)
                {
                    if (GUILayout.Button(items[i].texture, GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9)))
                    {
                        currItem = items[i];
                    }
                }
                else
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.border.Add(new Rect(1f, 1f, 1f, 1f));
                    if (GUILayout.Button(items[i].texture, gUIStyle, GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9)))
                    {
                        currItem = items[i];
                    }
                }
            }
            else
            {
                GUILayout.Box("", GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9));
            }

        }

        GUILayout.EndArea();


        GUILayout.BeginArea(new Rect(Screen.width / 11.875f, Screen.height / 15f, Screen.width / 19f, Screen.height / 1.5f));
        for (int i = 3; i < 6; i++)
        {
            if (items[i] != null)
            {
                if (i != number)
                {
                    if (GUILayout.Button(items[i].texture, GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9)))
                    {
                        currItem = items[i];
                    }
                }
                else
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.border.Add(new Rect(1f, 1f, 1f, 1f));
                    if (GUILayout.Button(items[i].texture, gUIStyle, GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9)))
                    {
                        currItem = items[i];
                    }
                }
            }
            else
            {
                GUILayout.Box("", GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9));
            }

        }

        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(Screen.width / 7.3f, Screen.height / 15f, Screen.width / 19f, Screen.height / 1.5f));
        for (int i = 6; i < 9; i++)
        {
            if (items[i] != null)
            {
                if (i != number)
                {
                    if (GUILayout.Button(items[i].texture, GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9)))
                    {
                        currItem = items[i];
                    }
                }
                else
                {
                    GUIStyle gUIStyle = new GUIStyle();
                    gUIStyle.border.Add(new Rect(1f, 1f, 1f, 1f));
                    if (GUILayout.Button(items[i].texture, gUIStyle, GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9)))
                    {
                        currItem = items[i];
                    }
                }
            }
            else
            {
                GUILayout.Box("", GUILayout.Width(Screen.width / 19), GUILayout.Height(Screen.height / 9));
            }

        }

        GUILayout.EndArea();

        GUI.Label(new Rect(Screen.width / 4.75f, Screen.height / 4, Screen.width / 4f, Screen.height / 11), "Для использования предмета нажмите левую кнопку мыши");

        GUI.Label(new Rect(Screen.width / 4.75f, Screen.height / 3.5f, Screen.width / 4f, Screen.height / 11), "Для отмены выбора предмета нажмите правую кнопку мыши");

        GUI.Label(new Rect(Screen.width / 4.75f, Screen.height / 3.1f, Screen.width / 4f, Screen.height / 11), "Для выбора предмета используйте колесо мыши");


        /*
        if (GUI.Button(new Rect(Screen.width / 14.615f, Screen.height / 2.37f, Screen.width / 12.66f, Screen.height / 18), "Очистить"))
        {
            eProject.InventoryItemCurrent = null;//eProject.Inventory.GetInventoryItem(currItem.name);
            eProject.GameObjectInventoryItemCurrent = null;
            //eProject.InventoryItemCurrent.Texture = null;//currItem.texture;

            show = false;
            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            scriptMouseLook.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            currItem = null;

            //Debug.Log("USE");
            //useGameObject.GetComponent<Renderer>().enabled = false;
            //if (useGameObject.transform.parent.parent.childCount > 1)
            //{
            //    useGameObject.transform.parent.GetChild(1).GetComponent<Renderer>().enabled = false;
            //}
            Destroy(useGameObjectPrev);


        }
        */
    }

}
