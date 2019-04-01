using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public DialogueNode[] node;
    public int _currentNode;
    public bool ShowDialogue = false;
    public int currentDialogue = 0;
    private float zom;
    public GUISkin skin;
    public Font font;

    void Start()
    {
        GUI.skin.font = font;
    }
    private void Update()
    {
        zom = Input.GetAxis("Mouse ScrollWheel");

        if (zom < 0)
        {
            //print(currentButton);
            if (currentDialogue < node[_currentNode].PlayerAnswer.Length - 1)
            {
                currentDialogue++;
            }
            // currItem = items[currentButton];
        }

        if (zom > 0)
        {
            //print(currentButton);
            if (currentDialogue > 0)
            {
                currentDialogue--;
            }
            //currItem = items[currentButton];
        }

        if (Input.GetMouseButtonDown(0) && ShowDialogue)
        {
            var i = currentDialogue;
            if (node[_currentNode].PlayerAnswer[i].SpeakEnd)
            {

                InitSceneScript initSceneScript = GameObject.Find("Player").GetComponent<InitSceneScript>();
                initSceneScript._eventListener.SendMessageToSR(node[_currentNode].PlayerAnswer[i].ElementRef, node[_currentNode].PlayerAnswer[i].ActionRef, node[_currentNode].PlayerAnswer[i].InventoryItemRef);

                ShowDialogue = false;


                MouseLook scriptMouseLook = GameObject.Find("Player").GetComponent<MouseLook>();
                Zoom scriptZoom = GameObject.Find("Player").GetComponent<Zoom>();


                scriptMouseLook.enabled = true;
                scriptZoom.enabled = true;
            }
            _currentNode = node[_currentNode].PlayerAnswer[i].ToNode;
        }
    }
    void OnGUI()
    {
        GUI.skin.font = font;
        Color color = GUI.backgroundColor;
        GUI.skin = skin;
        if (ShowDialogue == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 600, Screen.height - 500, 1200, 450), "");
            GUI.Label(new Rect(Screen.width / 2 - 550, Screen.height - 480, 1125, 150), node[_currentNode].NpcText);

            for (int i = 0; i < node[_currentNode].PlayerAnswer.Length; i++)
            {
                if (i != currentDialogue)
                {
                    if (GUI.Button(new Rect(Screen.width / 2 - 550, Screen.height - 400 + 50 * i, 1125, 50), node[_currentNode].PlayerAnswer[i].Text))
                    {
                        if (node[_currentNode].PlayerAnswer[i].SpeakEnd)
                        {

                            InitSceneScript initSceneScript = GameObject.Find("Player").GetComponent<InitSceneScript>();
                            initSceneScript._eventListener.SendMessageToSR(node[_currentNode].PlayerAnswer[i].ElementRef, node[_currentNode].PlayerAnswer[i].ActionRef, node[_currentNode].PlayerAnswer[i].InventoryItemRef);

                            ShowDialogue = false;
                        }
                        _currentNode = node[_currentNode].PlayerAnswer[i].ToNode;
                    }
                } else
                {
                    GUI.backgroundColor = Color.green;

                    if (GUI.Button(new Rect(Screen.width / 2 - 550, Screen.height - 400 + 50 * i, 1125, 50), node[_currentNode].PlayerAnswer[i].Text))
                    {
                        if (node[_currentNode].PlayerAnswer[i].SpeakEnd)
                        {

                            InitSceneScript initSceneScript = GameObject.Find("Player").GetComponent<InitSceneScript>();
                            initSceneScript._eventListener.SendMessageToSR(node[_currentNode].PlayerAnswer[i].ElementRef, node[_currentNode].PlayerAnswer[i].ActionRef, node[_currentNode].PlayerAnswer[i].InventoryItemRef);

                            ShowDialogue = false;
                        }
                        _currentNode = node[_currentNode].PlayerAnswer[i].ToNode;

                    }

                    GUI.backgroundColor = color;
                }
            }
        }
    }
}

[System.Serializable]
public class DialogueNode
{
    public string NpcText;
    public Answer[] PlayerAnswer;
}


[System.Serializable]
public class Answer
{
    public string Text;
    public int ToNode;
    public bool SpeakEnd;
    public string ActionRef;
    public string ElementRef;
    public string InventoryItemRef;
}
