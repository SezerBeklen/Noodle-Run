using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;



    Rigidbody rb;
    public float speed;
    public float rotationDuration;
    public float Distance;
    GameObject finishObject;
    public GameObject character;
    public GameObject HoldPoint;
     
  
    private void Start()
    {
        finishObject = GameObject.FindGameObjectWithTag("Finish");
        rb = GetComponent<Rigidbody>();
         
    }





    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }





        character.transform.position = new Vector3(gameObject.transform.position.x, character.transform.position.y, gameObject.transform.position.z-0.19f);
         gameObject.transform.position += Vector3.forward*Time.deltaTime*speed;
        
        Distance = Vector3.Distance(gameObject.transform.position, finishObject.transform.position);
        if (Distance <= transform.localScale.y)
        {
            speed = 0;
            
            gameObject.transform.parent = finishObject.transform;
            gameObject.transform.localPosition = new Vector3(0, 0.5f, gameObject.transform.localPosition.z);
            character.transform.position = HoldPoint.transform.position;

            gameObject.transform.DOLocalRotate(new Vector3(90, 0, 0), rotationDuration, RotateMode.Fast);
            Invoke("NoodleJump", 0.5f);
            //  transform.RotateAround 
            /* character.transform.parent = gameObject.transform;
           if (character.transform.parent != null)
           {
               // character.transform.position = new Vector3(character.transform.localPosition.x, character.transform.localPosition.y, character.transform.localPosition.z-calculate);
               character.transform.localPosition = new Vector3(0, 0, 0);
               speed = 0;
           }*/
        }
    }




    void NoodleJump()
    {
        finishObject.gameObject.transform.DOLocalRotate(new Vector3(120, 0, 0), 2f, RotateMode.Fast);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("jumpend"))
        {
            gameObject.transform.parent = null;
            gameObject.transform.DOLocalRotate(new Vector3(0, 0, 90), rotationDuration, RotateMode.Fast);
            //character.transform.position = new Vector3(gameObject.transform.position.x, character.transform.position.y, gameObject.transform.position.z - 0.19f);
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+0.9f, transform.position.z);
            speed = 4;
            
            Debug.Log("karakter etkileþimde");
        }
    }

}
