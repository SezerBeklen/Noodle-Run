using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public bool temas;
    public float scalesize;
    public float objectHeight;
   

    public void Cut(Transform knife)
    {
        if (knife.transform.position.x < 0)
        {
            float y = transform.localScale.y;
            y -= transform.position.x;
            float dist = y + knife.position.x;
            Debug.Log("dist :" + dist);

            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + dist / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(-(y - yeni.transform.localScale.y), transform.position.y, transform.position.z);
                yeni.AddComponent<Rigidbody>();



            }


        }
        else
        {

            float y = transform.localScale.y;  //y=3  3+2=5  dist= 3-2 =1
            y += transform.position.x;
            float dist = y - knife.position.x;
            Debug.Log("dist :" + dist);

            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - dist / 2, transform.position.y, transform.position.z);

                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                yeni.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                yeni.transform.rotation = transform.rotation;
                yeni.transform.position = new Vector3(y - yeni.transform.localScale.y, transform.position.y, transform.position.z);
                yeni.AddComponent<Rigidbody>();



            }

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("saw"))
        {
            Cut(other.gameObject.transform);
        }


        if (other.gameObject.CompareTag("scalesize"))
        {
            other.gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + scalesize, transform.localScale.z);
            objectHeight += 0.2f;
           
        }

        
    }

 
}
