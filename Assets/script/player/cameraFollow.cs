using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float FollowSpeed = 2f;
    public float yOffset = 1f;    
    

    // Update is called once per frame
    private void Update()
    {
        Vector3 targetCamPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);

        transform.position = Vector3.Lerp(transform.position, targetCamPos, FollowSpeed * Time.deltaTime);

    }

}
