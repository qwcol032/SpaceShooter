using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float bulletSpeed;

    private void Start()
    {
        StartCoroutine(this.CoMove());
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            this.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
            if (this.transform.position.y > 5.41f)
            {
                Object.Destroy(this.gameObject);
            }
            yield return null;

        }
    }
}
