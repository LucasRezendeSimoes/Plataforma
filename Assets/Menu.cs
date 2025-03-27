using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GUISkin layout;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.skin = layout;
        GUI.skin.label.fontSize = 50;
        Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Título do jogo"));
        GUI.Label(new Rect((Screen.width-label1.x)/2, (Screen.height-label1.y)/2-30, label1.x+5, label1.y), "Título do jogo");

        GUI.skin.label.fontSize = 20;
        Vector2 label2 = GUI.skin.label.CalcSize(new GUIContent("Use as setas para se mover"));
        GUI.Label(new Rect((Screen.width-label2.x)/2, (Screen.height-label2.y)/2+20, label2.x+5, label2.y), "Use as setas para se mover");

        GUI.skin.label.fontSize = 20;
        Vector2 label3 = GUI.skin.label.CalcSize(new GUIContent("Pegue todas as moedas para ganhar e não deixe suas vidas chegarem a 0"));
        GUI.Label(new Rect((Screen.width-label3.x)/2, (Screen.height-label3.y)/2+40, label3.x+5, label3.y), "Pegue todas as moedas para ganhar e não deixe suas vidas chegarem a 0");

        GUI.skin.label.fontSize = 20;
        Vector2 label4 = GUI.skin.label.CalcSize(new GUIContent("Aperte espaço para iniciar"));
        GUI.Label(new Rect((Screen.width-label4.x)/2, (Screen.height-label4.y)/2+70, label4.x+5, label4.y), "Aperte espaço para iniciar");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("01");
        }
    }
}
