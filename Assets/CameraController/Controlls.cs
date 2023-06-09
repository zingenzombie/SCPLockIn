using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    [Header("Zoom Features")]
    [SerializeField] private float ZoomIntensity = 2.5f;
    [SerializeField] private Vector2 ZoomBounds = new Vector2(5, 120);

    [Header("Moving Features")]
    [SerializeField] private float MoveSpeed;

    private float ZoomVar = 75;
    private float xVar;
    private float yVar;

    public GameObject TheGrid;

    void Start()
    {

        transform.position = new Vector3(TheGrid.GetComponent<GridSystemMain>().GridSize.x / 2.0f, 10, TheGrid.GetComponent<GridSystemMain>().GridSize.y / 2.0f);

        xVar = transform.position.x;
        yVar = transform.position.z;

    }
    void Update()
    {
        //adding in camera scrolling
        ZoomVar -= Input.mouseScrollDelta.y * ZoomIntensity;
        xVar += Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
        yVar += Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime;

        ZoomVar = Mathf.Clamp(ZoomVar, 7.5f, 110f);

        transform.position = new Vector3(xVar, ZoomVar, yVar);
    }
}
