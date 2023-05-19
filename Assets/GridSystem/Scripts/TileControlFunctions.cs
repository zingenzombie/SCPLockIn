using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{
    private MeshRenderer Renderer;

    private Color32 originalColor;

    private bool BlockPlaced = false;

    public GridSystemMain GridSystem;

    private bool clicked = false;

    public float clickRemoveTime = 2.5f;

    public GameObject wall;

    public GameObject Block;

    void Start(){

        Renderer = transform.GetComponent<MeshRenderer>();
        originalColor = Renderer.material.color;
        GridSystem = GameObject.Find("GridSystem").transform.GetComponent<GridSystemMain>();

    }
    void OnMouseOver(){
        if(Input.GetMouseButton(0)){
            if(!BlockPlaced){

            BlockPlaced = true;
            
            Block = Instantiate(wall, transform.position, Quaternion.identity);

            Renderer.material.color = GridSystem.SelectionColor;
            clicked = true;
            StartCoroutine(offclick());

            }
        }
        else if(Input.GetMouseButton(1)){
            if(BlockPlaced){

            BlockPlaced = false;
            
            Destroy(Block);

            Renderer.material.color = GridSystem.SelectionColor;
            clicked = true;
            StartCoroutine(offclick());

            }
        }
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
