using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    public GridSystemMain gridSystem;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            gridSystem.PlaceWall();
        }
    }

}
