using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
//[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public void PlakatClick()
    {
        moveCamera = true;
        Cursor.lockState = CursorLockMode.Locked;
        Plakat2Door.gameObject.SetActive(true);

        //Plakat1.gameObject.SetActive(false);
        //Plakat2.gameObject.SetActive(false);
        //Plakat3.gameObject.SetActive(false);
    }
    // CursorLockMode wantedMode;

    [DllImport("__Internal")]
    private static extern void TestFunction();

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;



    public GameObject CameraY;
    public Animator DoorAnim;
    public Animator DoorAnim1;
    public GameObject Hand;
    public GameObject Plakat1;
    public GameObject Plakat2;
    public GameObject Plakat3;

    public GameObject Plakat2Door;
    public UnityEngine.UI.Text TextField;

    private bool DoorOpened = false;
    private bool SecondUpDoorOpened = false;
    private bool SecondDownDoorOpened = false;
    private bool lever1Up = true;
    private bool lever2Up = true;
    private bool lever3Up = true;
    private bool HandActivate = false;
    private bool selectPlakat = false;


    float rotationY = 0F;

    private bool moveCamera = true;

    void Update()
    {
        if (moveCamera)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(0, rotationX, 0);
                CameraY.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    //Cursor.visible = false;
        //    moveCamera = true;
        //}

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    moveCamera = false;

        //}

        ////RaycastHit hit_1;
        ////Ray _ray;
        ////_ray = Camera.allCameras[0].ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));//ScreenPointToRay(Input.mousePosition);
        ////if (Physics.Raycast(_ray, out hit_1))
        ////{
        ////    //Debug.Log(hit_1.collider.tag);
        ////    if (hit_1.distance <= 1f)
        ////    {
        ////        if (hit_1.collider.tag == "bottomDoor") // Проверяем то ,что вернулось
        ////        {
        ////            HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                //Debug.Log(DoorOpened);
        ////                if (!DoorOpened)
        ////                {
        ////                    DoorAnim.Play("bottomDoorOpen");
        ////                    DoorOpened = true;
        ////                    //Lamp.color = Color.green;
        ////                }
        ////                else
        ////                {
        ////                    DoorAnim.Play("bottomDoorClose");
        ////                    DoorOpened = false;
        ////                    //Lamp.color = Color.red;
        ////                }

        ////                //Application.ExternalEval("alert('button');");
        ////                //Application.ExternalCall("TestFunction");
        ////                //TestFunction();

        ////            }

        ////        }

        ////        else if (hit_1.collider.tag == "lever1") // Проверяем то ,что вернулось
        ////        {
        ////            HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                if (lever1Up)
        ////                {
        ////                    DoorAnim.Play("lever1Down");
        ////                    lever1Up = false;
        ////                }
        ////                else
        ////                {
        ////                    DoorAnim.Play("lever1Up");
        ////                    lever1Up = true;
        ////                }
        ////            }
        ////        }

        ////        else if (hit_1.collider.tag == "lever2") // Проверяем то ,что вернулось
        ////        {
        ////            HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                if (lever2Up)
        ////                {
        ////                    DoorAnim.Play("lever2Down");
        ////                    lever2Up = false;
        ////                }
        ////                else
        ////                {
        ////                    DoorAnim.Play("lever2Up");
        ////                    lever2Up = true;
        ////                }
        ////            }
        ////        }

        ////        else if (hit_1.collider.tag == "lever3") // Проверяем то ,что вернулось
        ////        {
        ////            HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                if (lever3Up)
        ////                {
        ////                    DoorAnim.Play("lever3Down");
        ////                    lever3Up = false;
        ////                }
        ////                else
        ////                {
        ////                    DoorAnim.Play("lever3Up");
        ////                    lever3Up = true;
        ////                }
        ////            }
        ////        }

        ////        else if (hit_1.collider.tag == "Plakat")
        ////        {
        ////            //HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                Cursor.lockState = CursorLockMode.None;
        ////                moveCamera = false;
        ////                selectPlakat = true;
        ////                Plakat1.gameObject.SetActive(true);
        ////                Plakat2.gameObject.SetActive(true);
        ////                Plakat3.gameObject.SetActive(true);
        ////            }
        ////            TextField.gameObject.SetActive(true);
        ////            TextField.text = "Повесить плакат";
        ////        }

        ////        else if (hit_1.collider.tag == "Door")
        ////        {
        ////            //HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                if (!DoorOpened)
        ////                {
        ////                    DoorAnim1.Play("OpenDoor");
        ////                    Debug.Log("Open");
        ////                    DoorOpened = true;
        ////                }
        ////                else
        ////                {
        ////                    DoorAnim1.Play("CloseDoor");
        ////                    Debug.Log("Close");
        ////                    DoorOpened = false;
        ////                }
        ////            }
        ////        }

        ////        else if (hit_1.collider.tag == "SecondUpDoor")
        ////        {
        ////            //HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                if (!SecondUpDoorOpened)
        ////                {
        ////                    DoorAnim1.Play("OpenSecondUpDoor");
        ////                    SecondUpDoorOpened = true;

        ////                }
        ////                else
        ////                {
        ////                    DoorAnim1.Play("CloseSecondUpDoor");
        ////                    SecondUpDoorOpened = false;
        ////                }
        ////            }
        ////        }

        ////        else if (hit_1.collider.tag == "SecondDownDoor")
        ////        {
        ////            //HandActivate = true;
        ////            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        ////            {
        ////                if (!SecondDownDoorOpened)
        ////                {
        ////                    DoorAnim1.Play("OpenSecondDownDoor");
        ////                    SecondDownDoorOpened = true;

        ////                }
        ////                else
        ////                {
        ////                    DoorAnim1.Play("CloseSecondDownDoor");
        ////                    SecondDownDoorOpened = false;
        ////                }
        ////            }
        ////        }

        ////        //else if (hit_1.collider.name == "Plakat2" && selectPlakat)
        ////        //{
        ////        //    if (Input.GetMouseButtonDown(0))
        ////        //    {
        ////        //        selectPlakat = false;

        ////        //    }
        ////        //}

        ////        //else
        ////        //{
        ////        //    Debug.Log(hit_1.collider.name);
        ////        //}


        ////    }
        ////    else
        ////    {
        ////        //HandActivate = false;
        ////        TextField.gameObject.SetActive(false);
        ////    }
        ////}

        //if (HandActivate)
        //{
        //    Hand.gameObject.SetActive(true);
        //    HandActivate = false;
        //}
        //else
        //{
        //    Hand.gameObject.SetActive(false);
        //}

    }

    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;

        //Hand.gameObject.SetActive(false);
      //  TextField.gameObject.SetActive(false);

        //Plakat1.gameObject.SetActive(false);
        //Plakat2.gameObject.SetActive(false);
        //Plakat3.gameObject.SetActive(false);
      //  Plakat2Door.gameObject.SetActive(false);
    }

 
}