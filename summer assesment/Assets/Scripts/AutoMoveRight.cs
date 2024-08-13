    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AutoMoveRight : MonoBehaviour
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

            //move with inpout 
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

            // when jump button press add upward force 
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                //make sure to use impulse for jump instead of lift 
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false; 
            }
        }

        // when make ground contact, if true allow jump 
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground"|| collision.gameObject.CompareTag("obstacle"))
            {
                isGrounded = true;
            }
        }

        // when already touching grouqnd, if true allow jump
        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Ground"|| collision.gameObject.CompareTag("obstacle"))
            {
                isGrounded = true;
            }
        }

            // when stop  touching ground, if false do not allow jump
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }
    }
