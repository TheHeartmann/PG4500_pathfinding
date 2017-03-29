using UnityEngine;

public class TargetPickupScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Put pickup trigger logic here
        print("Congrats, you reached a target!");

        Destroy(gameObject);
    }
}