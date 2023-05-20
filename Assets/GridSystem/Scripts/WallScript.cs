using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    
    public string BlockName;

    private Vector2Int Coords;

    public bool[] NSEW;

    public bool Updating = false;

    private Vector2Int[] Offsets = new Vector2Int[4];

    private GameObject[,] TheGrid;

    // Start is called before the first frame update
    void Awake()
    {
        NSEW = new bool[4];
        for(int i = 0; i < 4; i++){
            NSEW[i] = false;
        }

        Offsets[0] = new Vector2Int(0,1);
        Offsets[1] = new Vector2Int(0,-1);
        Offsets[2] = new Vector2Int(-1,0);
        Offsets[3] = new Vector2Int(1,0);
    }

    public void SetCoordsAndGrid(Vector2Int coords, ref GameObject[,] TheGrid)
    {
        Coords = coords;
        this.TheGrid = TheGrid;
    }

    //This function is called to update the visual representation of the block when updated.
    public void CheckNear(){

        Updating = true;

        for(int i = 0; i < 4; i++){
            try{
                if(TheGrid[Coords.x + Offsets[i].x, Coords.y + Offsets[i].y].transform.GetChild(0).GetComponent<TileControlFunctions>().BlockPlaced != NSEW[i]){
                    NSEW[i] = !NSEW[i];
                    if(!TheGrid[Coords.x + Offsets[i].x, Coords.y + Offsets[i].y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().Updating){
                        TheGrid[Coords.x + Offsets[i].x, Coords.y + Offsets[i].y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
                    }
                }
            }catch{}

        }

        Updating = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
