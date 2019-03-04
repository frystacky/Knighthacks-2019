using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    private bool attacking = false;
    private float attackTimer;
    private float attackCd = 0.5f;
    private float attackLength = 0.3f;
    private KnightMovement knightMovementScript;

    public GameObject attackR;
    public GameObject attackL;

    Collider2D attackColR;
    Collider2D attackColL;
    SpriteRenderer spriteR;
    SpriteRenderer spriteL;

    // Start is called before the first frame update
    void Awake()
    {
        //get objects references
        attackColR = attackR.GetComponent<BoxCollider2D>();
        attackColL = attackL.GetComponent<BoxCollider2D>();
        spriteR = attackR.GetComponent<SpriteRenderer>();
        spriteL = attackL.GetComponent<SpriteRenderer>();

        attackColR.enabled = false;
        spriteR.enabled = false;
        attackColL.enabled = false;
        spriteL.enabled = false;

        //get player to check direction
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        knightMovementScript = player.GetComponent<KnightMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attacking)
        {

            attacking = true;
            attackTimer = attackCd;

            //check which direction knight is facing
            //facing right
            if (knightMovementScript.getDirection()) {
                Debug.Log("Attacking R");
                attackColR.enabled = true;
                spriteR.enabled = true;
            }
            else
            {
                Debug.Log("Attacking L");
                attackColL.enabled = true;
                spriteL.enabled = true;
            }
        }

        if (attacking)
        {
            //disable cone of attack and hitbox
            if(attackTimer < attackCd - attackLength)
            {
                attackColR.enabled = false;
                spriteR.enabled = false;
                attackColL.enabled = false;
                spriteL.enabled = false;
            }

            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
    }
}
