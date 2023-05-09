using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] private float CameraSpeed = 0.0f;


    void FixedUpdate(){

        float xVar = Input.GetAxis("Horizontal") * CameraSpeed * Time.deltaTime;
        float yVar = Input.GetAxis("Vertical") * CameraSpeed * Time.deltaTime;

        transform.position += new Vector3(xVar, yVar);
    }
}