using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public Text text;
    public float timer = 0f;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeSquare", 0f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = timer.ToString("F2");
    }

    public void MakeSquare()
    {
        Instantiate(square);
    }
}
