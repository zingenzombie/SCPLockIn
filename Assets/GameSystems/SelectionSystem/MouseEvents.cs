using UnityEngine;

public class MouseEvents : MonoBehaviour
{

    public GridSystemMain gridSystem;
    void Update(){
        if(Input.GetMouseButton(0))
        {
            gridSystem.PlaceWall();
        }
        else if (Input.GetMouseButton(1))
        {
            gridSystem.BreakWall();
        }
    }

}
