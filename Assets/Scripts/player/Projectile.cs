using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float x, y;
    public string orientation;
    public float speed;
    public float lifetime = 2.0f;

    public int damage = 1;
    public Vector3 destine;
    void Start()
    {
        //x = (orientation == "right") ? 12 : -12;
        //Destroy(gameObject, lifetime);
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector2(x, y), speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(destine.x, destine.y), speed * Time.deltaTime);
        if (transform.position.x == x)
        {
            Destroy(gameObject);
        }
    }
}