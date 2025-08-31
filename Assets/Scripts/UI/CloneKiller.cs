using UnityEngine;

public class CloneKiller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject); // Should be changed to be tag specific perhaps....
    }
}
