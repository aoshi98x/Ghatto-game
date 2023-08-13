using System;
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
    [SerializeField] int clickCounter;

    [Space(10)]
    [Header("Collectibles Zone")]
    [SerializeField] TextMeshProUGUI foodCount;
    [SerializeField] protected int foodAmount;

    [Space(10)]
    [Header("Attack")]
    [SerializeField] GameObject arm;
    [SerializeField] Animator catAnimator;
    [SerializeField] AttackControl attackControl;
    float timeToZero;

    // Start is called before the first frame update
    void Start()
    {
        catRigid = GetComponent<Rigidbody>();
        /*foodCount = GameObject.Find("FoodCounter").GetComponent<TextMeshProUGUI>();
        catAnimator = GetComponent<Animator>();*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickCounter < 2)
        {
            clickCounter++;
        }

        else if (Input.GetMouseButtonDown(1) && onFloor)
        {
            clickCounter = 2;
        }
        
        switch (clickCounter)
        {
            

            case 1:
                if (Input.GetMouseButtonDown(0) && onFloor)
                {
                    canJump = true;
                }
                break;

            case 2:
                {
                    AttackMode(true);
                    timeToZero += Time.deltaTime;
                    if(timeToZero > 0.5f)
                    {
                        clickCounter = 0;
                        timeToZero = 0;
                    }
                    
                }

                break;

            default:
                {
                    AttackMode(false);
                }    
                break;
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

    void AttackMode(bool state)
    {
        arm.SetActive(state);
        catAnimator.SetBool("AtkCuchillo", state);
        attackControl.enabled = state;
    }
    void Jump()
    {
        catRigid.AddForce(Vector3.up * speed, ForceMode.Impulse);
        catAnimator.SetBool("Salto", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
            catAnimator.SetBool("Salto", false);
            clickCounter = 0;
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
        if (other.gameObject.CompareTag("Food") && clickCounter < 2)
        {
            foodAmount++;
            foodCount.text = Convert.ToString(foodAmount);
        }
    }
}
