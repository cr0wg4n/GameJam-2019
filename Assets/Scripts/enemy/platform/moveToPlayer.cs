using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPlayer : MonoBehaviour
{
    private Transform player;
    public float speed = .02f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("PlayerPlatform").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.Normalize();
        this.transform.position += direction * speed;
    }
}
