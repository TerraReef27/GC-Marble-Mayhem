using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform parent;
    ParticleSystem particles;

    public float maxPower = 2000f;
    [SerializeField] float chargeRate = 10f;
    [SerializeField] float decreaseRate = 1f;
    [Range(0f, 2000f)]
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        myRigidbody = GetComponent<Rigidbody>();
        parent = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithMouse();
        particles.transform.rotation = Quaternion.Euler(-90f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }

    private void MoveWithMouse()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Charge();
        }
        else
        {
            //TODO fix so not on update
            particles.Stop();
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

        if (!particles.isPlaying)
        {
            particles.Play();
        }
    }


}
