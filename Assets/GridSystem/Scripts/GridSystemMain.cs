using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemMain : MonoBehaviour
{
    [SerializeField] private Vector2 GridSize;

    public GameObject GridGround;

    public GameObject selectionTile;

    private Vector3 currentSelectedTileLocation;
    private float xPoint, yPoint;

    public GameObject Wall;

    void Awake()
    {
        var Renderer = GridGround.GetComponent<MeshRenderer>();
        Renderer.material.SetVector("_Tiles", new Vector4(GridSize.x, GridSize.y, 0, 0));
        GridGround.transform.localScale = new Vector3(GridSize.x / 10, 1, GridSize.y / 10);

        Camera.main.transform.position = new Vector3(GridGround.transform.position.x, Camera.main.transform.position.z, GridGround.transform.position.y);
    }


    void FixedUpdate(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var newXpoint = Mathf.Ceil(hit.point.x) - .5f;
                var newYpoint = Mathf.Ceil(hit.point.z) - .5f;
                if(newXpoint != xPoint){
                    xPoint = newXpoint;
                    ChangeSelection();
                }
                if(newYpoint != yPoint){
                    yPoint = newYpoint;
                    ChangeSelection();
                }
            }
            else{
                selectionTile.SetActive(false);
            }
    }


    private void ChangeSelection(){
        selectionTile.SetActive(true);
        selectionTile.transform.position = new Vector3(xPoint, 0, yPoint);
    }

    public void PlaceWall(){
        var obj = Instantiate(Wall, new Vector3(xPoint, 0, yPoint), Quaternion.identity);
        obj.GetComponent<TileControlFunctions>().InitObj();
    }
}
