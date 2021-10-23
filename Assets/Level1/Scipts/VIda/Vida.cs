using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] public float StartHealth;
    public float VidaActual;
    
    public float maxHealth;
    private Animator anim;


    private void Awake()
    {
        VidaActual = StartHealth;
        maxHealth = StartHealth;
        
        anim = GetComponent<Animator>();
    }

    public void TakeDMG(float _dmg)
    {
        VidaActual = Mathf.Clamp(VidaActual - _dmg, 0, maxHealth);

        if (!isDead())
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            //GetComponent<PlayerMov>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
           
            
        }

    }
    public void addHp(float _hp)
    {
        VidaActual = Mathf.Clamp(VidaActual + _hp, 0, maxHealth);
        //TO DO
        //anim.SetTrigger("masVida");
    }

    public void addMaxHP()
    {
        maxHealth++;
    }

    private bool isDead()
    {
        if (VidaActual > 0) return false;

        return true;
    }

   

}
