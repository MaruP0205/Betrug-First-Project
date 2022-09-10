using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUD : MonoBehaviour
{
     public float moveSpeed;
    public Transform upLimit;
    public Transform downLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    private void Awake(){
        SelectTarget();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = new Vector2(transform.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(!InsideofLimits() && !inRange)
        {
            SelectTarget();
        }
    }
    private bool InsideofLimits(){
        return transform.position.y > upLimit.position.y && transform.position.y < downLimit.position.y;
    }
    public void SelectTarget(){
        float distanceToUp = Vector2.Distance(transform.position, upLimit.position);
        float distanceToDown = Vector2.Distance(transform.position, downLimit.position);

        if(distanceToUp > distanceToDown){
            target = upLimit;
        }else {
            target = downLimit;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision){
        collision.transform.SetParent(null);
    }
}
