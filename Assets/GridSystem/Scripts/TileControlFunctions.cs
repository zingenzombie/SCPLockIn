using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{
    private MeshRenderer Renderer;

    private Color32 originalColor;

    public Vector2Int Coords;

    public bool BlockPlaced = false;

    public GridSystemMain GridSystem;

    private bool clicked = false;

    public float clickRemoveTime = 2.5f;

    public GameObject[] Blocks;

    public GameObject Block;

    private GameObject[,] TheGrid;

    void Start(){

        Renderer = transform.GetComponent<MeshRenderer>();
        originalColor = Renderer.material.color;
        GridSystem = GameObject.Find("GridSystem").transform.GetComponent<GridSystemMain>();

    }

    public void SetCoordsAndGrid(Vector2Int coords, ref GameObject[,] TheGrid)
    {
        Coords = coords;
        this.TheGrid = TheGrid;
    }

    void OnMouseOver(){
        if(Input.GetMouseButton(0)){
            if(!BlockPlaced){

            BlockPlaced = true;
            
            Block = Instantiate(Blocks[0], transform.position, Quaternion.identity);
            Block.GetComponent<WallScript>().SetCoordsAndGrid(Coords, ref TheGrid);
            Block.GetComponent<WallScript>().CheckNear();
        }
        else if(Input.GetMouseButton(1)){
            if(BlockPlaced){

                BlockPlaced = false;
                
                Destroy(Block);
                UpdateNearbyTiles();
            }
        }
    }
    }

    void UpdateNearbyTiles(){
        try{
        TheGrid[Coords.x, Coords.y + 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
        try{
        TheGrid[Coords.x, Coords.y - 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
        try{
        TheGrid[Coords.x - 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
        try{
        TheGrid[Coords.x + 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
    }
}
