using UnityEngine;
using System.Collections;


//main character only
public class EnemyHealthScript : MonoBehaviour
{


    public int hp = 1;
    public bool isEnemy = true;

    

    public void Damage(int damageCount)
    {
        WeaponScript enemycount = GetComponent<WeaponScript>();

        hp -= damageCount;
        if (hp <= 0) //dead
        {
            //do whatever you want to the enemy character after death
            Destroy(gameObject);
           
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //gets hurt by main character projectile
        projectiles shot = col.gameObject.GetComponent<projectiles>();
        if (shot != null)//if shot
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);//calling function
                Destroy(shot.gameObject);//calling function
            }
        }
    }
}
