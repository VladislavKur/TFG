using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float health;
    public float maxHealth;
    public float[] checkpoint;
    public float[] position;

    public PlayerData(PlayerMov player)
    {   
        //Vida Player
        health = player.GetComponent<Vida>().VidaActual;
        maxHealth = player.GetComponent<Vida>().maxHealth;

        //checkpoint 
        checkpoint = new float[3];
        checkpoint[0] = player.checkpoint.x;
        checkpoint[1] = player.checkpoint.y;
        checkpoint[2] = player.checkpoint.z; 


        // ultima posicion  Player
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}