using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamge : MonoBehaviour
{
    [SerializeField] protected float damge;
    float damgeRate = 0.5f;
    float nextDamge;

    // Start is called before the first frame update
    void Start()
    {
        nextDamge = 0f;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && nextDamge<Time.time)
        {
            playerHealth theplayerHealth = other.gameObject.GetComponent<playerHealth>();
            theplayerHealth.addDamge (damge);
            nextDamge = damgeRate + Time.time;
            
        }
    }
}
