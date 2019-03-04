using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KnightMovement : MonoBehaviour
{
    //animation control variables
    private bool swordIsRight = true;
    private bool isMoving = false;

    public int hp = 100;
    [SerializeField] Text HpDisplay;


    private Rigidbody2D rb2d;
    private bool canJump = true;
    bool knockback = false;
    private SpriteRenderer facing;
    private Animator knightMovementAnimator;

    [SerializeField] GameObject sword;


    [SerializeField] int speed = 40;
    [SerializeField] Sprite[] directionFacing;
    [SerializeField] Sprite[] swordModle;
    [SerializeField] SpriteRenderer swords;

    LevelHandler getMeOutOfHere;

    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        facing = gameObject.GetComponent<SpriteRenderer>();

        knightMovementAnimator = gameObject.GetComponent<Animator>();

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

        //set y velocity poitive
        if (Input.GetKey(KeyCode.D) && !knockback)
        {
            //update speed if not already moving right
            if(rb2d.velocity.x < speed)
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }

            swordIsRight = true;
            isMoving = true;
            facing.sprite = directionFacing[0];
            swords.sprite = swordModle[0];
            sword.transform.localPosition = new Vector2(4.4f, 3.1f);
            sword.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetKeyUp(KeyCode.D) && !knockback)
        {
            facing.sprite = directionFacing[0];
            isMoving = false;
            if (rb2d.velocity.x >= speed*0.9)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x - speed, rb2d.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.A) && !knockback)
        {
            //update speed if not already moving left
            if (rb2d.velocity.x > -speed)
            {
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            }

            swordIsRight = false;
            isMoving = true;
            facing.sprite = directionFacing[1];
            swords.sprite = swordModle[0];
            sword.transform.localPosition = new Vector2(-0.79f, 3.1f);
            sword.transform.localRotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (Input.GetKeyUp(KeyCode.A) && !knockback)
        {
            facing.sprite = directionFacing[1];
            isMoving = false;
            if (rb2d.velocity.x >= -speed*1.5)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x + speed, rb2d.velocity.y);
            }
        }

        if (Input.GetKeyDown("space") && canJump)
        { 
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + 70);
        }

        knightMovementAnimator.SetBool("facingRight", swordIsRight);
        knightMovementAnimator.SetBool("inMotion", isMoving);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Dirt")
        {
            canJump = true;
            knockback = false;
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
        knockback = true;
    }

    public bool getDirection()
    {
        return swordIsRight;
    }
}
