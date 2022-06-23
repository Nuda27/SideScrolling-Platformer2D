using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    //Untuk fireball
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float distanceCollider;
    [SerializeField] private LayerMask enemyLayer;
    private Health enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B) && cooldownTimer > attackCooldown)
        {
            Attack();
        }
        if(Input.GetKey(KeyCode.V) && cooldownTimer > attackCooldown)
        {
            meleeAttack();
        }
        //cooldownTimer += Time.deltaTime;
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        //suarafireball
        SoundManager.instance.FireballSfx();
        fireballs[CheckFireball()].transform.position = firePoint.position;
        fireballs[CheckFireball()].GetComponent<ProjectTile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    
    public void meleeAttack()
    {
        anim.SetTrigger("strike");
        cooldownTimer = 0;
        //suaraAttack
        SoundManager.instance.MeleeSfx();
    }

    private int CheckFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool CheckEnemy()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, enemyLayer); 
        if(hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * distanceCollider, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)); 
    }

    private void DamageEnemy()
    {
        if (CheckEnemy())
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    public void Damage()
    {
        damage = damage +1;
    }
}

