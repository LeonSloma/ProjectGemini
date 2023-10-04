using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    void OnTriggerEnter2D( Collider2D col )
    {
        if(col.tag == "Player")
        {
            col.GetComponentInParent<PlayerController>().die();
        }
    }
}
