using UnityEngine;

// Stolen from here http://answers.unity3d.com/questions/586989/create-gameobject-on-mouse-click.html, and slightly refactored

public class TargetPlacement : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    public GameObject Prefab;
    // Use this for initialization

    // Update is called once per frame
    void Update () {

        _ray=Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(_ray, out _hit)) return;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Prefab,new Vector3(_hit.point.x,_hit.point.y,_hit.point.z), Quaternion.identity);
        }
    }
}