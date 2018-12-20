using UnityEngine;
using System.Collections;

//belongs to enemy character(s)
public class EnemyCharacterScript : MonoBehaviour
{

    //declare variables
    private Rigidbody2D enemyRigidBody2D;

    

    private float movePlayerVector;

    public bool facingRight = false;

    public float speed = .5f;

    public float jumpPower = 1f;




    // Use this for initialization
    void Awake()
    {
        //connects Unity's rigidbody to code
        enemyRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));

        //connects Unity's Animator controller to code
 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        bool shoot = true; //automatic
        if (shoot)
        {
            EnemyWeaponScript weapon = GetComponent<EnemyWeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }

        movePlayerVector = 1;

        //Flipping the sprite
        if (enemyRigidBody2D.position.x <= -13 && !facingRight)
        {
            Flip();
           // enemyRigidBody2D.position = new Vector2(-12,0);
            movePlayerVector = 1;
            

        }
        else if (enemyRigidBody2D.position.x >= 13 && facingRight)
        {
            Flip();
            movePlayerVector = -1;

        }
        enemyRigidBody2D.velocity = new Vector2(movePlayerVector * speed, enemyRigidBody2D.velocity.y);


    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Bubble(Clone)")
        {
            Destroy(col.gameObject);

        }
    }


    

}

