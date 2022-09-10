using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateHealth : MonoBehaviour
{
    public float maxHealth; 
    float currentHealth;

    public bool drop;
    public GameObject theDrop;

    void Start()
    {
        currentHealth = maxHealth;   
     
    }

    public void addDamge(float damge){
        currentHealth -= damge;
       
        if(currentHealth<=0){
            makeDead();
           
        }
    }
    void makeDead(){
        Destroy(gameObject);
        
        if(drop){
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}
