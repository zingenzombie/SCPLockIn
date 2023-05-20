using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemMain : MonoBehaviour
{
    [SerializeField] private Vector2Int GridSize;

    public GameObject GridGround;

    public GameObject selectionTile;

    private Dictionary<Vector2, GameObject> TileLocations;

    void Awake()
    {

        var Renderer = GridGround.GetComponent<MeshRenderer>();
        Renderer.material.SetVector("_Tiles", new Vector4(GridSize.x, GridSize.y, 0, 0));
        GridGround.transform.localScale = new Vector3(GridSize.x / 10, 1, GridSize.y / 10);

        Camera.main.transform.position = new Vector3(GridGround.transform.position.x, Camera.main.transform.position.z, GridGround.transform.position.y);

        for(int i = 0; i < GridSize.x; i++){
            for(int j = 0; j < GridSize.y; j++){

                //TileLocations.Add(new Vector2(i, j), Instantiate()

                Debug.Log(i + ", " + j + " block created.");
            }
        }
    }

    private Vector3 currentSelectedTileLocation;
    private float xPoint, yPoint;
    void Update()
    {
        
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
}
