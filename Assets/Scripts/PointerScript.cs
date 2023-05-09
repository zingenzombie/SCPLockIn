using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    [SerializeField] private float _distance;
    private float _rotationSpeed = 20f;
    private Vector3 _horizontalMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = new Vector3(0f, 0f, -Input.GetAxis("Horizontal"));

        transform.Rotate(_horizontalMovement * _rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) == Input.GetKey(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), _distance);

            if (hit)
            {
                Debug.Log("Hit " + hit.collider.name);
            }
        }
    }
}
