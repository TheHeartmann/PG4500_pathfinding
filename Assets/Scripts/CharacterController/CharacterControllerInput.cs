using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterControllerInput : MonoBehaviour
{
    //Get the main camera for orientation
    private Transform _camera;
    [SerializeField]
    private CharacterControllerPhysics _character; // A reference to the ThirdPersonCharacter on the object


    //Easy way to get vectors
    public float HorizontalMovement { get; set; }
    public float VerticalMovement { get; set; }
    public Vector3 MovementVector

    {
        get
        {
            return VerticalMovement * _camera.up + HorizontalMovement * _camera.right;
        }
    }

    private void Start()
    {
        _camera = Camera.main.transform;
//        _character = GetComponent<CharacterControllerPhysics>();
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
    private void Update()
    {
        //TODO: Put logic here. Over write below section.

        #region Example code. Overwrite this section

        MoveUp();
        MoveRight();

        #endregion

        _character.Move(MovementVector);
        ClearVectors();

    }

    private void ClearVectors()
    {
        HorizontalMovement = 0;
        VerticalMovement = 0;
    }
}