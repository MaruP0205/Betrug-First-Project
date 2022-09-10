using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    [SerializeField]public float startingHealth; 
    public float currentHealth;
    private Animator anim;
    private bool dead;
    public GameObject bloodEffect;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamge(float damge){
        currentHealth = Mathf.Clamp(currentHealth - damge,0,startingHealth);
       
        if(currentHealth > 0 ){
           anim.SetTrigger("hurt");
           
        }else {
            if (!dead)
            {
                Instantiate(bloodEffect, transform.position, transform.rotation);
                Destroy(gameObject);

                if (GetComponentInParent<enemyPatrol>() != null)
                    GetComponentInParent<enemyPatrol>().enabled = false;

                if (GetComponent<ZombieEnemy>() != null)    
                    GetComponent<ZombieEnemy>().enabled = false;

                dead = true;
                music_zomdie.zombieDie();
            }
        }
    }
}
