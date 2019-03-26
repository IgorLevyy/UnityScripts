using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LadderController : MonoBehaviour
{

    private Rigidbody MyBody;
    public BoxCollider LadderCollider;
    public float Speed = 1.0f;
    private Vector3 Movement;
    private float h = 10.0f;

    // Use this for initialization
    void Start()
    {
        MyBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //float Right = Input.GetAxisRaw("Horizontal");
        //float Forward = Input.GetAxisRaw("Vertical");

        //Movement.Set(Forward, 0.0f, Right);

        //MyBody.AddForce(transform.forward * Forward * Speed, ForceMode.Impulse);

        //MyBody.AddForce(transform.right * Right * Speed, ForceMode.Impulse);

        //MyBody.AddForce(transform.up * Speed, ForceMode.Impulse);
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    //float Forward = Input.GetAxisRaw("Vertical");
        //    // float Right = Input.GetAxisRaw("Horizontal");
        //    //float Forward = Input.GetAxisRaw("Vertical");

        //    //MyBody.AddForce(transform.up * Speed, ForceMode.Impulse);
        //    //MyBody.transform.position += MyBody.transform.up * Speed * Time.deltaTime;
        //    //Movement.Set(Forward, 0.0f, Right);
        //    MyBody.AddForce(0f, 300f, 0f, ForceMode.Impulse);
        //}
        if (Input.GetKey(KeyCode.W))
        {
            //MyBody.AddForce(transform.up * Speed, ForceMode.Impulse);
            //MyBody.transform.position += MyBody.transform.up * Speed * Time.deltaTime;
            Vector3 vector = LadderCollider.transform.up;
        //    MyBody.AddForce(h * vector.x * Speed, h * vector.y * Speed, h * vector.z * Speed, ForceMode.Impulse);
            MyBody.AddForce(h * vector.x * Speed,0, 0, ForceMode.Impulse);
            MyBody.AddForce(0, h * vector.y * Speed, 0, ForceMode.Impulse);
            MyBody.AddForce(0, 0, h * vector.z * Speed, ForceMode.Impulse);
            MyBody.useGravity = false;

        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    Vector3 vector3Position = new Vector3(gameObject.transform.position.x,
        //                                                gameObject.transform.position.y,
        //                                                gameObject.transform.position.z);
        //    //MyBody.AddForce(transform.up * Speed, ForceMode.Impulse);
        //    //MyBody.transform.position -= MyBody.transform.up * Speed * Time.deltaTime;
        //    Vector3 vector = LadderCollider.transform.up;
        //  //  MyBody.AddForce(-h * vector.x * Speed, -h * vector.y * Speed, -h * vector.z * Speed, ForceMode.Impulse);
        //    MyBody.AddForce(-h * vector.x * Speed, 0, 0, ForceMode.Impulse);
        //   // MyBody.AddForce(0, -h * vector.y * Speed, 0, ForceMode.Impulse);
        //    MyBody.AddForce(0, 0, -h * vector.z * Speed, ForceMode.Impulse);

        //    if (gameObject.transform.position == vector3Position)
        //    {
        //        MyBody.AddForce(-h * vector.x * Speed*5, 0, 0, ForceMode.Impulse);
        //        //MyBody.AddForce(0, -h * vector.y * Speed * 5, 0, ForceMode.Impulse);
        //        MyBody.AddForce(0, 0, -h * vector.z * Speed * 5, ForceMode.Impulse);

        //        //MyBody.transform.position = new Vector3(vector3Position.x-h * vector.x,
        //        //                                        vector3Position.y - h * vector.y,
        //        //                                        vector3Position.z - h * vector.z);

        //    }
        //    MyBody.useGravity = true;

        //}
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 vector = LadderCollider.transform.up;
            //    MyBody.AddForce(h * vector.x * Speed, h * vector.y * Speed, h * vector.z * Speed, ForceMode.Impulse);
            MyBody.AddForce(- h * vector.x * Speed, 0, 0, ForceMode.Impulse);
            MyBody.AddForce(0, - h * vector.y * Speed, 0, ForceMode.Impulse);
            MyBody.AddForce(0, 0, - h * vector.z * Speed, ForceMode.Impulse);
            MyBody.useGravity = false;

        }

    }
}
