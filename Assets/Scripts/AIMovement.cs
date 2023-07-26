using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 1 * Time.deltaTime * speed, transform.position.y, transform.position.z) ;

        if( transform.position.x >= 10)
        {
            speed = -15.0f;
        }
        else if (transform.position.x <= -10)
        {
            speed = 15.0f;
        }
    }
}
