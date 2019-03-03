﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing_Zombie : MonoBehaviour
{
    [SerializeField] private float speed;
    GameObject player;
    Rigidbody2D rb2d;
    Vector3 xyz;
    Vector3 knight_xyz;
    [SerializeField] Sprite[] directionFacing;
    bool chasing = false;
    private SpriteRenderer facing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        rb2d = GetComponent<Rigidbody2D>();
        facing = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //get zombie unstuck if chasing and not moving in x
        if (chasing && xyz.x == transform.position.x)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 20);
        }
        */

        xyz = transform.position;
        knight_xyz = player.transform.position;
        //check distance
        if (Vector3.Distance(xyz, knight_xyz) < 25.0)
        {
            chasing = true;
            //zombie chases left
            if(xyz.x < knight_xyz.x)
            {
                facing.sprite = directionFacing[1];
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
            else
            {
                facing.sprite = directionFacing[0];
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            }
        }
        else if (Vector3.Distance(xyz, knight_xyz) > 35.0)
        {
            chasing = false;
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    //zombie deals damage and knocks back the knight
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collide = collision.gameObject;
        if(collide.tag == "Player")
        {
            Rigidbody2D knight_rb2d = collide.GetComponent<Rigidbody2D>();

            //knockback right
            if (xyz.x < knight_xyz.x)
            {
                knight_rb2d.velocity = new Vector2(50,75);
            }
            else
            {
                knight_rb2d.velocity = new Vector2(-50, 75);
            }
        }
    }
}
