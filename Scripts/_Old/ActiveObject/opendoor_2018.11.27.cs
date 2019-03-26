using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor2018_11_27 : MonoBehaviour {


   // public GameObject Lamp1;
    public float smooth = 2.0f;
    public float angleOpened = 90.0f;
   // public float angleClosed = 90.0f;
    public bool open = false;

    public bool isActive = false;
    public static GameObject gameObjectForOpen = null;

        

    private Vector3 defaultRot;
    private Vector3 openRot;

  

    // public GameObject[] doorAll;


    // Use this for initialization
    void Start () {
        gameObjectForOpen = gameObject;
        defaultRot = gameObjectForOpen.transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + angleOpened, defaultRot.z);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F) && isActive)
        {
           
            // print(gameObjectForOpen.transform.rotation);
            if (!open)
            {
                // print(Using1.gameObjectForShader.transform.rotation);
                //Open door
                //Using1.gameObjectForShader.transform.eulerAngles = Vector3.Slerp(Using1.gameObjectForShader.transform.eulerAngles, openRot, Time.deltaTime * smooth);
                //Vector3 openDoors = new Vector3(Using1.gameObjectForShader.transform.rotation.x, Using1.gameObjectForShader.transform.rotation.y, Using1.gameObjectForShader.transform.rotation.z + DoorOpenAngle);
                //Quaternion quaternion = new Quaternion(0,
                //                                       gameObjectForOpen.transform.rotation.y,
                //                                       0,// + DoorOpenAngle,
                //                                      90);// gameObjectForOpen.transform.rotation.w);
                //print(gameObject.name + ": !open: quat " + quaternion);
                //gameObjectForOpen.transform.rotation = quaternion;
                // print(gameObjectForOpen.transform.rotation);

                // gameObjectForOpen.transform.rotation.SetEulerAngles(0f, 54, 0f);
                gameObjectForOpen.transform.rotation *= Quaternion.Euler(0f, angleOpened, 0f);

                print(gameObject.name + ": !open: " );
            }
            else
            {

                //Close door
                //Using1.gameObjectForShader.transform.eulerAngles = Vector3.Slerp(Using1.gameObjectForShader.transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
                //Vector3 openDoors = new Vector3(Using1.gameObjectForShader.transform.rotation.x, Using1.gameObjectForShader.transform.rotation.y, Using1.gameObjectForShader.transform.rotation.z - DoorOpenAngle);
                //Quaternion quaternion = new Quaternion(0,
                //                                       1,
                //                                       0,// - DoorOpenAngle,
                //                                       -90);// -gameObjectForOpen.transform.rotation.w);
                print(gameObject.name + ": open: "); //quat " + quaternion);
                //gameObjectForOpen.transform.rotation = quaternion;
                gameObjectForOpen.transform.rotation *= Quaternion.Euler(0f, -angleOpened, 0f);
                // print(gameObjectForOpen.transform.rotation);
            }
            open = !open;
            isActive = false;
        }


        //if (Input.GetKeyDown(KeyCode.F) && enter)
        //{
        //  
        //    open = !open;
        //    // doorAll = GameObject.FindGameObjectsWithTag("Door");
        //    // foreach (GameObject door in doorAll)
        //    // {
        //    //     //door.GetComponent<Animation>().Play("OpenDoor");
        //    //     //door.GetComponent<MeshRenderer>().enabled = false;
        //    //     door.transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        //    //
        //    // }
        //    //Lamp1.SetActive(!Lamp1.activeSelf);
        //    //Lamp1.active = !Lamp1.active;
        //}
        //if (Input.GetKeyDown("f") && enter)
        //{
        //    // open = !open;
        //    if (open)
        //    {
        //        //Open door
        //        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        //    }
        //    else
        //    {
        //        //Close door
        //        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        //    }
        //    //Debug.Log(gameObject.GetComponent<Renderer>().materials);
        //
        //    //
        //}



    }

    ////Activate the Main function when player is near the door
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        enter = true;
    //    }
    //}
    //
    ////Deactivate the Main function when player is go away from door
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        enter = false;
    //    }
    //}

    void OnGUI()
    {
        if (isActive)
        {

            if(gameObjectForOpen != null) GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 200, 200, 30), gameObjectForOpen.name);
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 180, 200, 30), open.ToString());

            if (open)
            {
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 300, 30), "Нажмите 'F', чтобы закрыть дверь");
                // GUI.Label(new Rect(500, 200, 350, 100), System.Math.Round(Using1.gameObjectForShader.transform.eulerAngles.x, 3).ToString() + "\n" + System.Math.Round(transform.eulerAngles.x, 3).ToString());

                //GUI.Label(new Rect(500, 200, 350, 100), System.Math.Round(Using1.gameObjectForShader.transform.eulerAngles.x, 3).ToString() + "\n" + System.Math.Round(transform.eulerAngles.x, 3).ToString());
            }
            else
            {
               GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 70, 300, 30), "Нажмите 'F', чтобы открыть дверь");                              
            }
            
        }
    }

    GameObject GetRootRotateObject(GameObject gameObject, int maxLevelParent, string namePrefixRootRotateObject = "Door")
    {
        if (gameObject.name.Substring(0, 4) == namePrefixRootRotateObject)
        {
            return gameObject;
        }
        else
        {
            if (maxLevelParent == 0)
            {
                Debug.Log(" gameObject is NULL");
                return null;
            }
            if (gameObject.transform == null)
            {
                Debug.Log(" gameObject.transform is NULL");
                return null;
            }
            if (gameObject.transform.parent == null)
            {
                Debug.Log(" gameObject.transform.parent is NULL");
                return null;
            }
            if (gameObject.transform.parent.gameObject == null)
            {
                Debug.Log(" gameObject.transform.parent.gameObject is NULL");
                return null;
            }

            Debug.Log(string.Format(" No root element '{0}' for GivenLevelRoot", namePrefixRootRotateObject));
            return GetRootRotateObject(gameObject.transform.parent.gameObject, -1, namePrefixRootRotateObject);
            
        }
            
    }

}
