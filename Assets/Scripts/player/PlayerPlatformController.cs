using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    public float speed = 10f;
    float jump = 6.5f;
    private Rigidbody2D rgb2D;
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rgb2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);

    }
}
