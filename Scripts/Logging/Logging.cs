using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogElement
{
    public DateTime dataTime;
    public string name;
    public string objName;
    public string timeExecution;
}

public class Logging : MonoBehaviour
{
    public List<LogElement> logs = new List<LogElement>();
    //public static bool show = false;
    public Font font;
    Vector2 scrollPosition = Vector2.zero;

    void Start()
    {
        var logStart = new LogElement
        {
            dataTime = DateTime.Now,
            name = "Start logging",
            objName = "Logging"
        };
        logs.Add(logStart);
        //show = true;
    }

    void Update()
    {

    }


    void OnGUI()
    {
        GUI.skin.font = font;// Resources.GetBuiltinResource(typeof(Font), "Times.ttf") as Font;
        GUI.Window(10, new Rect(Screen.width-230, Screen.height - 230, 230, 100), RenderLogs, "Действия");
    }

    void RenderLogs(int id)
    {
        GUI.skin.font = font;
        scrollPosition = GUILayout.BeginScrollView(
           scrollPosition, GUILayout.Width(220), GUILayout.Height(80));

        for (int i = 0; i < logs.Count; i++)
        {
            if (logs[i] != null)
            {
                GUILayout.Label(logs[i].dataTime.ToString() + " - " + logs[i].name + " - " + logs[i].objName);
            }
            else
            {
                GUILayout.Box("", GUILayout.Width(100f), GUILayout.Height(100f));
            }

        }

        GUILayout.EndScrollView();
    }

}
