using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour
{
    [SerializeField] private float RotateSpeed;
    void FixedUpdate(){

        transform.RotateAround(transform.position, transform.forward, RotateSpeed * Time.deltaTime);

    }
}
