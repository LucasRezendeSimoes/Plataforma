using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    void Start()
    {
        score = 0;
    }

    public void AddScore(int valor)
    {
        score += valor;
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
