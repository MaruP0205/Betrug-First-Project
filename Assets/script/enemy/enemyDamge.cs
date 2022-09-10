using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamge : MonoBehaviour
{
    [SerializeField] protected float damge;
    float damgeRate = 0.5f;
    float pushBackForce;
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

            pushBack(other.transform);
        }
    }
    void pushBack(Transform pushedObject){
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
