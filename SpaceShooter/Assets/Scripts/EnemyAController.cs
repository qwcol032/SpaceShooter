using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject bulletPrefeb;
    public GameObject coinPrefab;
    public GameObject boomPrefab;
    public GameObject powerPrefab;
    private float elapsedTime;

    void Start()
    {
        //StartCoroutine(CoFade());
        StartCoroutine(CoShoot());
    }

    //IEnumerator CoFade()
    //{
    //    SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
    //    float alpha = 1f;

    //    while (true)
    //    {
    //        if (alpha <= 0)
    //        {
    //            break;
    //        }

    //        Color color = new Color(1, 1, 1, alpha);
    //        sr.color = color;
    //        Debug.Log(alpha);

    //        alpha -= 0.1f;

    //        yield return null;
    //    }
    //}

    IEnumerator CoShoot()
    {
        float rand = Random.value + 1f;

        while (true)
        {

            this.elapsedTime += Time.deltaTime;

            if (this.elapsedTime > rand)
            {
                rand = Random.value;

                if (rand < 0.1)
                {
                    GameObject enemyBullet3 = Instantiate(bulletPrefeb);
                    enemyBullet3.transform.position = this.transform.position;
                }
                this.elapsedTime = 0;
            }

            yield return null;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "PlayerBullet(Clone)")
        {
            GameObject explosionGo = Object.Instantiate(this.explosionPrefab);
            explosionGo.transform.position = this.transform.position;

            float rand = Random.value;
            if (rand <= 0.2)
            {
                rand = Random.value;
                if (rand < 0.333)
                {
                    //内牢 积己
                    GameObject coinGo = Object.Instantiate(this.coinPrefab);
                    coinGo.transform.position = this.transform.position;
                }
                else if (rand < 0.666)
                {
                    //气藕积己
                    GameObject boomGo = Object.Instantiate(this.boomPrefab);
                    boomGo.transform.position = this.transform.position;
                }
                else
                {
                    //颇况诀 积己
                    GameObject powerGo = Object.Instantiate(this.powerPrefab);
                    powerGo.transform.position = this.transform.position;
                }
            }

            Object.Destroy(collision.gameObject);
            Object.Destroy(this.gameObject);
        }
        else if(collision.gameObject.name == "Shooter")
        {
            GameObject ShooterGo = GameObject.Find("Shooter");
            ShooterController shooterController = ShooterGo.gameObject.GetComponent<ShooterController>();
            shooterController.HitDamage();
            Object.Destroy(this.gameObject);
        }
    }
}
