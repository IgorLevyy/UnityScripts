using EProjectNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePanel : MonoBehaviour {
    //public GUIText text;
    // public float alpha = 0.4f;
    // Use this for initialization
    public string title;

    public Font font;
    // GameObject test = GameObject.FindGameObjectWithTag("Player");
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }
    void OnGUI()
    {
        GUI.skin.font = font; // Resources.GetBuiltinResource(typeof(Font), "Times.ttf") as Font;
        GUI.color = Color.black;
        GUI.Label(new Rect(400, 10, 200, 100), title);

        InitSceneScript scriptSetActive = gameObject.GetComponent<InitSceneScript>();
        if (scriptSetActive != null)
        {
            EProject eProject = scriptSetActive.eProject;
            if(eProject != null)
            {
                if (eProject.InventoryItemCurrent != null)
                {
                    GUI.color = Color.white;
                   // GUI.Label(new Rect(Screen.width / 2.5f, Screen.height / 1.1f, 75, 150), eProject.InventoryItemCurrent.Title, new GUIStyle() { fontSize = 15 }); //Текст
                    GUI.color = Color.white;
                    //GUI.Box(new Rect(900f, 820f, 50f, 60f), "");
                    //GUI.Box(new Rect(Screen.width / 2, Screen.height / 1.1f, Screen.width / 38, Screen.height / 15), "");
                    //GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 1.1f, Screen.width / 38, Screen.height / 15), eProject.InventoryItemCurrent.Texture);
                }
            }
            

        }
    }
}
