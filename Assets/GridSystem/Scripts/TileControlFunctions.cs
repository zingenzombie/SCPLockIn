using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TileControlFunctions : MonoBehaviour
{

    [SerializeField]
    public GameObject[] NSEW_Walls;

    public AudioClip[] SoundPlacedNoises;

    private System.Random SoundPlacedRandom = new System.Random();

    public LayerMask layerMask;

    public bool Updating = false;

    private GameObject[,] TheGrid;

    private Vector2Int Coords;

    private Vector2Int[] Offsets = new Vector2Int[4];

    public bool[] NSEW;

    public bool BlockPlaced = true;

    public void InitObj(Vector2Int Coords, ref GameObject[,] TheGrid){
        this.TheGrid = TheGrid;
        this.Coords = Coords;

        NSEW = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            NSEW[i] = false;
        }

        Offsets[0] = new Vector2Int(0, -1);
        Offsets[1] = new Vector2Int(0, 1);
        Offsets[2] = new Vector2Int(-1, 0);
        Offsets[3] = new Vector2Int(1, 0);
        PlaySoundPlaced();
    }

    void PlaySoundPlaced()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = SoundPlacedNoises[SoundPlacedRandom.Next(SoundPlacedNoises.Length)];

        audio.Play();
    }
    /*
    public void CheckNearSurroundings()
    {

        Updating = true;

        for (int i = 0; i < 4; i++)
        {
            try
            {
                if (TheGrid[Coords.x + Offsets[i].x, Coords.y + Offsets[i].y].GetComponent<TileControlFunctions>().BlockPlaced != NSEW[i])
                {
                    NSEW[i] = !NSEW[i];

                    NSEW_Walls[i].SetActive(NSEW[i]);

                    if (!TheGrid[Coords.x + Offsets[i].x, Coords.y + Offsets[i].y].GetComponent<TileControlFunctions>().Updating)
                    {
                        TheGrid[Coords.x + Offsets[i].x, Coords.y + Offsets[i].y].GetComponent<TileControlFunctions>().CheckNearSurroundings();
                    }
                }
            }
            catch {}

        }

        Updating = false;
    }*/

}
