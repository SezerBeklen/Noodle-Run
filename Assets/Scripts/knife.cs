using System.Collections;
using EzySlice;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public Material slicedSidematerial;
    public float explosionForce;
    public float explosionRadius;
    public bool gravity, kinematic;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanSlice"))
        {
            SlicedHull sliceobj = Slice(other.gameObject, slicedSidematerial);
            GameObject SlicedObjTop = sliceobj.CreateUpperHull(other.gameObject, slicedSidematerial);
            GameObject SlicedObjDown = sliceobj.CreateLowerHull(other.gameObject, slicedSidematerial);
            Destroy(other.gameObject);
            
        }
    }
    private SlicedHull Slice(GameObject obj ,Material mat)
    {
        return obj.Slice(transform.position, transform.up, mat);
    }
}
