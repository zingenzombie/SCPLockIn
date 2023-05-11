using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{

    public Color32 originalColor;
    private SpriteRenderer Renderer;

    public GridSystemMain GridSystem;

    private bool clicked = false;

    public float clickRemoveTime = 2.5f;

    void Start(){

        Renderer = transform.GetComponent<SpriteRenderer>();
        GridSystem = GameObject.Find("GridSystem").transform.GetComponent<GridSystemMain>();

    }
    void OnMouseOver(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Renderer.color = GridSystem.SelectionColor;
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
        Renderer.color = originalColor;
    }

    void OnMouseEnter(){
            Renderer.color = GridSystem.SelectionColor;
    }

    void OnMouseExit(){
            if(!clicked)
            Renderer.color = originalColor;
    }
}
