using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public GameObject playerBulletPrefab;
    public GameObject boomEffectPrefab;

    void Start()
    {
        StartCoroutine(CoMove());
        StartCoroutine(CoShoot());
        StartCoroutine(CoUseBoom());
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

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

            Vector3 dir = new Vector3(h, v, 0); //¹æÇâ 

            Vector3 movement = dir.normalized * this.moveSpeed * Time.deltaTime;

            this.transform.Translate(movement);

            yield return null;
        }
    }

    IEnumerator CoShoot()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject playerBulletGo = Object.Instantiate(this.playerBulletPrefab);
                Vector3 targetPosition = this.transform.position;
                targetPosition.y += 0.798f;
                playerBulletGo.transform.position = targetPosition;
            }

            yield return null;
        }
    }

    IEnumerator CoUseBoom()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject boomUI = GameObject.Find("BoomUI(Clone)");
                if (boomUI != null)
                {
                    Object.Destroy(boomUI);
                    GameObject boomEffectGo = Object.Instantiate(this.boomEffectPrefab);
                    boomEffectGo.transform.position = new Vector3(this.transform.position.x, 2f, 0);
                }
                else
                {
                    Debug.Log("ÆøÅº¾øÀ½");
                }
            }

            yield return null;
        }
    }

    public void HitDamage()
    {
        GameObject life;
        life = GameObject.Find("Life (2)");
        if (life == null)
        {
            life = GameObject.Find("Life (1)");
            if (life == null)
            {
                life = GameObject.Find("Life");
            }
        }

        if (life == null)
        {
            //°ÔÀÓ¿À¹ö
        }
        else
        {
            Object.Destroy(life.gameObject);
        }
    }
}