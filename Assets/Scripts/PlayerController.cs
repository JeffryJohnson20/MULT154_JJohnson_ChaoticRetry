using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 1000.0f;
    private Vector3 jump = new Vector3(0, 10, 0);
    private bool playerGrounded = true;
    public GameObject spawnPoint;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoint.transform.position;
        playerRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        playerRb.AddForce(new Vector3(horMove, 0.0f, verMove) * Time.deltaTime * speed);
        if(playerGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(jump, ForceMode.VelocityChange);
            playerGrounded = false;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = spawnPosition;
            transform.rotation = spawnPoint.transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!playerGrounded)
            {
                playerGrounded = true;
            }
        }
    }
}
