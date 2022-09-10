using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{   
    public float maxHealth;
    public float currentHealth;
    
    public GameObject bloodEffect;

    public Slider playerHealthSlider; 
    public gameOver gameover;

    public GameObject saved;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamge(float damge){
        if (damge <= 0)
        {
            return;
        }
        currentHealth -= damge;
        playerHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
            gameover.Setup();
        }
    }

    //Hoi mau khi an trai tym 
    public void addHealth(float healthAmmout){
        currentHealth += healthAmmout;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        playerHealthSlider.value = currentHealth;
    }

    void makeDead(){
        Instantiate(bloodEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        music_die.playerDie();
    }
    
    public void SavePlayer(){
        saveSystem.SavePlayer(this);
        saved.SetActive(true);
    }
    
    public void LoadPlayer(){
        playerData data = saveSystem.LoadPlayer();

        currentHealth = data.currentHealth;
        //Slider playerHealthSliderdata = data.playerHealthSliderdata;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }
}
