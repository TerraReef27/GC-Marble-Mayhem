using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform parentTranform;
    //ParticleSystem particles;

    [SerializeField] float maxPower = 2000f;

    [Range(0f, 10000f)]
    [SerializeField] float power = 0f;
    [SerializeField] float increaseRate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        parentTranform = GetComponentInParent<Transform>();
        //particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();    
    }

    private void Shoot()
    {
       if(Input.GetKey(KeyCode.Mouse0))
       {
            Charge();
       }
       if (Input.GetKeyUp(KeyCode.Mouse0))
       {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                print(transform.rotation);
                print("hit");

                Vector3 moveDirection = hit.point - transform.position;
                moveDirection.y = 0;
                print(moveDirection);

                moveDirection.Normalize();

                Debug.DrawLine(transform.position, hit.point);

                myRigidbody.AddForceAtPosition(moveDirection * power * Time.deltaTime, parentTranform.position);
                power = 0f;
                //transform.Translate(moveDirection * Time.deltaTime * speed, Space.World);
            }
       }
    }

    private void Charge()
    {
        if (power < maxPower)
        {
            power += Time.deltaTime * increaseRate;
        }
        /*
        if (!particles.isPlaying)
        {
            particles.Play();
        }

        else
        {
            particles.Stop();
        }
        */
    }
}
