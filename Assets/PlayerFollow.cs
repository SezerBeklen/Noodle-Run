using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 Offset;
    public float smoothSpeed = 0.125f;
    // Update is called once per frame
    void LateUpdate()
    {

        // gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+3, player.transform.position.z-4);
        Vector3 desiredPosition = player.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

    }
}
