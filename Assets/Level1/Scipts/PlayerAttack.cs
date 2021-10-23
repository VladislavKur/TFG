
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMov playerMov;

   [SerializeField] private float attackCooldown;
   [SerializeField] private Transform Firepoint;
   [SerializeField] private GameObject[] bolasDeFuego;


    private float coolDownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMov = GetComponent<PlayerMov>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCooldown && !PauseMenu.GameIsPaused)
        {
            if(playerMov.canAttack())
            Attack();
        }

        coolDownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;

        //pillar bolas de fuego
        bolasDeFuego[FindFireBall()].transform.position = Firepoint.position;
        bolasDeFuego[FindFireBall()].GetComponent<Proyectil>().SetDirection(Mathf.Sign(transform.localScale.x));
        
    }

    private int FindFireBall()
    {
        for(int i = 0; i < bolasDeFuego.Length; ++i)
        {
            if (!bolasDeFuego[i].activeInHierarchy)
                return i;

            
        }

        return 0;
    }

}
