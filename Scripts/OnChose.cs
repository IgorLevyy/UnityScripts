using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChose : MonoBehaviour {
    private bool light = false;
    private bool map = false;
    public Texture2D[] texKarta;
    private int count = 0;
    Vector2 scrollPosition;


    public static GameObject chosenGameObject = null;

    // Start is called before the first frame update
    void Start()
    {
        chosenGameObject = gameObject;

        //Debug.Log("132");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked && gameObject.name != "Map" && chosenGameObject == gameObject)
        {
            Debug.Log(gameObject.name);
            //Debug.Log(gameObject.transform.parent.parent.gameObject.ToString());
            GameObject gameObjectUnityApi = GameObject.Find("UnityAPI");
            UnityApiScript unityApiScript = gameObjectUnityApi.GetComponent<UnityApiScript>();

            // string[] gameObjects = { "Телефон", "|Табличка <Заземлено>", "Лестница" };

            //string gOb = gameObject.transform.parent.parent.name;//.gameObject.ToString();
            //Debug.Log(gOb);
            //GameObject gameObjectTarget = GameObject.Find(gOb + " Item");
            //Debug.Log(gameObjectTarget);
            Debug.Log(gameObject);
            GameObject gameObjectTarget = gameObject.transform.parent.parent.gameObject;
            Item item = gameObjectTarget.GetComponent<Item>();
            Debug.Log(item);
            Inventory inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            Debug.Log(inventory);
            inventory.items.Insert(0, item);
            //unityApiScript.AddItemInInventory(gOb);

           // gameObject.SetActive(false);
            gameObject.transform.GetComponent<Renderer>().enabled = false;

        }
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked && gameObject.name == "Map" && chosenGameObject == gameObject)
        {
            map = !map;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            map = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (count < texKarta.Length - 1) count++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            if (count > 0) count--;
        }
    }

    void OnMouseEnter()
    {
        //Debug.Log(gameObject);
       

    }
    void OnMouseExit()
    {
        //Debug.Log(gameObject);
       

    }

    void OnGUI()
    {

        if (map)
        {
            //отображаем карту на весь экран
            //scrollPosition = GUILayout.BeginScrollView(
            //scrollPosition, GUILayout.Width(690), GUILayout.Height(180));
            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texKarta[count], ScaleMode.ScaleToFit);

            //GUILayout.EndScrollView();
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            //GUI.DrawTexture(new Rect(0f, 0f, 250f, 200f), texKarta[count]);
            //GUILayout.Height(700f);

            GUILayout.Label(texKarta[count]);



            GUI.EndScrollView();
        }

        OperationsWithGameObject.LightObject(gameObject, chosenGameObject);
    }

}
