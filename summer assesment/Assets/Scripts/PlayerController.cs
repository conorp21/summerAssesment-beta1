using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1500f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move with input
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // When jump button is pressed, add upward force
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Make sure to use impulse for jump instead of lift 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // When making ground contact, allow jump
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("obstacle"))
        {
            isGrounded = true;
        }
    }

    // When already touching ground, allow jump
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("obstacle"))
        {
            isGrounded = true;
        }
    }

    // When stop touching ground, do not allow jump
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Handle trigger events
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            GameManager.instance.AddKey();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            if (GameManager.instance.playerKeys > 2)
            {
                SceneManager.LoadScene("levelWon");
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.RemoveLife();
             if (GameManager.instance.showlife() == 0)
            {
                Destroy(gameObject);
            }
            GameManager.instance.showlife();
            StartCoroutine(HandleEnemyCollision());
        }
       else if (other.gameObject.CompareTag("Powerup"))
        {
            GameManager.instance.AddLife();
            Destroy(other.gameObject);
        }
    }

    
    private IEnumerator HandleEnemyCollision()
    {
       
        yield return new WaitForSeconds(1);
       
    }
}
