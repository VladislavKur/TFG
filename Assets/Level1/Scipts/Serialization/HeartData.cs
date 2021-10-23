using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeartData
{
    public float[,] posicion;
    public float[] curacion;
    public float heartLength= 0;
    public bool[] isActive;
   public HeartData(List<CorazonVida> corazon)
   {
        if(corazon != null)
        {
            posicion = new float[corazon.Count, 3];
            curacion = new float[corazon.Count];
            isActive = new bool[corazon.Count];
            for (int i = 0; i < corazon.Count; ++i)
            {

                posicion[i, 0] = corazon[i].transform.position.x;
                posicion[i, 1] = corazon[i].transform.position.y;
                posicion[i, 2] = corazon[i].transform.position.z;

                curacion[i] = corazon[i].getCuracion();
                isActive[i] = corazon[i].isActiveAndEnabled;
                heartLength++;
            }

        }


    }
}
