using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    public GameObject projectile;
    public string orientation;

    public float speed = 10f;
    float jump = 6.5f;
    private Rigidbody2D rgb2D;
    private Vector3 backTime;
    float clock = 0.0f;
    public int goToBackTime = 1;
    private int lastTime = 0;
    private bool jumpFlag = false;
    private Animator anim;
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timeControl();
        if (Input.GetKeyDown(KeyCode.Space) && jumpFlag == false)
        {
            rgb2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumpFlag = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            disparo();
        }

        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            orientation = "right";
        }
        else if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            orientation = "left";
        }
        anim.SetBool("Ground", !jumpFlag);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")*100f));

    }
    private void FixedUpdate()
    {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = backTime;
        }
    }
    public void timeControl()
    {
        clock += Time.deltaTime;
        if (lastTime != (int)clock % 60 && lastTime%2==0)
        {
            Debug.Log(lastTime);
            backTime = transform.position;
        }
        lastTime = (int)clock % 60;
    }
    public int getTime()
    {
        return lastTime;
    }

    void disparo()
    {
        GameObject p = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
        Projectile pro = p.AddComponent<Projectile>();
        pro.orientation = orientation;
        pro.y = transform.position.y;
        pro.speed = 15f;
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "ground") {
            jumpFlag = false;
        }
    }
}