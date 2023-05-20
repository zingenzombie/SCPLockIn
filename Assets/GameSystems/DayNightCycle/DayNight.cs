using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public GameObject directionalLight;

    public GameObject GridFloor;

    [SerializeField] private float minutesPerDay;


    public float _Time = 0;

    private float secondsPerHour;

    private MeshRenderer mesh;

    void Awake(){
        secondsPerHour = 60 * minutesPerDay / 24;
        mesh = GridFloor.GetComponent<MeshRenderer>();
    }
    void FixedUpdate(){
        _Time += Time.deltaTime / secondsPerHour;
        if(_Time >= 24)
            _Time = 0;

        directionalLight.transform.Rotate(Time.deltaTime / secondsPerHour * 15, 0, 0, Space.Self);
    }
}
