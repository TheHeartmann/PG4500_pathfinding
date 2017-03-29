using UnityEngine;

public class TargetPickupScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Put pickup trigger logic here
        Destroy(gameObject);
    }
}