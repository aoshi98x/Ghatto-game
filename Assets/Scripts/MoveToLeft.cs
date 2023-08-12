using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float movementSpeed=3f;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);

    }
}
