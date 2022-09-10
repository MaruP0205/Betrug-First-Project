using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{   
    [SerializeField]private float damage;

    [Header ("FireTrap Timers")]
    [SerializeField]private float activationDelay;
    [SerializeField]private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool triggered; //Khi bẫy kích hoạt
    private bool active;    //Khi cái bẫy hoạt động và có thể đã thương nhân vật

    private void Awake(){
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Player"){
            if(!triggered)
                StartCoroutine(ActiveFiretrap());
            
            if(active)
                collider.GetComponent<playerHealth>().addDamge(damage);
            
        }
    }

    private IEnumerator ActiveFiretrap(){
        //chuyển sprite màu đỏ để thông báo cho người chơi và kích hoạt bẫy
        triggered = true;
        spriteRenderer.color = Color.red; 

        //Đợi delay, kích hoạt bẫy và hoạt ảnh bẫy
        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.color = Color.white; //biến sprite trở lại màu ban đầu
        active = true;
        anim.SetBool("activated",true);
        
        //Đợi trong khoảng X time, hủy kích hoạt bẫy và reset all giá trị
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated",false);
    }

}
 