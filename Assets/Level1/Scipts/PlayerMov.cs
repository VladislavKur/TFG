using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Joystick joystick;
    
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    // START VARIABLES
    private Vector2 StartPosition;
    public Vector3 checkpoint;
    private GameObject[] corazones;
    private GameObject[] corazonesNegros;
    private float gravityStart;
    public bool reset;
    private List<CorazonVida> listCorazones;
    //

    [SerializeField] private float movespeed;
    [SerializeField] private float jumpspeed;

    private float horizontalInput;
    private float horizontalJoystick;
    private float verticalJoystick;
    private float wallJumpCouldown;
    private float gravity;
    private bool moving;

    //string SavePath = "gamedata";


    private void Start()
    {
        // recoger la referencias al rigidbody y animacion del objeto
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        gravity = body.gravityScale;
        corazones = GameObject.FindGameObjectsWithTag("corazon");
        corazonesNegros = GameObject.FindGameObjectsWithTag("corazon purpura");
        StartPosition = body.position;
        checkpoint = body.position;
        gravityStart = body.gravityScale;
        reset = false;
        moving = false;
        listCorazones = new List<CorazonVida>();

    }



    private void Update()
    {

        if(GameManager.Instance.State == GameState.ContinueGame)
        {
            LoadPlayer();
        }
        
        bool vida = GetComponent<Vida>().VidaActual >= 1;
        if (Input.GetKeyDown(KeyCode.Return) && !vida)
        {
            //resetGameState();
            LoadPlayer();
        }else if (vida && !PauseMenu.GameIsPaused){
            horizontalInput = Input.GetAxis("Horizontal");
            horizontalJoystick = joystick.Horizontal;
            verticalJoystick = joystick.Vertical;
            Debug.Log(horizontalInput);
            if (horizontalInput != 0 || horizontalJoystick > .5f || horizontalJoystick < -0.5 || verticalJoystick > .5f || verticalJoystick < -.5) moving = true;
            else moving = false;

            // orientacion Sprite
            if (horizontalInput > 0.01f || horizontalJoystick > .5f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (horizontalInput < -0.01f || horizontalJoystick < -0.35f)
                transform.localScale = new Vector3(-1, 1, 1);
           


            //set variables de animacion

            anim.SetBool("run", (horizontalInput != 0 || horizontalJoystick != 0));
            anim.SetBool("Grounded", onGround());

            float move = 0;
            
            if (horizontalInput > 0.01|| horizontalJoystick > .3f) move = 1;
            else if (horizontalInput < -0.01 || horizontalJoystick < -0.3f) move = -1;
            else move = 0;
            body.velocity = new Vector2(move * movespeed, body.velocity.y);
            
            if (horizontalInput != 0)
            {
                body.velocity = new Vector2(horizontalInput * movespeed, body.velocity.y);
            }

            if (wallJumpCouldown >= 0.2f)
            {
                

                if (onWall() && !onGround())
                {


                    body.gravityScale = 0;
                    body.velocity = Vector2.zero;

                }
                else
                    body.gravityScale = gravity;

                
                if (Input.GetKey(KeyCode.Space) || verticalJoystick > .5f)
                {
                    jump();
                }
            }
            else
                wallJumpCouldown += Time.deltaTime;
        }

        


    }


    private void jump()
    {

        if (onGround())
        {
            body.velocity = new Vector2(body.velocity.x, jumpspeed);
            onGround();
            anim.SetTrigger("jump");
        }
        else if(onWall() && !onGround())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 6, 0);
                transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 6, jumpspeed* 0.75f);


            wallJumpCouldown = 0;

        }
  

    }


    private bool onGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);

        return raycastHit.collider != null;

 
    }

    public bool canAttack()
    {
        return !moving && onGround() && !onWall();

        
    }

    public void resetGameState()
    {
        reset = true;
        //reset de corazones
        for (int i = 0; i < corazones.Length; ++i) corazones[i].SetActive(true);
        for (int i = 0; i < corazonesNegros.Length; ++i) corazonesNegros[i].SetActive(true);
      
        //VIDA del PLAYER
        GetComponent<Vida>().VidaActual = GetComponent<Vida>().StartHealth;
        GetComponent<Vida>().maxHealth = GetComponent<Vida>().StartHealth;


        //set animation to idle
        anim.SetTrigger("jump");

        //Reset velocidades y posicion
        body.position = StartPosition;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
      
       
        body.gravityScale = gravityStart;
      
    }

    public void SavePlayer()
    {
        if (GameObject.FindGameObjectWithTag("corazon") != null)
        {
            listCorazones = CorazonVida.getCorazones();
          
        }



        if (this != null)           SaveSystem.Save( this);
        if (listCorazones != null) SaveSystem.SaveHeart(listCorazones); else SaveSystem.SaveHeart(null);
        Debug.Log(" SE HA GUARDADO " ); 
    }
    public void LoadPlayer()
    {
        PlayerData player = SaveSystem.Load();
        HeartData hearts = SaveSystem.LoadCorazon();
        Debug.Log("LOAD CORAZONES: "+ hearts.heartLength + " == " + hearts.curacion.Length);
        if(player == null)
        {
            Debug.Log("DATA LOAD ERROR");
           // GetComponent<PauseMenu>().Resume();
        }
        else {
            GetComponent<Vida>().VidaActual = player.health;
            GetComponent<Vida>().maxHealth = player.maxHealth;

            //posicion del Player
            Vector3 position;
            position.x = player.position[0];
            position.y = player.position[1];
            position.z = player.position[2];
            transform.position = position;

            PauseMenu.GameIsPaused = false;
            Time.timeScale = 1f;

            anim.SetTrigger("jump");


        }
        

        if (hearts == null)
        {
            Debug.Log("HEALTH LOAD ERROR");
        }else
        {
           // Debug.Log("HEALTH LOAD " + hearts.heartLength);

            //CORAZONES NECESITAN UN ID
            for (int i = 0; i < hearts.heartLength; ++i)
            { 
                    listCorazones[i].gameObject.SetActive(hearts.isActive[i]);
            }
        }

       
            
    }

    public void setCheckpoint(Vector3 newcheckpoint)
    {
        if(checkpoint != newcheckpoint) checkpoint = newcheckpoint;
    }
    



}
