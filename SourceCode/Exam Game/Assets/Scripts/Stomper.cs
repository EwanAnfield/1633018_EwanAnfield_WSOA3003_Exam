using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{

    public float speed = 5;
    public GameObject pointOne;
    public GameObject pointTwo;

    public bool down;
    // Start is called before the first frame update
    void Start()
    {
        down = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(this.transform.position, pointOne.transform.position, step);
        }

        if (!down)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(this.transform.position, pointTwo.transform.position, step);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point1")
        {         
             down = false;
        }
        if (collision.tag == "Point2")
        {
            down = true;
        }
    }
}
