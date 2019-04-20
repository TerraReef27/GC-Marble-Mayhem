using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMarble : MonoBehaviour
{
    public Marble marbleData;

    [Range(0f, 2000f)]
    public float power;

    public void Boost(Rigidbody myRigidbody, Vector3 moveDirection)
    {
        myRigidbody.angularDrag = 0.05f;

        moveDirection.y = 0;
        moveDirection.Normalize();

        //myRigidbody.AddForceAtPosition(moveDirection * power, transform.position);
        myRigidbody.AddForce(moveDirection * power);
        power = 0;
    }

    public void Charge(Rigidbody myRigidbody)
    {
        if (power < marbleData.maxPower)
        {
            power += marbleData.chargeRate;
        }

        //myRigidbody.angularDrag += marbleData.decreaseRate;
    }

    public void updateMaterial()
    {
        GetComponent<Renderer>().material = marbleData.material;
    }
}
