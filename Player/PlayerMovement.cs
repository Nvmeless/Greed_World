using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //hash Anim
    private int jumpHash = Animator.StringToHash("_jump");
    
    //Controller
    public CharacterController controller;
    public PlayerStats playerStats;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float wallJumping;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool sheath;
    // WallJump System

    public Transform wallJumpCheck; 

    //Attaques 
    public float attackCooldown;

    private bool isAttacking;

    private float currentCooldown;
//animations

    public Animator animations;
    Vector3 velocity;
    bool isGrounded;
    bool isWallJumped;
//mort 
    public bool isDead;
    ////////Functions

    // Start is called before the first frame update
    void Start()
    {
        sheath = false;
        isDead = false;
    //animations = gameObject.GetComponent<Animation();
    playerStats = (PlayerStats)playerStats.GetComponent<PlayerStats>();
    wallJumping = 1;
    animations = animations.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            
         
            // Controller
            isWallJumped = Physics.CheckSphere(wallJumpCheck.position, groundDistance, groundMask);
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);




            if((isGrounded || isWallJumped )&& velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
// != 0f

            animations.SetFloat("_speed", z);
            animations.SetFloat("_sideway", x);



            Vector3 move = transform.right * x + transform.forward * z;

        
            controller.Move(move * speed * Time.deltaTime);
           
            if (!isGrounded)
            {
                animations.SetBool("_inNotGrounded", isGrounded);
            }
            else
            {
                animations.SetBool("_isNotGrounded", !isGrounded);
            }
            if(Input.GetButtonDown("Jump") && (isGrounded || isWallJumped) && playerStats.stamina >= playerStats.staminaDecreaseRate * 100 * Time.deltaTime)
            {
                animations.SetTrigger(jumpHash);
                wallJumping = 1;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                playerStats.stamina -= playerStats.staminaDecreaseRate * 100 * Time.deltaTime ;
            }
            if(Input.GetButtonDown("Jump") && !isGrounded && isWallJumped && playerStats.stamina >= ((wallJumping +1 )* playerStats.wallJumpRate) * playerStats.staminaDecreaseRate * 100 * Time.deltaTime)
                    {
                        wallJumping ++;
                        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                        playerStats.stamina -= (wallJumping * playerStats.wallJumpRate) * (playerStats.staminaDecreaseRate * 100 * Time.deltaTime) ;
                    }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
         if(sheath){ 
            //attaque du joueur
            if (Input.GetAxis("Attack")!=0f)
            {
                Attack();
            }
            }
        }
        
        if (isAttacking)
        {
            // si le joueur attaque
            currentCooldown -= Time.deltaTime;
            // on baisse le cooldown de l'attaque
        }

        if (currentCooldown <= 0)
        {
            // si le cooldown revient a 0
            currentCooldown = attackCooldown;
            isAttacking = false;
        }

        if (Input.GetAxis("Draw Weapon")!=0f)
        {
            //jouer animation ranger armes 
            sheath = false;
        }
    }

    public void Attack()
    {
        isAttacking = true;
        // Jouer animation attaque
    }

}
