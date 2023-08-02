using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playersRB;
    private bool isJumpInput = false;
    private bool isLeftInput = false;
    private bool isRightInput = false;
    private bool isAirbourne = false;

    private Health playerHealth;
    public TMP_Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        playersRB = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
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

        HealthText.text = "Health: " + playerHealth.health;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isJumpInput)
        {
            playersRB.AddForce(Vector2.up * 300f);
            isJumpInput = false;
        }
        
        if (isLeftInput) 
        {
            playersRB.AddForce(Vector2.left * 800f * Time.deltaTime);
            isLeftInput = false;
        }
        else if (isRightInput) 
        {
            playersRB.AddForce(Vector2.right * 800f * Time.deltaTime);
            isRightInput = false;
        }
        
        
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isAirbourne)
        {
            isAirbourne = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isAirbourne)
        {
            isAirbourne = true;
        }
    }

    public bool GetAirbourne()
    { 
        return isAirbourne; 
    }

    public void SetAirbourne(bool toggleChange)
    {
        isAirbourne = toggleChange;
    }
}
