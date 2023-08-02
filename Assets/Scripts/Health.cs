using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using Unity.VisualScripting;

public class Health : MonoBehaviour
{
    public int health;
    public int damageIncrement;
    public int healthIncrement;
    private int maxHealth = 100;

    //private GameObject ownGO;
    private PlayerMovement activePlayer;
    // Start is called before the first frame update
    void Start()
    {
        //ownGO = GetComponent<GameObject>();
        activePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
            {
                //Damage player as enemy
                collision.gameObject.GetComponent<Health>().health -= damageIncrement;
                Debug.Log("Player hit! Health now " + collision.gameObject.GetComponent<Health>().health);
                if (collision.gameObject.GetComponent<Health>().health <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player") && activePlayer.GetAirbourne() && activePlayer.transform.position.y > gameObject.transform.position.y - 1.5 )
            {
                //Damage enemy only when jumping as player
                collision.gameObject.GetComponent<Health>().health -= damageIncrement;
                Debug.Log("Enemy hit! Health now " + collision.gameObject.GetComponent<Health>().health);
                if (collision.gameObject.GetComponent<Health>().health <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("Pickup") && gameObject.CompareTag("Player"))
            {
                //Heal player if pick up is collected by player
            }
        }
    }
}
