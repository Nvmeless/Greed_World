using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth, maxThirst, maxHunger, maxStamina;
    public float thirstIncreaseRate, hungerIncreaseRate , staminaIncreaseRate, wallJumpRate;
    public float staminaDecreaseRate;
    public float thirstDamage, hungerDamage;
    public float health, thirst, hunger, stamina;
    public bool died;
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

    }
    public void Die()
            {
                died = true;
                print("You've died because of thirst o Hunger");
            }
}
