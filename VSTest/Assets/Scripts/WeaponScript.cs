using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    public int enemyCount = 4;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
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
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            projectiles shot = shotTransform.gameObject.GetComponent<projectiles>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            


            // Make the weapon shot always towards it
            Move move = shotTransform.gameObject.GetComponent<Move>();

            CharacterMovement facingDirection = GetComponent<CharacterMovement>();
            if (move != null)
            {
                if (facingDirection.facingRight)
                {
                    move.direction = this.transform.right; // towards in 2D space is the right of the sprite
                    
                }
                else
                {
                    move.direction = this.transform.right * -1;
                    shot.transform.Rotate(0, 0, -180.0f);



                }

            }
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

    void OnGUI()
    {


        GUIStyle textStyle = new GUIStyle();
        GUI.color = Color.white;
        textStyle.fontSize = 30;
        GUI.Label(new Rect(0, 0, 100, 100), "Enemies Left: " + enemyCount, textStyle);
    }
}