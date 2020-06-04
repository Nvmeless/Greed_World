using UnityEngine;

namespace Entities
{
    public class enemyAI : MonoBehaviour
    {
       //Distance entre le joueur et l'ennemi
    private float Distance;

    // Cible de l'ennemi
    public Transform Target;

    //Distance de poursuite
    public float chaseRange = 10;

    // Portée des attaques
    public float attackRange = 2.2f;

    // Cooldown des attaques
    public float attackRepeatTime = 1;
    private float attackTime;

    // Montant des dégâts infligés
    public float TheDammage;

    // Agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    // Animations de l'ennemi
    private Animator anime;

    // Vie de l'ennemi
    public float enemyHealth;
    private bool isDead = false;

    void Start()
    {
        anime = GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();        
        attackTime = Time.time;
    }



    void Update()
    {

        if (!isDead)
        {

            // On cherche le joueur en permanence
            Target = GameObject.Find("Player").transform;

            // On calcule la distance entre le joueur et l'ennemi, en fonction de cette distance on effectue diverses actions
            Distance = Vector3.Distance(Target.position, transform.position);

            // Quand l'ennemi est loin = idle pas besoin l'animator le joue tout seul
           
            

            // Quand l'ennemi est proche mais pas assez pour attaquer
            if (Distance < chaseRange && Distance > attackRange)
            {
                chase();
            }
            else
            {
                anime.SetFloat("_speed", 0f);
            }

            // Quand l'ennemi est assez proche pour attaquer
            if (Distance < attackRange)
            {
                attack();
            }

        }
    }

    // poursuite
    void chase()
    {
        anime.SetFloat("_speed", 1f);
        agent.destination = Target.position;
    }

    // Combat
    void attack()
    {
        // empeche l'ennemi de traverser le joueur
        agent.destination = transform.position;

        //Si pas de cooldown
        if (Time.time > attackTime)
        {
            //anime.SetTrigger("_hit");
            Target.GetComponent<PlayerInventory>().ApplyDamage(TheDammage);
            Debug.Log("L'ennemi a envoyé " + TheDammage + " points de dégâts");
            attackTime = Time.time + attackRepeatTime;
        }
    }

  
    public void ApplyDammage(float TheDammage)
    {
        if (!isDead)
        {
            enemyHealth = enemyHealth - TheDammage;
            print(gameObject.name + "a subit " + TheDammage + " points de dégâts.");

            if (enemyHealth <= 0)
            {
                Dead();
            }
        }
    }

    public void Dead()
    {
        isDead = true;
        //anime.SetTrigger("_death");
        Destroy(transform.gameObject, 5);
    }
}  
    }
