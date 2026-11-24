using UnityEngine;

public class CS_Spawn_Dirt : MonoBehaviour
{
    [SerializeField] GameObject dirtPrefab;
    [SerializeField] Vector3 spawnPoint = new Vector3();
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(dirtPrefab, spawnPoint * 0.75f, Quaternion.identity);
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
