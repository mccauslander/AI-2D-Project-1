using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playersRB;

    // Start is called before the first frame update
    void Start()
    {
        playersRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playersRB.AddForce(Vector2.up * 200f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playersRB.AddForce(Vector2.left * 2000f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playersRB.AddForce(Vector2.right * 2000f * Time.deltaTime);
        }
    }
}
