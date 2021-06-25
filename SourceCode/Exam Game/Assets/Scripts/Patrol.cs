using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;

    public bool movingRight = true;

    public Transform groundDetection;
    public Transform wallDetection;
    public Transform wallDetection2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);  

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
                Debug.DrawLine(groundDetection.position, Vector2.down, Color.red);
            }

            RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, transform.forward, 1f);
            if (wallInfo.collider == true)
            {
                if (wallInfo.collider.gameObject.CompareTag("Black") && movingRight || wallInfo.collider.gameObject.CompareTag("White") && movingRight || wallInfo.collider.gameObject.CompareTag("PlaceHolder") && movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else if (wallInfo.collider.gameObject.CompareTag("Black") && !movingRight || wallInfo.collider.gameObject.CompareTag("White") && !movingRight || wallInfo.collider.gameObject.CompareTag("PlaceHolder") && !movingRight)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kill")
        {
            gameObject.SetActive(false);
        }
    }
}
