using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    GameObject scoreUIText;

    float speed;

    public GameObject ExplosionAnim;

    void Start()
    {
        speed = 2f;

        scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));

        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag")|| (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            Destroy(gameObject);

            scoreUIText.GetComponent<GameScore>().Score += 100;
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate (ExplosionAnim);

        explosion.transform.position = transform.position;
    }
}
