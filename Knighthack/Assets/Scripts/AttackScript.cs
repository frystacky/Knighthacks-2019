using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    private bool attacking = false;
    private float attackTimer;
    private float attackCd = 0.5f;

    public Collider2D attackCol;

    // Start is called before the first frame update
    void Awake()
    {
        attackCol.enabled = false;
        attackCol.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimer = attackCd;
            attackCol.enabled = true;
            attackCol.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackCol.enabled = false;
                attackCol.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
