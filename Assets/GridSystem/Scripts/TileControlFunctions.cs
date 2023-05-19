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

    void Start(){

        Renderer = transform.GetComponent<MeshRenderer>();
        originalColor = Renderer.material.color;
        GridSystem = GameObject.Find("GridSystem").transform.GetComponent<GridSystemMain>();

    }

    public void SetCoordsAndGrid(Vector2Int coords){
        Coords = coords;
    }

    void OnMouseOver(){
        if(Input.GetMouseButton(0)){
            if(!BlockPlaced){

            BlockPlaced = true;
            
            Block = Instantiate(Blocks[0], transform.position, Quaternion.identity);
            Block.GetComponent<WallScript>().SetCoordsAndGrid(Coords);
            Block.GetComponent<WallScript>().CheckNear();

            Renderer.material.color = GridSystem.SelectionColor;
            clicked = true;
            StartCoroutine(offclick());

            }
        }
        else if(Input.GetMouseButton(1)){
            if(BlockPlaced){

                BlockPlaced = false;
                
                Destroy(Block);
                UpdateNearbyTiles();

                Renderer.material.color = GridSystem.SelectionColor;
                clicked = true;
                StartCoroutine(offclick());

            }
        }
    }

    void UpdateNearbyTiles(){
        GameObject[,] TheGrid = GameObject.Find("GridSystem").GetComponent<GridSystemMain>().TheGrid;
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

    private IEnumerator offclick(){
        var timeTemp = clickRemoveTime;
        while(timeTemp >= 0){
            timeTemp -= Time.deltaTime;
            yield return null;
        }
        clicked = false;
        Renderer.material.color = originalColor;
    }

    void OnMouseEnter(){
           Renderer.material.color = GridSystem.SelectionColor;
    }

    void OnMouseExit(){
            if(!clicked)
            Renderer.material.color = originalColor;
    }
}
