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

    public void InitObj(){
        CheckNearSurroundings();
    }

    void PlaySoundPlaced()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = SoundPlacedNoises[SoundPlacedRandom.Next(SoundPlacedNoises.Length)];

        audio.Play();
    }

    
    private void CheckNearSurroundings(){
        var HorizontalObjs = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, .2f), Quaternion.identity, layerMask);
        var VerticalObjs = Physics.OverlapBox(transform.position, new Vector3(.2f, 1f, 1f), Quaternion.identity, layerMask);

        foreach(var obj in HorizontalObjs){
            if(obj != this){
                var objController = obj.transform.parent.GetComponent<TileControlFunctions>();
            if(obj.transform.position.x - transform.position.x < 0){
                NSEW_Walls[2].SetActive(true);
                objController.NSEW_Walls[3].SetActive(true);
            }
            else if(obj.transform.position.x - transform.position.x > 0){
                NSEW_Walls[3].SetActive(true);
                objController.NSEW_Walls[2].SetActive(true);
            }
            }
        }

        foreach(var obj in VerticalObjs){
            if(obj != this){
                var objController = obj.transform.parent.GetComponent<TileControlFunctions>();
            if(obj.transform.position.z - transform.position.z < 0){
                NSEW_Walls[0].SetActive(true);
                objController.NSEW_Walls[1].SetActive(true);
            }
            else if(obj.transform.position.z - transform.position.z > 0){
                NSEW_Walls[1].SetActive(true);
                objController.NSEW_Walls[0].SetActive(true);
            }
            }
        }
    }
}
