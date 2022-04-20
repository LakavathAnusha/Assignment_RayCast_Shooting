using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    
    
    public GameObject enemyPrefab;
    
    float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      
        time = time + Time.deltaTime;
        if (time >= 3.0f)
        {
            float x = Random.Range(Random.Range(-5f, -15f), Random.Range(5f, 15f));
            float y = Random.Range(1f, 3f);
            float z = Random.Range(Random.Range(-5f, -15f), Random.Range(5f, 15f));
            Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
            time = 0.0f;

        }
    }


}
