using System.Collections.Generic;
using UnityEngine;

public class CorazonVida : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float curacion = 1;
    public static List<CorazonVida> listaCorazones = new List<CorazonVida>();

    private void Start()
    {

        listaCorazones.Add(this);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (this.tag == "corazon purpura")
            {
                collision.GetComponent<Vida>().addMaxHP();
            } else
                collision.GetComponent<Vida>().addHp(curacion);
            gameObject.SetActive(false);
        }

    }
    public float getCuracion() { return curacion; }
    public static List<CorazonVida> getCorazones() { return listaCorazones;}
}
