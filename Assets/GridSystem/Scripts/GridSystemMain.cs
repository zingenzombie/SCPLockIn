using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemMain : MonoBehaviour
{
    [SerializeField] private Vector2 GridSize;

    public GameObject GrassTile;

    public GameObject TileParent;

    void Start(){
        for(int i = 0; i < GridSize.x; i++){
            for(int j = 0; j < GridSize.y; j++){
                Instantiate(GrassTile, new Vector3(i, j, 0), Quaternion.identity, TileParent.transform);
            }
        }

        Camera.main.transform.position = new Vector3(GridSize.x / 2.0f, GridSize.y / 2.0f, -75);
    }
}
