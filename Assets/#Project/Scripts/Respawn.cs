using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 initialPosition;
    public bool isGrounded = true;
    public float fallingLevel = -2f;
    private Transform cameraRespawn;
    public float decalZ = -8f;
    void Start()
    {
        initialPosition = transform.position;
        cameraRespawn = GetComponent<CameraMove>().cameraTransform;
        decalZ = GetComponent<CameraMove>().decalZ;
        isGrounded = GetComponent<PlayerControl>().isGrounded;
    }

    void Update()
    {
        if (transform.position.y < fallingLevel) {
            RespawnAtStart();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            RespawnAtStart();
        }
    }

    void RespawnAtStart() {
        transform.position = initialPosition;

        // Rigidbody rb = GetComponent<Rigidbody>();
        // if (rb != null) 
        // {
        //     rb.velocity = Vector3.zero;
        // }

        isGrounded = true;

        Vector3 position = cameraRespawn.position;
        position.z = transform.position.z + decalZ;
        cameraRespawn.position = position;
    }
}
