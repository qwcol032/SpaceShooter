using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet3Controller : MonoBehaviour
{
    GameObject shooterGo;
    public float bulletSpeed;

    void Start()
    {
        shooterGo = GameObject.Find("Shooter");
        StartCoroutine(CoFly());
    }


    //플레이어의 현제 위치에 보정을 더한 방향으로 날아가는 함수
    IEnumerator CoFly()
    {

        Vector3 dir = shooterGo.transform.position - this.transform.position;

        //랜덤값 보정
        Vector3 rand = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        dir = dir + rand;

        while (true)
        {
            Vector3 movement = dir.normalized * this.bulletSpeed * Time.deltaTime;
            this.transform.Translate(movement);


            //화면 밖에서 사라지는 기능
            if (this.transform.position.y < -5.68f || this.transform.position.x > 3.4 || this.transform.position.x < -3.4)
            {
                Object.Destroy(this.gameObject);
            }

            yield return null;
        }
    }



    //온트리그 : 슈터와 접촉하면 데미지를 주는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shooter")
        {
            GameObject ShooterGo = GameObject.Find("Shooter");
            ShooterController shooterController = ShooterGo.gameObject.GetComponent<ShooterController>();
            shooterController.HitDamage();
            Object.Destroy(this.gameObject);
        }
    }
}
