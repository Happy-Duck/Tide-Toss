using UnityEngine;

public class PodSpawner : MonoBehaviour
{

    [SerializeField] GameObject podPrefab;
    [SerializeField] int MaxClones = 10;
    GameObject[] pod_array;
    public int pod_index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pod_array = new GameObject[MaxClones];

        SpawnPod();
    }

    private void SpawnPod()
    {
        GameObject podClone = Instantiate(podPrefab, new Vector3(0f, -0.8f, 1f), new Quaternion());

        Tosser podTosser = podClone.GetComponent<Tosser>();

        podTosser.floorCollision += handleFloorCollision;

        if (pod_array[pod_index] != null)
        {
            Destroy(pod_array[pod_index]);
        }

        pod_array[pod_index] = podClone;

        pod_index = (pod_index + 1) % pod_array.Length;

        Debug.Log(pod_index);
    }

    private void handleFloorCollision()
    {
        SpawnPod();
    }

}
