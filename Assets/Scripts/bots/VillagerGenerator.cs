using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerGenerator : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;

    public List<GameObject> villagers;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        int n = Random.Range(2, 6);
        for (int i=0; i<n ; i++)
        {
            int villagerType = (int)Random.Range(0, 1);
            switch (villagerType)
            {
                case 0:
                    GameObject b = Instantiate(boy, randomizePosition(), Quaternion.identity);
                    Villager vill = b.AddComponent<Villager>();
                    villagers.Add(b);
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    Vector3 randomizePosition()
    {
        float x = Random.Range(-10.0f, 10.0f);
        int r = Random.Range(0, 2);
        float y = 0f;
        if (r == 1)
        {
            y = Random.Range(-6.0f, -1.3f);
        }
        else
        {
            y = Random.Range(1.3f, 6.0f);
        }
        Vector3 res = new Vector3(x, y, 0.0f);
        return res;
    }
}
