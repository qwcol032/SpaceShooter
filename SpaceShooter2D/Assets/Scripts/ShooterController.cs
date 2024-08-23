using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float moveSpeed = 1f;//�ӵ� 
    public Animator animator;
    public GameObject playerBulletPrefab;   //���� 

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�Ѿ� �߻�");

            //�������� ����ǰ�� ���� 
            GameObject playerBulletGo = Object.Instantiate(this.playerBulletPrefab);

            Vector3 targetPosition = this.transform.position;
            targetPosition.y += 0.798f;

            //��ġ�� �缳�� 
            playerBulletGo.transform.position = targetPosition;
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Debug.Log($"{h}, {v}");
        if (h == 0)
        {
            this.animator.SetInteger("State", 0);
        }
        else if (h == 1)
        {
            this.animator.SetInteger("State", 2);
        }
        else if (h == -1)
        {
            this.animator.SetInteger("State", 1);
        }

        Vector3 dir = new Vector3(h, v, 0); //���� 

        Vector3 movement = dir.normalized * this.moveSpeed * Time.deltaTime;

        this.transform.Translate(movement);
    }
}