using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headless_Zombie : MonoBehaviour
{
    [SerializeField] private float speed;
    GameObject player;
    Rigidbody2D rb2d;
    Vector3 xyz;
    Vector3 knight_xyz;
    [SerializeField] Sprite[] directionFacing;
    private SpriteRenderer facing;
    int stuck_frames = 0;
    float left_bound;
    float right_bound;
    bool goingLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        knight_xyz = player.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        facing = gameObject.GetComponent<SpriteRenderer>();
        xyz = transform.position;
        left_bound = xyz.x - 20;
        right_bound = xyz.x + 20;
    }

    // Update is called once per frame
    void Update()
    {

        //get zombie unstuck if not moving in x
        if (xyz.x == transform.position.x)
        {
            stuck_frames++;
            if (stuck_frames > 20)
            {
                stuck_frames = 0;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 20);
            }
        }
        else
        {
            stuck_frames = 0;
        }

        xyz = transform.position;
        knight_xyz = player.transform.position;

        if(goingLeft == true)
        {
            facing.sprite = directionFacing[1];
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            if(xyz.x < left_bound)
            {
                goingLeft = false;
            }
        }
        else
        {
            facing.sprite = directionFacing[2];
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            if (xyz.x > right_bound)
            {
                goingLeft = true;
            }
        }

    }

    //zombie deals damage and knocks back the knight
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collide = collision.gameObject;
        if (collide.tag == "Player")
        {
            Rigidbody2D knight_rb2d = collide.GetComponent<Rigidbody2D>();

            //knockback right
            if (xyz.x < knight_xyz.x)
            {
                knight_rb2d.velocity = new Vector2(50, 75);
            }
            else
            {
                knight_rb2d.velocity = new Vector2(-50, 75);
            }
        }
    }
}
