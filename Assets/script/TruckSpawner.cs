using UnityEngine;
using System.Collections;

public class TruckSpawner : MonoBehaviour
{
    [Header("Truck Settings")]
    public GameObject truckPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 4f;

    IEnumerator Start()
    {
        while (true)
        {
            SpawnTruck();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnTruck()
    {
        GameObject truck = Instantiate(
            truckPrefab,
            transform.position,
            transform.rotation
        );

        Animator animator = truck.GetComponent<Animator>();

        if (animator != null)
        {
            StartCoroutine(DestroyAfterAnimation(truck, animator));
        }
    }

    IEnumerator DestroyAfterAnimation(GameObject truck, Animator animator)
    {
        // Wait one frame so animation starts
        yield return null;

        // Get animation length
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // Wait until animation finishes
        yield return new WaitForSeconds(animLength);

        Destroy(truck);
    }
}