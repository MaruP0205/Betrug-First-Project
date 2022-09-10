using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    Vector3 offset;

    [SerializeField] float lowY;
    [SerializeField] float maxX, minX;
    
    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - target.position;
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY){
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        if(transform.position.x > maxX){
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        if(transform.position.x < minX){
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }
}
