using System.Collections;
using UnityEngine;

public class UIPodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tidePod; // Should just be a visual version w/ collider and gravity, not throwable!!!
    
    void Start()
    {
        StartCoroutine(SpawnUIPods());
    }

    IEnumerator SpawnUIPods()
    {
        Instantiate(tidePod, new Vector3(Random.Range(80f, -80f), 82f, 90f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnUIPods());
        // Is this how you do loops......?
    }

    
    
}
