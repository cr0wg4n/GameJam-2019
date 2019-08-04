using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float x, y;
    public string orientation;
    public float speed;
    void Start()
    {
        x = (orientation == "right") ? 12 : -12;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(x, y), speed * Time.deltaTime);
        if (transform.position.x == x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (transform.position.x == x)
        {
            Destroy(gameObject);
        }
    }
}