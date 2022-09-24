using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{   
    public GameObject textSave;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            
            textSave.SetActive(true);
        }
    }
}
