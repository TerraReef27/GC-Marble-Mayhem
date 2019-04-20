using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CPUMover : MovableMarble
{
    Rigidbody myRidgidbody;
    GameObject player;

    void Start()
    {
        myRidgidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("attackPlayer", Random.Range(1f, 3f), Random.Range(1f, 3f));
    }

    private void attackPlayer()
    {
        if (player != null)
        {
            print("attacking player");

            //TODO work with data
            power = Random.Range(300f, 1000f);

            myRidgidbody.velocity = Vector3.zero;

            Vector3 playerDirection = player.transform.position - transform.position;

            Boost(myRidgidbody, playerDirection);
            Debug.DrawLine(transform.position, player.transform.position);
        }
        else
        {
            //TODO look for another player
            CancelInvoke();
        }
    }
}
