using UnityEngine;
using System.Collections;

//belongs to enemy character(s)
public class EnemyProjectiles : MonoBehaviour
{

    public int damage = 1;
    public bool isPlayerShot = false;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
