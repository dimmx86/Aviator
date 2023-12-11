using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Island island;
    [SerializeField] private float maxRandomY = 5.0F;
    [SerializeField] private float maxRandomX = 2.0f;
    [SerializeField] private float periodSpawn = 4.0f;
    [SerializeField][Min(1)] private int countSpawn = 3;

    private bool isSpawn = false;
    private WaitForSeconds wait;

    private void Start()
    {
        
        wait = new WaitForSeconds(periodSpawn);
        isSpawn = true;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return wait;
        while (isSpawn)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                Vector3 position = new Vector3(
                    transform.position.x 
                    + Random.Range(-maxRandomX, maxRandomX),
                    transform.position.y 
                    + Random.Range(-maxRandomY, maxRandomY));

                Instantiate(island, position, Quaternion.identity);
            }

            yield return wait;

        }

    }

    private void OnDestroy()
    {
        isSpawn = false;
    }
}
