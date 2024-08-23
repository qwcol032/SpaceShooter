using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAController : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(CoFade());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "PlayerBullet(Clone)")
        {
            Object.Destroy(collision.gameObject);
            Object.Destroy(this.gameObject);
        }
    }
}
