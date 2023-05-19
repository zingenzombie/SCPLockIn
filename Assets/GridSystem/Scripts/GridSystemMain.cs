using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemMain : MonoBehaviour
{
    [SerializeField] private Vector2Int GridSize;

    public GameObject GrassTile;

    public GameObject TileParent;

    public GameObject[,] TheGrid;

    public Color32 SelectionColor = Color.white;

    void Awake(){
        TheGrid = new GameObject[GridSize.x, GridSize.y];

        for(int i = 0; i < GridSize.x; i++){
            for(int j = 0; j < GridSize.y; j++){
                
                TheGrid[i,j] = Instantiate(GrassTile, new Vector3(i, j, 0), Quaternion.identity, TileParent.transform);

                TheGrid[i,j].transform.GetChild(0).GetComponent<TileControlFunctions>().SetCoordsAndGrid(new Vector2Int(i, j));
                
                Debug.Log(i + ", " + j + " block created.");
            }
        }

        Camera.main.transform.position = new Vector3(GridSize.x / 2.0f, GridSize.y / 2.0f, Camera.main.transform.position.z);
    }

    void Update(){

        //check for a raycast hit by the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            //Debug.Log(hit.transform.name);
        }

    }
}
