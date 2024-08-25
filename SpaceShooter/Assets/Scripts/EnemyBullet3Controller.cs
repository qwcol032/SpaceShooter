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


    //�÷��̾��� ���� ��ġ�� ������ ���� �������� ���ư��� �Լ�
    IEnumerator CoFly()
    {

        Vector3 dir = shooterGo.transform.position - this.transform.position;

        //������ ����
        Vector3 rand = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        dir = dir + rand;

        while (true)
        {
            Vector3 movement = dir.normalized * this.bulletSpeed * Time.deltaTime;
            this.transform.Translate(movement);


            //ȭ�� �ۿ��� ������� ���
            if (this.transform.position.y < -5.68f || this.transform.position.x > 3.4 || this.transform.position.x < -3.4)
            {
                Object.Destroy(this.gameObject);
            }

            yield return null;
        }
    }



    //��Ʈ���� : ���Ϳ� �����ϸ� �������� �ִ� �Լ�
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
