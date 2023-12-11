using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawObject[] objects;
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
        
        while (isSpawn)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                Vector3 position = new Vector3(
                    transform.position.x 
                    + Random.Range(-maxRandomX, maxRandomX),
                    transform.position.y 
                    + Random.Range(-maxRandomY, maxRandomY));

                SpawObject obj = Instantiate(
                    objects[Random.Range(0,objects.Length)],
                    position, Quaternion.identity);
                if (!IsFreeSpace(position,obj.Radius))
                {
                    Destroy(obj.gameObject);
                    print("destroy");
                }
            }

            yield return wait;

        }
        yield return wait;
    }

    private bool IsFreeSpace(Vector3 position, float radius)
    {
        var collision = Physics2D.CircleCastAll(position, radius,Vector2.zero);
        if (collision.Length > 1)
        {
            return false;

        }
        return true;
    }


    private void OnDestroy()
    {
        isSpawn = false;
    }
}
