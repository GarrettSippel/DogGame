using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playablecharacter : MonoBehaviour {
    public int hungers = 100;
    public Rigidbody rb;
    public float speed = 200f;
    public float rotateSpeed = 5f;
    float rotateInput = 0.0f;
    
    float xMov = 0;
    float yMov = 0;
    Vector3 nose;

   // Vector3 mp;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Vector3 nose = new Vector3(0.0f, 0.0f, 0.0f);
}
    void FixedUpdate ()
    {
        print("Hunger: " + hunger);
        nose = rb.transform.rotation.eulerAngles;
        
        xMov = -(Mathf.Sin((Mathf.PI) * ((nose.z)) / 180));
        yMov = Mathf.Cos((Mathf.PI)*((nose.z)) /180);

        rotateInput = rotateInput + ((Input.GetAxis("Horizontal") * rotateSpeed));
        Quaternion rotate = Quaternion.Euler(0.0f,0.0f, rotateInput);
        float moveForward = Input.GetAxis("Vertical")*speed;
        Vector3 movement = new Vector3(xMov*moveForward, yMov*moveForward, 0.0f);
        rb.velocity = movement;
        rb.MoveRotation(rotate);




       // mp = Input.mousePosition;
       // print(mp);


    }
}
