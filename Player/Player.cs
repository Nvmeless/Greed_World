using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // variables 
    public float maxHealth, maxThirst, maxHunger, maxStamina;
    public float thirstIncreaseRate, hungerIncreaseRate;
    public float thirstDamage, hungerDamage;
    public float health, thirst, hunger;
    public bool died;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        died = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!died)
        {
            if (thirst < maxThirst)
            {
                thirst += thirstIncreaseRate * Time.deltaTime;
            }
            if (hunger < maxHunger)
            {
                hunger += hungerIncreaseRate * Time.deltaTime;
            }
            if (thirst >= maxThirst)
            {
                health -= thirstDamage * Time.deltaTime;
            }
            if (hunger >= maxHunger)
            {
                health -= hungerDamage * Time.deltaTime;
            }
        }
            if (health <= 0 )
        {
            Die();
        }

    }

    public void Die() 
    {
        died = true;
        print("You've died because of thirst o Hunger");
    }
}

// A partir de la
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    //Stats
    public float maxHealth, maxThirst, maxHunger, maxStamina;
       public float thirstIncreaseRate, hungerIncreaseRate , staminaIncreaseRate;
       public float staminaDecreaseRate;
       public float thirstDamage, hungerDamage;
       public float health, thirst, hunger, stamina;
       public bool died;


    //Controller
    public CharacterController controller;
    public Component playerStats;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    // WallJump System
    public Transform wallJumpCheck;

    Vector3 velocity;
    bool isGrounded;
    bool isWallJumped;

    ////////Functions

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        died = false;
    }


    // Update is called once per frame
    void Update()
    {

        //Stats
        if (!died)
        {
            if(stamina < 0){
                stamina = 0;
            }
            if(stamina < maxStamina)
            {
                stamina += staminaIncreaseRate * Time.deltaTime;
            }
            if (thirst < maxThirst)
            {
                thirst += thirstIncreaseRate * Time.deltaTime;
            }
            if (hunger < maxHunger)
            {
                hunger += hungerIncreaseRate * Time.deltaTime;
            }
            if (stamina <= 0)
            {

            }
            if (thirst >= maxThirst)
            {
                health -= thirstDamage * Time.deltaTime;
            }

            if (hunger >= maxHunger)
            {
                health -= hungerDamage * Time.deltaTime;
            }
        }
        if (health <= 0)
        {
            Die();
        }


        // Controller
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isWallJumped = Physics.CheckSphere(wallJumpCheck.position, groundDistance, groundMask);



        if((isGrounded || isWallJumped )&& velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && (isGrounded || isWallJumped) && playerStats.stamina >= staminaDecreaseRate * 100 * Time.deltaTime)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            playerStats.stamina -= staminaDecreaseRate * 100 * Time.deltaTime ;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    public void Die()
    {
        died = true;
        print("You've died because of thirst o Hunger");
    }
}
*/

