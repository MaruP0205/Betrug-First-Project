using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthup : MonoBehaviour
{   
    public float healthAmmout;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Player"){
            playerHealth thePlayerHealth = collider.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addHealth(healthAmmout);
            Destroy(gameObject);
            music_hearth.healthup();
        }
    }
}
