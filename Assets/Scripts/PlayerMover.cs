using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform parent;

    public float maxPower = 2000f;
    [SerializeField] float chargeRate = 10f;
    [SerializeField] float decreaseRate = 1f;
    [Range(0f, 2000f)]
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        parent = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithButtons();
        MoveWithMouse();
    }

    private void MoveWithMouse()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Charge();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            myRigidbody.angularDrag = 0.05f;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 moveDirection = hit.point - transform.position;
                moveDirection.y = 0;
                moveDirection.Normalize();

                //TODO remove later
                Debug.DrawLine(transform.position, hit.point);

                myRigidbody.AddForceAtPosition(moveDirection * power, parent.position);
                power = 0;
            }
        }
    }

    private void Charge()
    {
        if(power < maxPower)
        {
            power +=  chargeRate;
        }

        myRigidbody.angularDrag += decreaseRate;
    }

    private void MoveWithButtons()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            myRigidbody.AddForceAtPosition(Vector3.right * Input.GetAxis("Horizontal") * power, parent.position);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            myRigidbody.AddForceAtPosition(Vector3.forward * Input.GetAxis("Vertical") * power, parent.position);
        }
    }
}
