using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Killer")
        {
            Destroy(player);
        }
    }
}
