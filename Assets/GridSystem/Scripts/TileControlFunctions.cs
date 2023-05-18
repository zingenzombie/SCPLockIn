using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{
    private MeshRenderer Renderer;

    private Color32 originalColor;

    public GridSystemMain GridSystem;

    private bool clicked = false;

    public float clickRemoveTime = 2.5f;

    public GameObject wall;

    void Start(){

        Renderer = transform.GetComponent<MeshRenderer>();
        originalColor = Renderer.material.color;
        GridSystem = GameObject.Find("GridSystem").transform.GetComponent<GridSystemMain>();

    }
    void OnMouseOver(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            
            Instantiate(wall, transform.position, Quaternion.identity);

            Renderer.material.color = GridSystem.SelectionColor;
            clicked = true;
            StartCoroutine(offclick());
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
