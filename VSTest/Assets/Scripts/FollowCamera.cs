using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {


    public float xMargin = 1.5f;//left and right margin
    public float yMargin = 1.5f;//up and down margin

    public float xSmooth = 1.5f;//how smoothly camera moves L/R
    public float ySmooth = 1.5f;//how smoothly camera moves U/D

    public Vector2 maxXAndY;//can prevent from showing non-background
    public Vector2 minXAndY;//limits the amount user can see at moment

    public Transform player;//change player reference point

    

    void Awake()//happens when game starts only
    {
        player = GameObject.Find("Mario").transform;//Insert Unity character name in quotes
        if(player == null)
        {
            Debug.LogError("Player object not found");
        }
    }

    bool CheckXMargin()
    {
                       //Point B                Point A
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        //Point B                Point A
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

   

    void FixedUpdate()//checks much more frequently than Update()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())//has margin been breached
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }

        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        }

        //move camera based on answers above
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

}
