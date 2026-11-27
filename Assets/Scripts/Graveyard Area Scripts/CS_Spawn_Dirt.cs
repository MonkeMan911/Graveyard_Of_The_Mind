using UnityEngine;
using System.Collections;

public class CS_Spawn_Dirt : MonoBehaviour
{
    public GameObject dirtPrefab;
    public GameObject coffinPrefab;

    public int worldWidth = 10;
    public int worldHeight = 10;

    public float spawnSpeed = 0;

    void Start()
    {
        StartCoroutine(CreateDirtHole());
    }

    IEnumerator CreateDirtHole()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            yield return new WaitForSeconds(spawnSpeed);

            for (int z = 0; z < worldHeight; z++)
            {
                yield return new WaitForSeconds(spawnSpeed);

                GameObject block = Instantiate(dirtPrefab, Vector3.zero, dirtPrefab.transform.rotation) as GameObject;
                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(x, 0, z);
            }
        }
    }
    //[SerializeField] GameObject dirtPrefab;
    //[SerializeField] Vector3 spawnPoint = new Vector3();
    //void Start()
    //{
    //    for (int i = 0; i < 8; i++)
    //    {
    //        Instantiate(dirtPrefab, spawnPoint * 0.75f, Quaternion.identity);
    //        Debug.Log(i);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
