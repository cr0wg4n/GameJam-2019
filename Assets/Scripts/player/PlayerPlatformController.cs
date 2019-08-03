using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    public float speed = 10f;
    float jump = 6.5f;
    private Rigidbody2D rgb2D;
    private Vector3 backTime;
    float clock = 0.0f;
    public int goToBackTime = 1;
    private int lastTime = 0;
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeControl();
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rgb2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.T)) {
            transform.position = backTime;
        }
    }
    public void timeControl() {
        clock += Time.deltaTime;
        if (lastTime != (int)clock % 60)
        {
            backTime = transform.position;
        }
        lastTime = (int)clock % 60;
    }
    public int getTime() {
        return lastTime;
    }
}
