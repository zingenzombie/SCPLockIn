using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject GridSystem;

    public void SetColor(){

        GridSystem.GetComponent<GridSystemMain>().SelectionColor = this.GetComponent<RawImage>().color;

    }

}
