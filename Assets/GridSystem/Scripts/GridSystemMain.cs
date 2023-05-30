using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridSystemMain : MonoBehaviour
{
    [SerializeField] public Vector2Int GridSize;

    public GameObject GridGround;

    public GameObject selectionTile;

    private Vector3 currentSelectedTileLocation;
    private int xPoint, yPoint;

    public GameObject Wall;

    private GameObject[,] TheGrid;

    private Vector2Int[] Offsets = new Vector2Int[4];

    public NavMeshSurface surface;

    void Awake()
    {
        TheGrid = new GameObject[GridSize.x, GridSize.y];

        var Renderer = GridGround.GetComponent<MeshRenderer>();
        Renderer.material.SetVector("_Tiles", new Vector4(GridSize.x, GridSize.y, 0, 0));
        GridGround.transform.localScale = new Vector3(GridSize.x / 10.0f, 1, GridSize.y / 10.0f);
        GridGround.transform.Translate(GridSize.x / 2.0f, 0, GridSize.y / 2.0f);

        Offsets[0] = new Vector2Int(0, -1);
        Offsets[1] = new Vector2Int(0, 1);
        Offsets[2] = new Vector2Int(-1, 0);
        Offsets[3] = new Vector2Int(1, 0);

        surface.BuildNavMesh();
    }


    void FixedUpdate(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
        {
                int newXpoint = (int) Mathf.Ceil(hit.point.x) - 1;
                int newYpoint = (int) Mathf.Ceil(hit.point.z) - 1;
                if(newXpoint != xPoint){
                    xPoint = newXpoint;
                    ChangeSelection();
                }
                if(newYpoint != yPoint){
                    yPoint = newYpoint;
                    ChangeSelection();
                }
        }
        else
        {
                selectionTile.SetActive(false);
            }
    }


    private void ChangeSelection(){
        selectionTile.SetActive(true);
        selectionTile.transform.position = new Vector3(xPoint + .5f, 0, yPoint + .5f);
    }

    public void PlaceWall(){
        if (TheGrid[xPoint, yPoint] == null)
        {
            TheGrid[xPoint, yPoint] = Instantiate(Wall, new Vector3(xPoint + .5f, 0, yPoint + .5f), Quaternion.identity);
            TheGrid[xPoint, yPoint].GetComponent<TileControlFunctions>().InitObj(new Vector2Int(xPoint, yPoint), ref TheGrid);
            CheckNearSurroundings(xPoint, yPoint);
        }
    }

    public void BreakWall()
    {
        if (TheGrid[xPoint, yPoint] != null)
        {
            Destroy(TheGrid[xPoint, yPoint]);

            try
            {
                TheGrid[xPoint + Offsets[0].x, yPoint + Offsets[0].y].GetComponent<TileControlFunctions>().NSEW_Walls[1].active = false;
            }
            catch { }
            try
            {
                TheGrid[xPoint + Offsets[1].x, yPoint + Offsets[1].y].GetComponent<TileControlFunctions>().NSEW_Walls[0].active = false;
            }
            catch { }
            try
            {
                TheGrid[xPoint + Offsets[2].x, yPoint + Offsets[2].y].GetComponent<TileControlFunctions>().NSEW_Walls[3].active = false;
            }
            catch { }
            try
            {
                TheGrid[xPoint + Offsets[3].x, yPoint + Offsets[3].y].GetComponent<TileControlFunctions>().NSEW_Walls[2].active = false;
            }
            catch { }

        }
    }

    public void CheckNearSurroundings(int x, int y)
    {

        TheGrid[x, y].GetComponent<TileControlFunctions>().Updating = true;

        for (int i = 0; i < 4; i++)
        {
            try
            {


                if (!TheGrid[x + Offsets[i].x, y + Offsets[i].y].GetComponent<TileControlFunctions>().Updating &&
                    TheGrid[x, y].GetComponent<TileControlFunctions>().NSEW_Walls[i].active !=
                    TheGrid[x + Offsets[i].x, y + Offsets[i].y].GetComponent<TileControlFunctions>().BlockPlaced)
                {
                    CheckNearSurroundings(x + Offsets[i].x, y + Offsets[i].y);
                }

                TheGrid[x, y].GetComponent<TileControlFunctions>().NSEW_Walls[i].active =
                    TheGrid[x + Offsets[i].x, y + Offsets[i].y].GetComponent<TileControlFunctions>().BlockPlaced;
            }
            catch { TheGrid[x, y].GetComponent<TileControlFunctions>().NSEW_Walls[i].active = false; }

        }

        TheGrid[x, y].GetComponent<TileControlFunctions>().Updating = false;
    }
}