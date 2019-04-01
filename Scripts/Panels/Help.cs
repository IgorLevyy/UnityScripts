using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {
    //public GUIText text;
    // public float alpha = 0.4f;
    // Use this for initialization
    float h;
    public bool showHelp = false;
    public GUISkin skin;
    public Font font;
    // GameObject test = GameObject.FindGameObjectWithTag("Player");
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        h = gameObject.transform.position.y;
        h = (float)System.Math.Round(h, 2);

        //a  += "1";

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
            Zoom scriptZoom = GameObject.Find("Player").GetComponent<Zoom>();

            showHelp = !showHelp;

           

            if (showHelp)
            {
                scriptMouseLook.enabled = false;
                scriptZoom.enabled = false;
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                scriptMouseLook.enabled = true;
                scriptZoom.enabled = true;
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
            }


        }

    }
    void OnGUI()
    {
        GUI.skin.font = font;// Resources.GetBuiltinResource(typeof(Font), "Times.ttf") as Font;
       // GUI.Label(new Rect(10, 50, 230, 450), "Управление:\n\nОбзор - Мышь.\nВперед: W\nНазад: S\nВлево: A\nВправо: D\nВверх: Q\nВниз: E"
       //     + "\nУскорение (бег): Shift (левый)"
       //     + "\nАктивировать/деактивировать курсор: Ctrl (левый)"
       //     + "\nВзаимодействие с предметом-\n левая кнопка мыши."
       //     + "\nПриближение-\n колесо мыши."
       //     + "\nИнвентарь: I \nФонарь: L"
       //     + "\nЗахватить/отпустить лестницу: F "
       //     + "\nЗакрыть изображение: M "
       //     + "\nВыход из области тренажера: Esc "
       //     + "\n\n\nВысота: " + h.ToString());


        if (showHelp)
        {
            GUI.skin = skin;
            //GUI.Window(0, new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), InventoryBody, "Inventory");
            //GUI.Window(0, new Rect(1000, 500, 500, 500), InventoryBody, "Inventory");
            GUI.Window(0, new Rect(Screen.width / 3, Screen.height / 3, Screen.width / 3, Screen.height / 3), HelpBody, "Help");
        }


    }


    void HelpBody(int id)
    {
        Color color = GUI.backgroundColor;

        GUI.Label(new Rect(10, 25, Screen.width, Screen.height), "Обзор - Мышь.\nВперед: W. Назад: S. Влево: A. Вправо: D. Вверх: Q. Вниз: E"
           + "\nУскорение (бег): Shift (левый)"
           + "\nАктивировать/деактивировать курсор: Ctrl (левый)"
           + "\nВзаимодействие с предметом - левая кнопка мыши."
           + "\nПриближение - колесо мыши."
           + "\nФонарь: L"
           + "\nЗахватить/отпустить лестницу: F "
           + "\nЗакрыть изображение: M "
           + "\nВыход из области тренажера: Esc "
           + "\n\n\nВысота: " + h.ToString());


    }
}
