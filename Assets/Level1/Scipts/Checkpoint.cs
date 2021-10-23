using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 checkpoint;

    private void Awake()
    {
        checkpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerMov>().setCheckpoint(checkpoint);
            collision.GetComponent<PlayerMov>().SavePlayer();
        }
    }
}
