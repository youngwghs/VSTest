using UnityEngine;
using System.Collections;

public class PlantPacing : MonoBehaviour {

    private Rigidbody2D plant;

    public Transform down;
    private Vector3 up;
    private Vector3 reverse;
    private float secondsForOneLength = 5f;
   
    float speed = 5f;
    public bool loadedUp = false;
    Transform plantPosition;

	// Use this for initialization
	void Start () {
        plant = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        up = transform.position;
        reverse = down.position;
	}
	
	// Update is called once per frame
	void Update () {
        plant.velocity = new Vector2(plant.velocity.x, speed * 2);

        transform.position = Vector3.Lerp(up, reverse, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / secondsForOneLength, 1f)));

	}
}
