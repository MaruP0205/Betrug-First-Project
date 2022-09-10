using System.Collections;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{   
    [Header ("Attacak Parameter")]
    [SerializeField]private float attackCooldown;
    [SerializeField]private float range;
    [SerializeField]private int damge;
    
    [Header ("Collider Parameter")]
    [SerializeField]private float colliderDistance;
    [SerializeField]private BoxCollider2D boxCollider;

    [Header ("Player layer")]
    [SerializeField]private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private playerHealth player_Health;

    private enemyPatrol enemyPatrol;

    private void Awake(){
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrol>();
    }

    private void Update(){
        cooldownTimer += Time.deltaTime;
        
        //Tan khong khi nguoi choi trong tam
        if(PlayerInSight()){
            if (cooldownTimer >= attackCooldown){
                //Tan cong 
                cooldownTimer = 0;
                anim.SetTrigger("attack");

            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        ,0, Vector2.left, 0, playerLayer);

        if(hit.collider != null){
            player_Health = hit.transform.GetComponent<playerHealth>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer(){
        //Neu nguoi choi van o trong tam 
        if (PlayerInSight())
        {
            player_Health.addDamge(damge);
        }
    }
}
