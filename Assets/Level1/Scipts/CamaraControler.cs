
using UnityEngine;

public class CamaraControler : MonoBehaviour
{

    [SerializeField] private float speed;
    private float currentPosX;
    public Vector3 checkpoint;
  
    


    //player to follow
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        checkpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        
    }


    private void Update()
    {
       
        if (player == null)
        {
            
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        else
        {
         
            if (player.GetComponent<PlayerMov>().reset)
            {
                transform.position = checkpoint;
            }


                if (player.position.x >= -1.37)
                {
                    //FollowPlayer
                    transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
                }

            }
        
            
    }


    

    public void MoveToNewRoom(Transform _newPos)
    {

        currentPosX = _newPos.position.x;
    }




}
