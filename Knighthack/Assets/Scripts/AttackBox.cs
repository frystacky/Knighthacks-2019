using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true && collision.CompareTag("Zombie"))
        {
            collision.SendMessageUpwards("Damage", damage);
        }
    }
}
