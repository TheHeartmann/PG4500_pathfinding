using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class CharacterControllerInput : MonoBehaviour
{
    #region references to camera and character used for movement

    //Get the main camera for orientation
    private Transform _camera;

    [SerializeField]
    private CharacterControllerPhysics _character; // A reference to the ThirdPersonCharacter on the object

    #endregion

    #region Target properties

    //Target (to move towards?)
    private GameObject Target { get; set; }

    //All targets
    private List<Vector3> AllTargets { get; set; }

    public Vector3? VectorToTarget
    {
        get { return Target.transform.position - _character.transform.position; }
    }

    #endregion

    #region Movement

    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private float _minMovementModifier = 1;
    [SerializeField] private float _maxMovementModifier = 10;


    [SerializeField]
    private float DynamicMovementSpeed {
        get { return (VectorToTarget.Value.magnitude * _movementSpeed).Clamp(_minMovementModifier, _maxMovementModifier); } }

    //Easy way to get vectors
    private float HorizontalMovement { get; set; }

    private float VerticalMovement { get; set; }

    private Vector3 MovementVector

    {
        get { return VerticalMovement * _camera.up + HorizontalMovement * _camera.right; }
    }

    #endregion

    private void Awake()
    {
        if (_character == null)
        {
            Debug.LogError("No character object was set. Destroying the CharacterControllerInput object.");
            Destroy(gameObject);
        }

        AllTargets = new List<Vector3>();
    }

    private void Start()
    {
        _camera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        //TODO: Put logic here. Overwrite below section.

        #region Example code. Overwrite this section


        if (Target != null)
        {
        var movement = VectorToTarget;
//        _character.Move(movement.Value.normalized * Time.deltaTime * _movementSpeed); //use for static movement speed
            _character.Move(movement.Value.normalized * Time.deltaTime * DynamicMovementSpeed); //use for "arrive" functionality
        }

        #endregion
        ClearVectors();
    }

    private void MoveUp()
    {
        VerticalMovement = 1;
    }

    private void MoveDown()
    {
        VerticalMovement = -1;
    }

    private void MoveLeft()
    {
        HorizontalMovement = -1;
    }

    private void MoveRight()
    {
        HorizontalMovement = 1;
    }

    private void ClearVectors()
    {
        HorizontalMovement = 0;
        VerticalMovement = 0;
    }

    public void AddTarget(GameObject target)
    {
        Target = target;
    }
}