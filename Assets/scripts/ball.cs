using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    Vector3 target;
    Vector3 prevTarget;
    public Rigidbody rb;
    
    Vector3[] lastFive;
    int fiveC = 0;
	// Use this for initialization
	void Start () {
        target = transform.position;
        prevTarget = transform.position;
        rb = GetComponent<Rigidbody>();
        lastFive = new Vector3[5];

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            prevTarget = target;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            transform.position = target;
            if (fiveC >= 5)
            {
                fiveC = 0;
                lastFive[fiveC] = target-prevTarget;
            }
            else
            {
                lastFive[fiveC] = target-prevTarget;
                fiveC++;
            }
                
        }
        if (Input.GetMouseButtonUp(0))
        {

            //rb.AddForce((target - prevTarget)*1500);

            rb.velocity= (calThrow(lastFive)) * 50;
            print(target);
            print(prevTarget);
            print(prevTarget-target);
        }

    }

    Vector3 calThrow(Vector3[] array)
    {
        Vector3 reVec = new Vector3(0,0,0);
        for(int x=0; x<5; x++)
        {
            reVec = reVec + array[x];
        }
        reVec.x = reVec.x / 5;
        reVec.y = reVec.y / 5;
        reVec.z = 0;
        if (reVec.x > 50)
        {
            reVec.x = 50;
        }
        if (reVec.y > 50)
        {
            reVec.y = 50;
        }
        if (reVec.x < -50)
        {
            reVec.x = -50;
        }
        if (reVec.y < -50)
        {
            reVec.y = -50;
        }

        return reVec;
    }
}
