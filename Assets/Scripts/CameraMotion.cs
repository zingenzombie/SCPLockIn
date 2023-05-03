using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private float horizontal;
    private float zoom;
    private float hSpeed = 0, vSpeed = 0;
    private float speedMax = 25;
    private float vertical;

    [SerializeField] private Rigidbody2D rb;

     void Start() {
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0){
            hSpeed += (float) .05;
        }
        else{
            hSpeed = 0;
        }

        if(vertical != 0){
            vSpeed += (float) .05;
        }
        else{
            vSpeed = 0;
        }

        if(hSpeed > speedMax || vSpeed > speedMax){
            hSpeed = speedMax;
            vSpeed = speedMax;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * hSpeed, vertical * vSpeed);
    }
}