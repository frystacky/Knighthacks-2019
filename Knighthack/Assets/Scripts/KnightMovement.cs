﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KnightMovement : MonoBehaviour

{
    public bool swordIsRight = true;

    public int hp = 100;                    // players hp
    [SerializeField] Text HpDisplay;


    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.
    private bool canJump = true;
    private SpriteRenderer facing;

    [SerializeField] SpriteRenderer swords;

    private Animator walkingDir;

    [SerializeField] GameObject sword;


    [SerializeField] int speed = 40;
    [SerializeField] Sprite[] directionFacing;

    [SerializeField] Sprite[] swordModle;

    LevelHandler getMeOutOfHere;

    //[SerializeField] AnimationClip[] walking;



    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        facing = gameObject.GetComponent<SpriteRenderer>();

        walkingDir = gameObject.GetComponent<Animator>();

        swords = sword.GetComponent<SpriteRenderer>();

        getMeOutOfHere = FindObjectOfType<LevelHandler>();

    }

    void Update()
    {

        if(hp <= 0)
        {
            getMeOutOfHere.ToMainMenu();
        }
        
        HpDisplay.text = hp.ToString();

        //float yval = rb2d.velocity.y;
        rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);

        //set y velocity poitive
        if (Input.GetKey(KeyCode.D))
        {
            swordIsRight = true;
            walkingDir.Play("WalkRight");

            facing.sprite = directionFacing[0];
            swords.sprite = swordModle[0];
            sword.transform.localPosition = new Vector2(4.4f,3.1f);
            sword.transform.localRotation = Quaternion.Euler(0, 0, 0);

            //go right
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            walkingDir.Play("Ideal");
            facing.sprite = directionFacing[0];
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            walkingDir.Play("Ideal");
            facing.sprite = directionFacing[1];
        }


        if (Input.GetKey(KeyCode.A))
        {
            swordIsRight = false;
            walkingDir.Play("WalkLeft");

            facing.sprite = directionFacing[1];
            swords.sprite = swordModle[0];
            sword.transform.localPosition = new Vector2(-0.79f, 3.1f);
            sword.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            //go left
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);

        }

        if (Input.GetKeyDown("space") && canJump)
        {
            walkingDir.Play("Ideal");
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + 70);
       }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Dirt")
        {
            canJump = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dirt")
        {
            canJump = false;
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
    }
}
