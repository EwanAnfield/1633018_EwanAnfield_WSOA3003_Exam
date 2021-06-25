using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBlack : MonoBehaviour
{

    public GameObject BlackBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(BlackBox.transform.position.x, BlackBox.transform.position.y, BlackBox.transform.position.z);
    }
}
