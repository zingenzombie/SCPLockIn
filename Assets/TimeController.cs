using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeController : MonoBehaviour
{

    [SerializeField] public int TimeValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTime(float sliderVal)
    {
        TimeValue = (int) sliderVal * (int) sliderVal;
    }
}
