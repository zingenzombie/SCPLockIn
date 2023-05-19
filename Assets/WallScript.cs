using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    
    public string BlockName;

    private Vector2Int Coords;

    public bool[] NSEW;

    public bool Updating = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetCoordsAndGrid(Vector2Int coords){
        Coords = coords;
    }

    public void CheckNear(){
        NSEW = new bool[4];

        Updating = true;
        
        GameObject[,] TheGrid = GameObject.Find("GridSystem").GetComponent<GridSystemMain>().TheGrid;

        try{
            if(TheGrid[Coords.x, Coords.y + 1].transform.GetChild(0).GetComponent<TileControlFunctions>().BlockPlaced){
                NSEW[0] = true;
                if(!TheGrid[Coords.x, Coords.y + 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().Updating){
                    TheGrid[Coords.x, Coords.y + 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
                }
            }
        }catch{}

        try{
            if(TheGrid[Coords.x, Coords.y - 1].transform.GetChild(0).GetComponent<TileControlFunctions>().BlockPlaced){
                NSEW[1] = true;
                if(!TheGrid[Coords.x, Coords.y - 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().Updating){
                    TheGrid[Coords.x, Coords.y - 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
                }
            }
        }catch{}

        try{
            if(TheGrid[Coords.x - 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().BlockPlaced){
                NSEW[2] = true;
                if(!TheGrid[Coords.x - 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().Updating){
                    TheGrid[Coords.x - 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
                }
            }
        }catch{}

        try{
            if(TheGrid[Coords.x + 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().BlockPlaced){
                NSEW[3] = true;
                if(!TheGrid[Coords.x + 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().Updating){
                    TheGrid[Coords.x + 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
                }
            }
        }catch{}

        Updating = false;

        Debug.Log("MEEP");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
