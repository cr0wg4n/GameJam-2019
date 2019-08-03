using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    int x, y;

    public float velocidad;
    //public float aceleracion = 0f;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //int rnd = Random.Range(100, 1000);

        //for (int i=0 ; i<rnd; i++)
        //{
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(x, y), velocidad * Time.deltaTime);
        //}

        if(transform.position.x == x && transform.position.y == y)
        {
            nextPosition();
        }
    }

    void nextPosition()
    {
        velocidad = ((float)Random.Range(20, 50) / (float)100);
        x = Random.Range(-7, 7);
        y = Random.Range(-10, 10);
    }
}
