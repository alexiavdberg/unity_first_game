using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // public float offset;
    // public Transform target;
    // void Update()
    // {
    //     // Vector3 position = new Vector3(0, 4, target.position.z - offset);
    //     // transform.position = position;

    //     Vector3 position = transform.position;
    //     position.z = offset;
    //     transform.position = position;

    //     transform.position = target.position - transform.position;
    // }

    [HideInInspector] public Transform cameraTransform;
    private float speed;
    public float decalZ = -8f;

    void Start()
    {
        speed = GetComponent<PlayerControl>().speed;
        cameraTransform = Camera.main.transform;
        Vector3 position = cameraTransform.position;
        position.z = transform.position.z + decalZ;
        cameraTransform.position = position;
    }

    void Update()
    {
        Vector3 position = cameraTransform.position;
        position.z = transform.position.z + decalZ;
        //cameraTransform.position = position;
        Vector3 direction = (position - cameraTransform.position).normalized;
        cameraTransform.position += direction * speed * Time.deltaTime;
    }
}
