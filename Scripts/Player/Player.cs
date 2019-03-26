using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public delegate void OnCollisionEventHandler(string objectName);
    public static event OnCollisionEventHandler OnCollisionEvent;

    public Rigidbody MyBody;
    public float Speed;
    public float hSpeed;
    private Vector3 Movement;
    public float h = 2.0f;
    public bool isSitDown;
    public float hSitDown = 1.0f;
    public int stepUp = 16; // Высота прыжка через ступеньки

    // Use this for initialization
    void Start()
    {
        MyBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float _hSpeed = hSpeed;
        float _x = 5;
        float Right = Input.GetAxisRaw("Horizontal");
        float Forward = Input.GetAxisRaw("Vertical");

        Movement.Set(Forward, 0.0f, Right);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MyBody.AddForce(transform.forward * Forward * Speed*_x, ForceMode.Impulse);
            MyBody.AddForce(transform.right * Right * Speed*_x, ForceMode.Impulse);
            _hSpeed = _hSpeed*_x;
        }
        else
        {
            MyBody.AddForce(transform.forward * Forward * Speed, ForceMode.Impulse);
            MyBody.AddForce(transform.right * Right * Speed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Q)) { transform.position += transform.up * _hSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.E)) { transform.position -= transform.up * _hSpeed * Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isSitDown = !isSitDown;
            if(isSitDown)
            {
                transform.position -= transform.up * hSitDown*0.5f;
            }
            else
            {
                transform.position += transform.up * hSitDown * 0.5f;
            }

        }
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
        if (Input.GetKey(KeyCode.Q))
        {
            //MyBody.AddForce(transform.up * Speed, ForceMode.Impulse);
            //MyBody.transform.position += MyBody.transform.up * Speed * Time.deltaTime;
            MyBody.AddForce(0f, h, 0f, ForceMode.Impulse);

        }
        if (Input.GetKey(KeyCode.E))
        {
            //MyBody.AddForce(transform.up * Speed, ForceMode.Impulse);
            //MyBody.transform.position -= MyBody.transform.up * Speed * Time.deltaTime;
            MyBody.AddForce(0f, -h, 0f, ForceMode.Impulse);

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hazard" && OnCollisionEvent != null)
        {
            //Debug.Log("Опасность " + collision.gameObject.name);
            OnCollisionEvent(collision.gameObject.name);
        }

        if (collision.gameObject.tag == "Step" && Input.GetKey(KeyCode.W))
        {
            // Debug.Log("Ступенька " + collision.gameObject.name);
            MyBody.AddForce(transform.up * Speed * stepUp, ForceMode.Impulse);
        }
    }
}
