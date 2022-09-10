using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackDamge;
    public float angryAttackDamge;

    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask attackMask;

    public void Attack(){
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D collInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(collInfo != null){
            collInfo.GetComponent<playerHealth>().addDamge(attackDamge);
        }
    }

    public void AngryAttack(){
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D collInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(collInfo != null){
            collInfo.GetComponent<playerHealth>().addDamge(angryAttackDamge);
        }
    }
}
