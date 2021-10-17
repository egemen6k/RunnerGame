using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 _spawnPosition = new Vector3(25f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
