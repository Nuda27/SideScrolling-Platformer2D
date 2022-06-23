using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool hit;
    private float direction;
    private float projectile_lifetime;
    private Animator anim;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
        //SetDirection(direction);
        projectile_lifetime += Time.deltaTime;
        if(projectile_lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D  collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().EnemyDamage(damage);
            
        }
    }

   public void SetDirection(float projectile_direction)
   {
       projectile_lifetime = 0;
       direction = projectile_direction;
       gameObject.SetActive(true);
       hit = false;
       boxCollider.enabled = true;

       float localScaleX = transform.localScale.x;
       if(Mathf.Sign(localScaleX) != projectile_direction)
       {
           localScaleX = -localScaleX;
       }

       transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
   }

    private void Deactivated()
    {
        gameObject.SetActive(false);
    }

    public void Damage()
    {
        damage = damage + 1;
    }
}
