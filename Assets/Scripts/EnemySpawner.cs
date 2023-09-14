using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject slimePrefab;
    [SerializeField]
    private float slimeInterval = 3.5f;

    private int contador = 0;
    public int EnemyLimit = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(slimeInterval, slimePrefab));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= EnemyLimit)
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2.2f, 2.6f), Random.Range(-1f, 1.8f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
