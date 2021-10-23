
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    
    [SerializeField] private float dmg= 1;
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
      
            collision.GetComponent<Vida>().TakeDMG(dmg);
        }
        
    }

}
