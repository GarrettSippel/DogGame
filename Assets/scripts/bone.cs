using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bone : MonoBehaviour {
    Vector3 target;
    
	// Use this for initialization
	void Start () {
        target = transform.position;


    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("Player") == true)
        {
            print("this is a player");

            Vector3 replace = new Vector3(transform.position.x, transform.position.y, 0f);
            replace.x = replace.x + 100f;
            replace.y = replace.y + 100f;
            transform.position = replace;
            print("I'm eating here");
        }
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            
            transform.position = target;

        }



        
	}
}
