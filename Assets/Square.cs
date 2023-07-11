using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Rigidbody2D rigid;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3.25f, 4.5f);
        float size = Random.Range(0.75f, 1.25f);

        transform.position = new Vector3(x, y, 0);
        transform.localScale = new Vector3(size, size, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            if (transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameManager.isGameOver = true;
        }
        else if (other.gameObject.CompareTag("Shield"))
        {
            rigid.AddForce(new Vector2(1.75f, 1.75f), ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(new Vector2(0.5f, 0.5f), ForceMode2D.Impulse);
        }
    }
}
