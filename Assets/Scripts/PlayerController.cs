using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    Rigidbody catRigid;

    [Range(0, 15)]
    [SerializeField] float speed;

    [SerializeField] bool onFloor, canJump;

    [Space(10)]
    [Header("Collectibles Zone")]
    [SerializeField] TextMeshProUGUI foodCount;
    [SerializeField] int foodAmount;


    // Start is called before the first frame update
    void Start()
    {
        catRigid = GetComponent<Rigidbody>();
        foodCount = GameObject.Find("FoodCounter").GetComponent<TextMeshProUGUI>();
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
        if (collision.gameObject.CompareTag("Floor"))
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            foodAmount++;
            foodCount.text = "Food: " + foodAmount;
        }
    }
}
