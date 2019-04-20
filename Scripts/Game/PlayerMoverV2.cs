using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverV2 : MovableMarble
{
    Rigidbody myRidgidbody;

    void Start()
    {
        myRidgidbody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = marbleData.material;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Charge(myRidgidbody);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 moveDirection = hit.point - transform.position;
                Boost(myRidgidbody, moveDirection);
                Debug.DrawLine(transform.position, hit.point);
            }
        }
    }
}
