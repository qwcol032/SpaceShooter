using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    public GameObject enemyAPrefep;
    private float elapsedTime;

    void Start()
    {
        StartCoroutine(CoMakeEnemy());
        
    }

    IEnumerator CoMakeEnemy()
    {
        while (true)
        {
            this.elapsedTime += Time.deltaTime;

            if (this.elapsedTime > 1f)
            {
                GameObject enemyAGo = Instantiate(enemyAPrefep);
                float randomPosX = Random.Range(-2.55f, 2.55f);
                float randomPosY = Random.Range(0.3f, 4f);

                enemyAGo.transform.position = new Vector3(randomPosX, randomPosY, 0);
                this.elapsedTime = 0;
            }

            yield return null;
        }
    }
}
