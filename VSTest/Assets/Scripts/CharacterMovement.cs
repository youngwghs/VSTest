using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    //instance variables
    float timer = 0f;
    float runningSpeed = 5f;

    float movePlayerVector = 0;

	// Use this for initialization
	void Start () {
        timer += Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        movePlayerVector = Input.GetAxis("Horizontal");
	}
}
