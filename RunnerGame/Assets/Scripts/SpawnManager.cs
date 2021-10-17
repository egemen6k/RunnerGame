using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 _spawnPosition = new Vector3(25f, 0f, 0f);
    private float _startDelay = 2f;
    private float _repeatRate = 2f;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (!_playerController.gameOver)
        {
            Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
