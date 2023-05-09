using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] private float CameraSpeed = 0.0f;

    [Header("Camera Height")]
    [SerializeField] private float ScrollWheelIntensity = 2f;
    [SerializeField] private Vector2 HeightBounds = new Vector2(3, 13);
    [SerializeField] private float HeightAdjustSpeed = 0.0f;

    private float HeightVar;

    void Awake(){

        HeightVar = Camera.main.fieldOfView;

    }

    void FixedUpdate(){

        float xVar = Input.GetAxis("Horizontal") * CameraSpeed * Time.deltaTime;
        float yVar = Input.GetAxis("Vertical") * CameraSpeed * Time.deltaTime;

        transform.position += new Vector3(xVar, yVar);
    }

    void Update(){

        HeightVar -= Input.mouseScrollDelta.y * ScrollWheelIntensity;
        HeightVar = Mathf.Clamp(HeightVar, HeightBounds.x, HeightBounds.y);
        float Height = Mathf.MoveTowards(Camera.main.fieldOfView, HeightVar, HeightAdjustSpeed);

        Camera.main.fieldOfView = Height;

    }
}