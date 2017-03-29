using UnityEngine;

// Stolen from here http://answers.unity3d.com/questions/586989/create-gameobject-on-mouse-click.html, and slightly refactored

public class TargetPlacement : MonoBehaviour
{
    [SerializeField] private CharacterControllerInput _characterController;

    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField]
    private GameObject Prefab;

    // Use this for initialization
    private void Start()
    {
        if (_characterController != null) return;
        Debug.LogError("No character object was set. Destroying the CharacterControllerInput object.");
        Destroy(gameObject);
    }

    private void Update () {

        _ray=Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(_ray, out _hit)) return;
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
        var target = Instantiate(Prefab,new Vector3(_hit.point.x,_hit.point.y,_hit.point.z), Quaternion.identity) as GameObject;

        //TODO: change if you want different functionality
        _characterController.AddTarget(target);
    }
}