using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    void Update()
    {        
        if (transform.position.z >= 95) {
            GetComponent<PlayerControl>().enabled = false;
        }
    }
}
