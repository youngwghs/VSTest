using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

    public GameObject B;
    private WeaponScript b1Script;
    //Any more variables needed here?


        //I agree, more variables are needed!~~

    
    
    void Start() { 
    b1Script = B.GetComponent("WeaponScript") as WeaponScript;
        //[insert connection to Dinosaur game object here]
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "blueEnemy")
        {
            
            b1Script.enemyCount -= 1;
        }
    }
}
