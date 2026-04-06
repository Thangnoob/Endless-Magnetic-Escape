    using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [Header("Spawn Settings")]
    public GameObject magneticPrefab;
    public Transform player;
    public float spawnInterval = 1.5f;
    public float safeDistance = 3f; // Khoảng cách an toàn so với player
    
    [Header("Pool Settings (Mobile Optimization)")]
    public int initialPoolSize = 10;
    public float objectLifetime = 5f;

    private Queue<GameObject> objectPool = new Queue<GameObject>();
    private List<ActiveObjectData> activeObjects = new List<ActiveObjectData>();
    private float timer;

    private class ActiveObjectData
    {
        public GameObject gameObject;
        public float spawnTime;
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(magneticPrefab, transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    private void Update()
    {
        HandleSpawning();
        HandleObjectLifetime();
    }

    private void HandleSpawning()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMagneticObject();
            timer = 0f;
        }
    }

    private void SpawnMagneticObject()
    {
        GameObject obj = GetObjectFromPool();
        
        Vector2 spawnPosition = GetRandomSpawnPosition();
        obj.transform.position = spawnPosition;
        
        // Randomize polarity
        MagneticObject magneticObj = obj.GetComponent<MagneticObject>();
        if (magneticObj != null)
        {
            magneticObj.magneticType = (Random.value > 0.5f) ? MagneticType.North : MagneticType.South;
            
            // Cập nhật Update màu sắc cho object nếu prefab của bạn dùng SpriteRenderer màu
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = (magneticObj.magneticType == MagneticType.North) ? Color.red : Color.blue;
            }
        }

        obj.SetActive(true);

        activeObjects.Add(new ActiveObjectData { gameObject = obj, spawnTime = Time.time });
    }

    private GameObject GetObjectFromPool()
    {
        if (objectPool.Count > 0)
        {
            return objectPool.Dequeue();
        }
        else
        {
            GameObject obj = Instantiate(magneticPrefab, transform);
            obj.SetActive(false);
            return obj;
        }
    }

    private void HandleObjectLifetime()
    {
        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            if (Time.time - activeObjects[i].spawnTime >= objectLifetime)
            {
                ReturnToPool(activeObjects[i].gameObject);
                activeObjects.RemoveAt(i);
            }
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Camera mainCam = Camera.main;
        if (mainCam == null) return Vector2.zero;

        Vector2 minBounds = mainCam.ViewportToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
        Vector2 maxBounds = mainCam.ViewportToWorldPoint(new Vector3(1, 1, mainCam.nearClipPlane));

        float padding = 1f;

        Vector2 randomPos = Vector2.zero;
        bool validPosition = false;
        int maxAttempts = 10;
        int attempts = 0;

        while (!validPosition && attempts < maxAttempts)
        {
            float randomX = Random.Range(minBounds.x + padding, maxBounds.x - padding);
            
            // Tính toán Y luôn nằm phía trên Player để player hướng lên trên (Alien đuổi bên dưới)
            float playerY = (player != null) ? player.position.y : minBounds.y;
            
            // minSpawnY: phía trên player + safeDistance
            float minSpawnY = playerY + safeDistance;
            
            // maxSpawnY: có thể nằm trọn trong nửa trên màn hình hoặc mép trên màn hình
            float maxSpawnY = maxBounds.y - padding;

            // Nếu player tiến quá sát mép trên màn hình thì tự động spawn tuốt lên cao hơn Camera
            if (minSpawnY >= maxSpawnY)
            {
                maxSpawnY = minSpawnY + 3f;
            }

            float randomY = Random.Range(minSpawnY, maxSpawnY);
            randomPos = new Vector2(randomX, randomY);

            validPosition = true; // Y luôn an toàn nhờ minSpawnY nên không cần loop bắt check lại khoảng cách lớn trừ khi có chướng ngại vật

            attempts++;
        }

        return randomPos;
    }
}
