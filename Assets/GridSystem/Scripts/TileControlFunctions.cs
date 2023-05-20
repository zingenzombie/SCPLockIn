using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{
    private MeshRenderer Renderer;

    private Color32 originalColor;

    public Vector2Int Coords;

    public bool BlockPlaced = false;

    public GridSystemMain GridSystem;

    private bool clicked = false;

    public float clickRemoveTime = 2.5f;

    public GameObject[] Blocks;

    public GameObject Block;

    private GameObject[,] TheGrid;

    public AudioClip[] SoundPlacedNoises;

    private System.Random SoundPlacedRandom = new System.Random();

    void Start(){

        Renderer = transform.GetComponent<MeshRenderer>();
        originalColor = Renderer.material.color;
        GridSystem = GameObject.Find("GridSystem").transform.GetComponent<GridSystemMain>();

    }

    public void SetCoordsAndGrid(Vector2Int coords, ref GameObject[,] TheGrid)
    {
        Coords = coords;
        this.TheGrid = TheGrid;
    }

    void PlaySoundPlaced()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = SoundPlacedNoises[SoundPlacedRandom.Next(SoundPlacedNoises.Length)];

        audio.Play();
    }

    void OnMouseOver(){
        if(Input.GetMouseButton(0)){
            if(!BlockPlaced){

                BlockPlaced = true;

                PlaySoundPlaced();

                Block = Instantiate(Blocks[0], transform.position, /*Quaternion.identity*/ Quaternion.Euler(90, 0, 0));

                Block.GetComponent<WallScript>().SetCoordsAndGrid(Coords, ref TheGrid);
                Block.GetComponent<WallScript>().CheckNear();

                Renderer.material.color = GridSystem.SelectionColor;
                clicked = true;
                StartCoroutine(offclick());

            }
        }
        else if(Input.GetMouseButton(1)){
            if(BlockPlaced){

                BlockPlaced = false;
                
                Destroy(Block);
                UpdateNearbyTiles();

                Renderer.material.color = GridSystem.SelectionColor;
                clicked = true;
                StartCoroutine(offclick());

            }
        }
    }

    void UpdateNearbyTiles(){
        try{
        TheGrid[Coords.x, Coords.y + 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
        try{
        TheGrid[Coords.x, Coords.y - 1].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
        try{
        TheGrid[Coords.x - 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
        try{
        TheGrid[Coords.x + 1, Coords.y].transform.GetChild(0).GetComponent<TileControlFunctions>().Block.GetComponent<WallScript>().CheckNear();
        }catch{}
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
