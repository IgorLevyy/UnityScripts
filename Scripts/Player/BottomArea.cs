using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomArea : MonoBehaviour
{
    public GUISkin skin;
    private float timer;
    private DateTime dateTime;
    private DateTime dateTimeNow;
    // Start is called before the first frame update
    void Start()
    {
        dateTimeNow = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
       // if (timer < 99999.0f)
       // {
       //     timer += Time.deltaTime;
       //     
       // }
       
    }
    void OnGUI()
    {
        
        GUI.skin = skin;
        //GUI.Window(0, new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), InventoryBody, "Inventory");
        //GUI.Window(0, new Rect(1000, 500, 500, 500), InventoryBody, "Inventory");
        // GUI.Window(0, new Rect(Screen.width / 4, Screen.height / 4, Screen.height - 50, 500), InventoryBody, "Inventory");
        //GUI.Label(new Rect(500f, 65f, 200f, 35f), "Название: ");
        //GUILayout.Box("1232132131", GUILayout.Width(100f), GUILayout.Height(100f));
        GUI.Box(new Rect(Screen.width / 2.5f, Screen.height - Screen.height / 9, Screen.width / 4 , Screen.height / 11), "");
        GUI.Label(new Rect(Screen.width / 1.7f, Screen.height - Screen.height / 12, Screen.width / 19, Screen.height / 12), (DateTime.Now - dateTimeNow).ToString().Remove(8));
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 1.1f, Screen.width / 38, Screen.height / 15), "");
        //GUILayout.BeginArea(new Rect(60f, 60f, 100f, 600f));

        //GUILayout.EndArea();
    }
    void InventoryBody(int id)
    {
        //InitSceneScript scriptSetActive = GameObject.Find("Player").GetComponent<InitSceneScript>();
        //EProject eProject = scriptSetActive.eProject;

        //if (currItem)
        //{
        //
        //    GUI.Box(new Rect(400f, 60f, 300f, 230f), "");
        //    GUI.DrawTexture(new Rect(410f, 65f, 80f, 100f), currItem.texture);
        //    //GUI.color = Color.red;
        //    GUI.Label(new Rect(500f, 65f, 200f, 35f), "Название: " + currItem.name);
        //    //GUI.color = Color.white;
        //    GUI.Label(new Rect(500f, 100f, 200f, 100f), "Описание: " + currItem.discription);
        //}
        //GUILayout.BeginArea(new Rect(60f, 60f, 100f, 600f));

        GUILayout.Box("", GUILayout.Width(100f), GUILayout.Height(100f));
        //for (int i = 0; i < 3; i++)
        //{
        //    if (items[i] != null)
        //    {
        //        if (GUILayout.Button(items[i].texture, GUILayout.Width(100f), GUILayout.Height(100f)))
        //        {
        //            currItem = items[i];
        //        }
        //    }
        //    else
        //    {
        //        GUILayout.Box("", GUILayout.Width(100f), GUILayout.Height(100f));
        //    }
        //
        //}

        //GUILayout.EndArea();



      



    }
}
