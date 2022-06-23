using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickUp : MonoBehaviour
{
    //[SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerAttack>().Damage();
            //collision.GetComponent<ProjectTile>().Damage();
            //suaraPickUp
            SoundManager.instance.PickUpSfx();
            gameObject.SetActive(false);
        }
    }
}
