using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoodleControl : MonoBehaviour
{
    
    public float rotationDuration;
    public float Distance;

    public Movement mov;
    public Transform character;
    public Transform HoldPoint;
    private GameObject finishObject;
    public Transform noodlePoint;
    
    void Start()
    {
        finishObject = GameObject.FindGameObjectWithTag("Finish");
    }

    
    void FixedUpdate()
    {
        
        Distance = Vector3.Distance(gameObject.transform.position, finishObject.transform.position);

        if (Distance <= gameObject.transform.localScale.y) 
        {
             mov.speed = 0;
             transform.parent = finishObject.transform;
             transform.localPosition = new Vector3(0, 0.5f, transform.localPosition.z);
             transform.DOLocalRotate(new Vector3(90, 0, 0), rotationDuration, RotateMode.Fast);
            // character.transform.position = new Vector3(character.transform.position.x,   transform.localScale.y, transform.position.z - transform.localScale.y);
            Invoke("NoodleJump", 0.6f);
        }
    }


    void NoodleJump()
    {  
        finishObject.gameObject.transform.DOLocalRotate(new Vector3(120, 0, 0), 2f, RotateMode.Fast);
        
    }



   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jumpend"))
        {

            if (transform.parent != null)
            {
                gameObject.transform.parent = null;
                
            }
             
            gameObject.transform.DOLocalRotate(new Vector3(0, 0, 90), rotationDuration, RotateMode.Fast);
           
             gameObject.transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            gameObject.transform.parent = mov.gameObject.transform;

            mov.speed = 4;

            Debug.Log("karakter etkileþimde");
        }
    }*/


   
        
    
}
