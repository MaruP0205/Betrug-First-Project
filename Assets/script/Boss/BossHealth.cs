using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{   
    [Header("Health Boss")]
    [SerializeField]public float startingHealth; 
    public float currentHealth;
  
    [Header("Blood effect")]
    public GameObject bloodEffect;
    public Slider bossHealthSlider;

    [Header("Ground Hide")]
    public GameObject groundHide;

    public bool isInvulnerble = false;
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        bossHealthSlider.maxValue = startingHealth;
        bossHealthSlider.value = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInvulnerble)
            return;
    }
    public void addDamge(float damge){
        currentHealth = Mathf.Clamp(currentHealth - damge,0,startingHealth);
        bossHealthSlider.value = currentHealth;
        if(currentHealth <= 80){
            anim.SetTrigger("angry");
        }

        if(currentHealth > 0 ){
           anim.SetTrigger("hurt");
           
        }else {
            if (!dead)
            {   
                //anim.SetTrigger("die");
                Instantiate(bloodEffect, transform.position, transform.rotation);
                Destroy(gameObject);

                if (GetComponent<BossBehavior>() != null)    
                    GetComponent<BossBehavior>().enabled = false;

                dead = true;
                groundHide.SetActive(true);
                music_BossDie.bossDie();
            }
        }
    }
}
