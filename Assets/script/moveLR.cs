using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLR : MonoBehaviour
{   
    public float moveSpeed;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    private void Awake(){
        SelectTarget();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(!InsideofLimits() && !inRange)
        {
            SelectTarget();
        }
    }
    private bool InsideofLimits(){
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
    public void SelectTarget(){
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight){
            target = leftLimit;
        }else {
            target = rightLimit;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision){
        collision.transform.SetParent(null);
    }
}
