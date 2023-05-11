using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomColor : MonoBehaviour
{
    private Color32 Green1 = new Color32(88, 171,90,255);
    private Color Green2 = new Color32(95, 183, 97, 255);
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color32.Lerp(Green1, Green2, Random.Range(0.0f, 1.0f));
    }

    
}
