using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody catRigid;

    [Range(0, 15)]
    [SerializeField]float speed;

    [SerializeField] bool onFloor, canJump;
    // Start is called before the first frame update
    void Start()
    {
        catRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && onFloor) 
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        if(canJump)
        {
            Jump();
            canJump = false;
        }
    }
    void Jump()
    {
        catRigid.AddForce(Vector3.up * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }
}
