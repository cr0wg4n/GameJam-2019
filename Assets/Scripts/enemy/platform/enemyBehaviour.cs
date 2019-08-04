using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public int health = 3;

    void OnTriggerEnter2D(Collider2D theCollider)
    {
        Debug.Log ("entre");
        health -= 1;

        if (theCollider.gameObject.name.Contains("proyectil"))
        {
            Projectile pro = theCollider.gameObject.GetComponent("proyectil") as Projectile;
            health -= pro.damage;
            Destroy(theCollider.gameObject);
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
