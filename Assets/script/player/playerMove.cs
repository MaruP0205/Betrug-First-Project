 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{   
    
    public float maxSpeed;
    public float jumpHeight;

    bool facingRight;
    bool grounded;

    public gameOver gameWin;
    //Khai báo biến bắn
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    Rigidbody2D myBody;
    Animator myAnim;
    // Start is called before the first frame update
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
        float shoot = Input.GetAxisRaw("Fire1");

        myAnim.SetFloat("speed", Mathf.Abs(move));
        myAnim.SetFloat("jump", Mathf.Abs(jump));
        myAnim.SetFloat("shoot", Mathf.Abs(shoot));
        
        myBody.velocity = new Vector2(move*maxSpeed, myBody.velocity.y);
        
        //di chuyển(move)
        if(move > 0 && !facingRight){
            flip();
        }else if(move < 0 && facingRight){
            flip();
        }
        
        //nhảy (jump)
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||Input.GetKey(KeyCode.Space)){
            if(grounded){
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
                music_jump.playerJump();
            }
        }

        //Chức năng bắn từ chuột
        if(Input.GetAxisRaw("Fire1")>0){
            fireBullet();
            
        }

    }
    private void flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Ground"){
            grounded = true;
        }

        if(coll.gameObject.tag == "Finish"){
            Debug.Log("Da Sang man 2");
            SceneManager.LoadScene("Man2");
        }

        if(coll.gameObject.tag == "Finish2"){
            Debug.Log("Da Sang man 3");
            SceneManager.LoadScene("Man3");
        }

        if(coll.gameObject.tag == "Finish3"){
            Debug.Log("Da hoan thanh game");
            gameWin.Setup();
            Time.timeScale = 0f;
        }
    }
    //Chức năng bắn
    private void fireBullet(){
        if(Time.time > nextFire){
            nextFire = Time.time + fireRate;
            if(facingRight){
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,0)));
            }else if(!facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,180)));
            }
            music_shoot.playerShoot();
        }
    }
}
