using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformManager : MonoBehaviour
{

    public static FallingPlatformManager Instance = null;

    [SerializeField]
    GameObject PlatformFallPrefab;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        Instantiate(PlatformFallPrefab, new Vector2(220f, 111f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-177f, 295f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-212f, 318f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-237f, 344f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-267f, 153f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-298f, 188f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-180f, 234f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-222f, 221f), PlatformFallPrefab.transform.rotation);
        Instantiate(PlatformFallPrefab, new Vector2(-261f, 206f), PlatformFallPrefab.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(4f);
        Instantiate(PlatformFallPrefab, spawnPosition, PlatformFallPrefab.transform.rotation);
    }

}
