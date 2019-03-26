using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {
    //public GUIText text;
    // public float alpha = 0.4f;
    // Use this for initialization
    float h;

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
    }
    void OnGUI()
    {
        GUI.skin.font = font;// Resources.GetBuiltinResource(typeof(Font), "Times.ttf") as Font;
        GUI.Label(new Rect(10, 50, 230, 450), "Управление:\n\nОбзор - Мышь.\nВперед: W\nНазад: S\nВлево: A\nВправо: D\nВверх: Q\nВниз: E"
            + "\nУскорение (бег): Shift (левый)"
            + "\nАктивировать/деактивировать курсор: Ctrl (левый)"
            + "\nВзаимодействие с предметом-\n левая кнопка мыши."
            + "\nПриближение-\n колесо мыши."
            + "\nИнвентарь: I \nФонарь: L"
            + "\nЗахватить/отпустить лестницу: F "
            + "\nЗакрыть изображение: M "
            + "\nВыход из области тренажера: Esc "
            + "\n\n\nВысота: " + h.ToString());

    }
}
