using UnityEngine;
using System.Collections;

public class PrizesAppear : MonoBehaviour {

    private Rigidbody2D prizeRigidBody2D;
    private float movePrizeVector=0;
    public float speed = .5f;

    // Use this for initialization
    void Start () {
        prizeRigidBody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //  CharacterMovement facingDirection = GetComponent<CharacterMovement>();
        
       
	}
}
