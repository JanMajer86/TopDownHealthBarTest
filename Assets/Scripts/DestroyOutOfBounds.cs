using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 20.0f;
    private float bottomBound = -10.0f;

    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
