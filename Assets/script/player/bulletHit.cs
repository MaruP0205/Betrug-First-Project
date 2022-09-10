using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{   
    
    projectileControl myPC;
    public GameObject bulletExplosion;

    void Awake(){
        myPC = GetComponentInParent<projectileControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Shootable"){
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("crate"))
                other.GetComponent<crateHealth>().addDamge(10);
        }
        if(other.gameObject.tag == "Enemy"){
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy")){
                other.GetComponent<enemyHealth>().addDamge(10);
                
            }
        }
        if(other.gameObject.tag == "Boss"){
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("boss"))
                other.GetComponent<BossHealth>().addDamge(10);
        }
    }
}
