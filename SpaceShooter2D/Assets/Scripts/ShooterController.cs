using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float moveSpeed = 1f;//속도 
    public Animator animator;
    public GameObject playerBulletPrefab;   //원본 

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("총알 발사");

            //프리팹의 복제품을 만들어냄 
            GameObject playerBulletGo = Object.Instantiate(this.playerBulletPrefab);

            Vector3 targetPosition = this.transform.position;
            targetPosition.y += 0.798f;

            //위치를 재설정 
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

        Vector3 dir = new Vector3(h, v, 0); //방향 

        Vector3 movement = dir.normalized * this.moveSpeed * Time.deltaTime;

        this.transform.Translate(movement);
    }
}