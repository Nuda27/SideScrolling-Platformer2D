using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth {get; private set;}
    public GameObject Dialog;
    private Animator anim;
    private bool dead;
    // Start is called before the first frame update
    void Awake()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E))
        // {
        //     TakeDamage(1);
        // }
    }

    public void TakeDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, startingHealth);
        if(currHealth > 0)
        {
            anim.SetTrigger("hurt");
            //suaraterkena hit
            //currHealth -= damage;
        }
        else 
        {
                anim.SetTrigger("die");
                //Destroy(gameObject);
                //Time.timeScale = 0;
                SoundManager.instance.LoseSfx();
                Dialog.SetActive(true);
                GetComponent<PlayerMovement>().enabled = false;

                // if(GetComponentInParent<MovementToPlayer>() != null)
                // GetComponentInParent<MovementToPlayer>().enabled = false;

                // if(GetComponent<Enemy_Melee>() != null)
                // GetComponent<Enemy_Melee>().enabled = false;
                // dead = true;
        }
    }

    public void EnemyDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, startingHealth);
        if(currHealth > 0)
        {
            anim.SetTrigger("hurt");
            //currHealth -= damage;
        }
        else 
        {
                anim.SetTrigger("die");
                //Destroy(gameObject);
                //Time.timeScale = 0;
                Dialog.SetActive(true);
                GetComponent<Collider2D>().enabled = false;
        }
    }

    public void AddHealth(float value)
    {
        currHealth = Mathf.Clamp(currHealth + value, 0, startingHealth);
    }
}
