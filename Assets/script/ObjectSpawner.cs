using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Object Settings")]
    public GameObject objectPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 10f;

    IEnumerator Start()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(
            objectPrefab,
            transform.position,
            transform.rotation
        );

        Animator animator = obj.GetComponent<Animator>();

        if (animator != null)
        {
            StartCoroutine(DisableAfterAnimation(obj, animator));
        }
    }

    IEnumerator DisableAfterAnimation(GameObject obj, Animator animator)
    {
        // Wait one frame so animation starts
        yield return null;

        // Get current animation length
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;

        // Wait until animation finishes
        yield return new WaitForSeconds(animLength);

        // Disable object instead of destroying
        obj.SetActive(false);
    }
}