using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float jump;
    public Rigidbody rigidbody;
    public int hp;
    public bool onGround = true;
    public bool canTakeDamage = true;
    public GameObject gameOverScreen;
    public float rotationSpeed;
    void Start()
    {
        print("start");
        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

        if ( onGround )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector3.up * jump);
                onGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        onGround = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (canTakeDamage)
            {
                StartCoroutine(DamageDelay());
                TakeDamage();
            }
        }
    }
    
        IEnumerator DamageDelay()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.1f);
        canTakeDamage = true;
    }

    private void TakeDamage()
    {
        hp = hp - 1;
        if ( hp == 0)
        {
            Destroy(gameObject); 
            gameOverScreen.SetActive(true);
        }
    }
}   
        
    

