using UnityEngine;

public class ZombieHand : MonoBehaviour
{
    public GameObject RHand;
    public void ActivateCollider()
    {
        RHand.GetComponent<Collider>().enabled = true;
    }
    public void DeactivateCollider()
    {
        RHand.GetComponent<Collider>().enabled = false;
    }


}
