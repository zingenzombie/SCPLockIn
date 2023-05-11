using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{

    public Color32 originalColor;
    private SpriteRenderer Renderer;

    private bool clicked = false;

    void Start(){

        Renderer = transform.GetComponent<SpriteRenderer>();

    }
    void OnMouseOver(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Renderer.color = Color.white;
            clicked = true;
            StartCoroutine(Returncolor());
        }
    }

    private IEnumerator Returncolor(){
        yield return new WaitForSeconds(2.5f);
        Renderer.color = originalColor;
        clicked = false;
    }

    void OnMouseEnter(){
        if(originalColor.a == 0)
            originalColor = Renderer.color;
            Renderer.color = Color.white;
    }

    void OnMouseExit(){
            if(!clicked)
            Renderer.color = originalColor;
    }
}
