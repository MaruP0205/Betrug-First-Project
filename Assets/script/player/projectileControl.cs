using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D myBody; 
    Animation ani;

    private void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1,0)* bulletSpeed, ForceMode2D.Impulse);
        }else 
            myBody.AddForce(new Vector2(1,0)* bulletSpeed, ForceMode2D.Impulse);
        
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Tạo chức năng làm viên đạn dừng lại
    public void removeForce(){
        myBody.velocity = new Vector2(0,0);
    }    
}
