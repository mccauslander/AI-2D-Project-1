using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playersRB;
    private bool isJumpInput = false;
    private bool isLeftInput = false;
    private bool isRightInput = false;

    // Start is called before the first frame update
    void Start()
    {
        playersRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpInput = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeftInput = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isRightInput = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isJumpInput)
        {
            playersRB.AddForce(Vector2.up * 200f);
            isJumpInput=false;
        }
        if (isLeftInput) 
        {
            playersRB.AddForce(Vector2.left * 2000f * Time.deltaTime);
            isLeftInput=false;
        }
        else if (isRightInput) 
        {
            playersRB.AddForce(Vector2.right * 2000f * Time.deltaTime);
            isRightInput=false;
        }
    }
}
