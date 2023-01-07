using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float moveSpeed;
    private float bottomBound = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerMovement();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * moveSpeed * horizontalInput);
        playerRb.AddForce(Vector3.forward * moveSpeed * verticalInput);
    }

    void ConstrainPlayerMovement()
    {
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
    }
}
