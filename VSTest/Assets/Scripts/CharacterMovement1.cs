using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    //declare variables
    private Rigidbody2D playerRigidBody2D;

    private float movePlayerVector;

    public  bool facingRight;

    public float speed = .5f;

    public int enemyCount = 4;

    private AudioSource source;

    public AudioClip bubble;
    


    //Reference to graphical animator controller in Unity
    

    //jump speed
    public float jumpPower = 1f;

   

    // Use this for initialization
    void Awake () {
        //connects Unity's rigidbody to code
        playerRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));

        //connects Unity's Animator controller to code

        Move enemyConnect = GetComponent<Move>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        bool shoot = Input.GetKeyDown(KeyCode.F);
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
                
            }
            source.PlayOneShot(bubble);
        }
        

        movePlayerVector = Input.GetAxis("Horizontal");

        

        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);

        


        //jump detection
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * jumpPower * Time.deltaTime, Space.World);
            if(playerRigidBody2D.position.y >= 8.98)
            {
                
            }
        }

      
        //Flipping the sprite
        if (movePlayerVector > 0 && !facingRight)
        {
            Flip();
        }
        else if (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }

      

       
        
    }
        void Flip(){
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    

    


}

