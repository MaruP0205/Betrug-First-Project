using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class playerData
{
    public float currentHealth;
    public float[] position;
    //public float playerHealthSliderdata;

    public playerData(playerHealth playerH){
        currentHealth = playerH.currentHealth;
        //playerHealthSliderdata = playerH.playerHealthSlider;

        position = new float[2];
        position[0] = playerH.transform.position.x;
        position[1] = playerH.transform.position.y;
    }

}
