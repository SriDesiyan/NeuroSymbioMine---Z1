using UnityEngine;
using System.Collections;

public class ShowChildAfterDelay : MonoBehaviour
{
    public GameObject loadObjects; // Drag LoadObjects here
    public float delay = 10f;

    void Start()
    {
        loadObjects.SetActive(false);
        StartCoroutine(ShowObject());
    }

    IEnumerator ShowObject()
    {
        yield return new WaitForSeconds(delay);

        loadObjects.SetActive(true);
    }
}