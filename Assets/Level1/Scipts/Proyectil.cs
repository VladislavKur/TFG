
using UnityEngine;
using System.Collections.Generic;

public class Proyectil : MonoBehaviour
{

    [SerializeField] private float speed = 4;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private bool hit;
    private float direction = 1;
    private float lifeTime;

    private List<string> filtroTAGcollision = new List<string> {"invisDoor","corazon", "corazon purpura", "Checkpoint", "Player"};

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        if (hit) return;

        float time = 2;
        lifeTime += Time.deltaTime;
        if(lifeTime >= time)
        {
            anim.SetTrigger("BolaExplosion");
            transform.Translate(0, 0, 0);
            if (lifeTime >= time+0.26) Deactivate();
        }else
        {
            float movespeed = speed * Time.deltaTime * direction;
            transform.Translate(movespeed, 0, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool ignorar = false;
        foreach (string names in filtroTAGcollision)
        {
           
            if (collision.tag == names)
            {
                ignorar = true;
                break;
            }
          
        }
        if (!ignorar)
        {
            hit = true;
            boxCollider.enabled = false;
            anim.SetTrigger("BolaExplosion");
        }


    }

    public void SetDirection(float dir)
    {
        lifeTime = 0;
        direction = dir;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        if(Mathf.Sign(transform.localScale.x) != dir)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); 
        }
    }

    public void Deactivate()
    {
       
        
        gameObject.SetActive(false);
    }

}
