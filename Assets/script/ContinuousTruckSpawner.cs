using UnityEngine;
using System.Collections;

public class ContinuousTruckSpawner : MonoBehaviour
{
    [Header("Truck")]
    public GameObject truckPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 0.5f; // Faster spawning

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnTruck();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnTruck()
    {
        GameObject truck = Instantiate(truckPrefab, transform.position, transform.rotation);

        Animator anim = truck.GetComponent<Animator>();

        if (anim != null)
        {
            StartCoroutine(DisableAfterAnimation(truck, anim));
        }
    }

    IEnumerator DisableAfterAnimation(GameObject truck, Animator anim)
    {
        yield return null;

        float length = anim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(length);

        truck.SetActive(false);   // Disable instead of Destroy
    }
}