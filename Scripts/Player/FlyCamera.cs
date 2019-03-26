using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

[Serializable]
public class Question
{
    public string Quest;
    public bool isTrue;
    public Toggle toggle=null;

    public Question(string quest, bool IsTrue)
    {
        Quest = quest;
        isTrue = IsTrue;
    }
};

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

public class ViewPoint
{
    public float x;
    public float y;
    public float z;

    public ViewPoint()
    {
        x = 0;
        y = 0;
        z = 0;     
    }

}


//public class NewBehaviourScript : MonoBehaviour
//{

//    [DllImport("__Internal")]
//    private static extern void Hello();

//    [DllImport("__Internal")]
//    private static extern void HelloString(string str);

//    [DllImport("__Internal")]
//    private static extern void PrintFloatArray(float[] array, int size);

//    [DllImport("__Internal")]
//    private static extern int AddNumbers(int x, int y);

//    [DllImport("__Internal")]
//    private static extern string StringReturnValueFunction();

//    [DllImport("__Internal")]
//    private static extern void BindWebGLTexture(int texture);

//    void Start()
//    {
//        Hello();

//        HelloString("This is a string.");

//        float[] myArray = new float[10];
//        PrintFloatArray(myArray, myArray.Length);

//        int result = AddNumbers(5, 7);
//        Debug.Log(result);

//        Debug.Log(StringReturnValueFunction());

//        var texture = new Texture2D(0, 0, TextureFormat.ARGB32, false);
//        BindWebGLTexture(texture.GetNativeTextureID());


//        AddNumbers(5, 4);
//    }
//}

public class FlyCamera : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);


    [DllImport("__Internal")]
    private static extern void Calc2(int a);


    [DllImport("__Internal")]
    private static extern void TestFunction();

    public float cameraSensitivity = 90;
    public float climbSpeed = 4;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool SelectDefects = false;

    public GameObject Canvas;
    public GameObject Content;

    public Font Times;

    public GameObject Table1;
    public GameObject Table2;
    public GameObject Table3;
    public GameObject Table4;

    public GameObject PI4;
    public GameObject PI5;
    public GameObject PI6;

    public string a;


    public void ContinueView()
    {
        SelectDefects = false;
        Screen.lockCursor = true;
        //Canvas.gameObject.SetActive(false);
    }

    void Start()
    {
        Question[] Questions = new Question[4];
        //{
        //    new Question("Загрязнение корпуса трансформатора", false),
        //    new Question("Загрязнение корпуса трансформатора", false),
        //    new Question("Загрязнение корпуса трансформатора", false),
        //    new Question("Загрязнение корпуса трансформатора", false)
        //};
       // Application.ExternalCall("TestFunction");
        int sum = 555;// AddNumbers(2, 5);
        string testJson = "{\"Items\":[{\"Quest\":\"Загрязнение корпуса трансформатора"+ sum +"\",\"isTrue\":false},{\"Quest\":\"Отсутствие на кабелях маркировочных бирок\",\"isTrue\":false},{\"Quest\":\"Отсутствие площадки обслужвания перед КТП\",\"isTrue\":false},{\"Quest\":\"Отсутствие уплотнителей дверей КТП\",\"isTrue\":false}]}";

        Questions = JsonHelper.FromJson<Question>(testJson);

        a = "3213";

        Screen.lockCursor = true;
        //Canvas.gameObject.SetActive(false);

        float lastPosX = 0f;
        float lastPosY = -50f;

        int countToggle = Questions.Length;

        //Toggle []Toggles = new Toggle[countToggle];

        for (int i = 0; i < countToggle; i++)
        {
            //if (i == counttoggle / 2)
            //{
            //    lastPosX = 225;
            //    lastPosY = -50;
            //}

            DefaultControls.Resources uiResources = new DefaultControls.Resources();
            GameObject temptoggle = DefaultControls.CreateToggle(uiResources);
            temptoggle.transform.SetParent(Content.transform, false);
            temptoggle.AddComponent<Image>();
            Toggle temptoggle1 = temptoggle.GetComponent<Toggle>();
            Questions[i].toggle = temptoggle1;
            temptoggle1.isOn = false;
            temptoggle1.onValueChanged.AddListener(delegate { ChangeToggle(temptoggle1); });
            temptoggle.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 50);
            Destroy(temptoggle.transform.GetChild(0).gameObject);
            temptoggle.transform.GetChild(1).gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            temptoggle.transform.GetChild(1).gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().font = Times;
            temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().fontSize = 18;
            temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().text = Questions[i].Quest;
            temptoggle.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1f);
            temptoggle.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
            temptoggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(lastPosX, lastPosY);
            lastPosY -= 60;
            //Questions[i].toggle;
        }

        float contentsize = 536;
        if (countToggle > 8) contentsize = 536 + (countToggle - 8) * 60;

        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, contentsize);

        
    }


 

    public void ChangeToggle(Toggle Toggle)
    {
        if (Toggle.isOn) Toggle.GetComponent<Image>().color = new Color(0.68f, 0.97f, 0.65f);
        else Toggle.GetComponent<Image>().color = Color.white;
    }

    void Update()
    {
        
        if (!SelectDefects)
        {
            rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.P))
            {
                Question[] Questions = new Question[4];
                string text = transform.position.ToString();
                string testJson = "{\"Items\":[" +
                    "{\"Quest\":\"" + text + "\",\"isTrue\":false}," +
                    "{\"Quest\":\"" + a + "\",\"isTrue\":false}," +
                    "{\"Quest\":\"1232131\",\"isTrue\":false}," +
                    "{\"Quest\":\"1 1 1 1\",\"isTrue\":false}]}";

                Questions = JsonHelper.FromJson<Question>(testJson);

                Screen.lockCursor = true;
                //Canvas.gameObject.SetActive(false);

                float lastPosX = 0f;
                float lastPosY = -50f;

                int countToggle = Questions.Length;

                //Toggle []Toggles = new Toggle[countToggle];

                for (int i = 0; i < countToggle; i++)
                {
                    //if (i == counttoggle / 2)
                    //{
                    //    lastPosX = 225;
                    //    lastPosY = -50;
                    //}

                    DefaultControls.Resources uiResources = new DefaultControls.Resources();
                    GameObject temptoggle = DefaultControls.CreateToggle(uiResources);
                    temptoggle.transform.SetParent(Content.transform, false);
                    temptoggle.AddComponent<Image>();
                    Toggle temptoggle1 = temptoggle.GetComponent<Toggle>();
                    Questions[i].toggle = temptoggle1;
                    temptoggle1.isOn = false;
                    temptoggle1.onValueChanged.AddListener(delegate { ChangeToggle(temptoggle1); });
                    temptoggle.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 50);
                    Destroy(temptoggle.transform.GetChild(0).gameObject);
                    temptoggle.transform.GetChild(1).gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                    temptoggle.transform.GetChild(1).gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                    temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                    temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().font = Times;
                    temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().fontSize = 18;
                    temptoggle.transform.GetChild(1).gameObject.GetComponent<Text>().text = Questions[i].Quest;
                    temptoggle.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1f);
                    temptoggle.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
                    temptoggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(lastPosX, lastPosY);
                    lastPosY -= 60;
                    //Questions[i].toggle;
                }

                float contentsize = 536;
                if (countToggle > 8) contentsize = 536 + (countToggle - 8) * 60;

                Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, contentsize);

            }
           // if(Input.GetKey(KeyCode.Mouse0) { }
            if (Input.GetKey(KeyCode.Q)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
            if (Input.GetKey(KeyCode.E)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }

            if (Input.GetKeyDown(KeyCode.End))
            {
                Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F11))
        {
            SelectDefects = true;
            //Canvas.gameObject.SetActive(true);
            Screen.lockCursor = false;
        }
    }
}
