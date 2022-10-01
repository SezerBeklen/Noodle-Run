using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swervemovement : MonoBehaviour
{
    private Movement _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
 
    private void Awake()
    {
        _swerveInputSystem = GetComponent<Movement>();
    }

    private void Update()
    {
        

        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(0, -swerveAmount, 0);
    }
}
