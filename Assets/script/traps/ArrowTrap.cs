using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arraws;
    private float cooldownTimer;

    private void Attack(){
        cooldownTimer = 0;

        arraws[FindArrow()].transform.position = firePoint.position;
        arraws[FindArrow()].GetComponent<EnemyProjectile>().ActiveProjectile();
    }

    private int FindArrow(){
        for (int i = 0; i < arraws.Length; i++)
        {
            if(!arraws[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    
    private void Update(){
        cooldownTimer += Time.deltaTime;
        
        if (cooldownTimer >= attackCooldown){
            Attack();
        }
    }
}
