using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffectController : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(CoEnd());
    }

    IEnumerator CoEnd()
    {
        yield return new WaitForSeconds(0.2f);
        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy A(Clone)")
        {
            Object.Destroy(collision.gameObject);
        }
    }
}
