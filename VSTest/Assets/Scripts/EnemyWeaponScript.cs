using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class EnemyWeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 2f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;//delay in start shooting
    }

    void Update()
    {
        if (shootCooldown > 0)//delay weapon shoot by each second passed
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isPlayer)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            EnemyProjectiles shot = shotTransform.gameObject.GetComponent<EnemyProjectiles>();
            if (shot != null)
            {
                shot.isPlayerShot = isPlayer;
            }




            // Make the weapon shot always towards it
            Move move = shotTransform.gameObject.GetComponent<Move>();

                    move.direction = this.transform.right * -1;
                    shot.transform.Rotate(0, 0, -180.0f);
            
            }
        }
    

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}