using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Vitoria : MonoBehaviour
{
    // Start is called before the first frame update
    public GUISkin layout;
    public GameObject dialogo;
    public static int score;
    void Start()
    {
        score = GameManager.Instance.GetScore();
        
    }
    void OnGUI()
    {
        if(!dialogo.activeInHierarchy)
        {
            GUI.color = Color.black;
            GUI.skin = layout;
            GUI.skin.label.fontSize = 50;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Parabéns"));
            GUI.Label(new Rect((Screen.width-label1.x)/2, (Screen.height-label1.y)/2-30, label1.x+5, label1.y), "Parabéns");

            GUI.skin.label.fontSize = 20;
            Vector2 label2 = GUI.skin.label.CalcSize(new GUIContent("Sua pontuação foi de "+score));
            GUI.Label(new Rect((Screen.width-label2.x)/2, (Screen.height-label2.y)/2+20, label2.x+5, label2.y), "Sua pontuação foi de "+score);

            GUI.skin.label.fontSize = 20;
            Vector2 label3 = GUI.skin.label.CalcSize(new GUIContent("Aperte R para reiniciar"));
            GUI.Label(new Rect((Screen.width-label3.x)/2, (Screen.height-label3.y)/2+40, label3.x+5, label3.y), "Aperte R para reiniciar");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogo.activeInHierarchy && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
