using UnityEngine;
using System.Collections;


//main character only
public class HealthScript : MonoBehaviour {


    public int hp = 1;
    public bool isPlayer = true; //projectile will not hurt the player

	public void Damage(int damageCount)//function that will cause damage when called
    {
        hp -= damageCount;
        if(hp <= 0) //dead
        {
            //do whatever you want to the enemy character after death
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //will notice a collision if hurt by enemy projectile
        EnemyProjectiles shot = col.gameObject.GetComponent<EnemyProjectiles>();
        if(shot != null)//if shot
        {
            if(shot.isPlayerShot != isPlayer)
            {
                Damage(shot.damage);//calling function
                Destroy(shot.gameObject);//calling function
            }
        }
    }
}
