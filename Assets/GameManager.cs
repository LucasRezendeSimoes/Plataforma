using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    public static int life;
    public static int inv;
    public GameObject player;
    public static GUISkin layout;
    private Scene cena;
    public static GameManager Instance;

    void Start()
    {
        score = 0;
        life = 3;
        inv = 0;
    }

    void Awake()
    {
        // Verifica se já existe uma instância
        if (Instance == null)
        {
            // Se não existe, define esta instância
            Instance = this;

            // Não destruir o GameManager quando mudar de cena
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(player);
        }
        else
        {
            // Se já existe uma instância, destrua esta duplicata
            Destroy(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int valor)
    {
        score += valor;
    }

    public void LoseLife()
    {
        if(inv == 0)
        {
            life--;
            inv = 1000;
        }
    }

    void OnGUI()
    {
        if(cena.name == "01" || cena.name == "02")
        {
            GUI.color = Color.green;
            GUI.skin = layout;
            GUI.skin.label.fontSize = 50;
            Vector2 label1 = GUI.skin.label.CalcSize(new GUIContent("Score: " + score.ToString()));
            GUI.Label(new Rect(10, Screen.height-label1.y-10, label1.x+1, label1.y), "Score: " + score.ToString());

            GUI.skin.label.fontSize = 50;
            Vector2 label2 = GUI.skin.label.CalcSize(new GUIContent("Lifes: " + life.ToString()));
            GUI.Label(new Rect(Screen.width - label2.x-10, Screen.height-label2.y-10, label2.x+1, label2.y), "Lifes: " + life.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        cena = SceneManager.GetActiveScene();
        if(cena.name == "01" || cena.name == "02")
        {
            if(player == null)
            {
                player = GameObject.Find("player");
                DontDestroyOnLoad(player);
                score = 0;
                life = 3;
            }
            GameObject[] moedas = GameObject.FindGameObjectsWithTag ("cacarola");
            if(life <= 0 || player.transform.position.y <= -6)
            {
                SceneManager.LoadScene("Derrota");
            }
            if(moedas.Length == 0)
            {
                if(cena.name == "01")
                {
                    SceneManager.LoadScene("02");
                    player.transform.position = new Vector2 (-7.35f, -1.8f);
                }
                else if(cena.name == "02")
                {
                    SceneManager.LoadScene("Vitoria");
                    
                }
            }
            if(inv>0)
            {
                inv--;
            }
            if(Input.GetKey(KeyCode.R)){
                LoseLife();
            }
        }
        else
        {
            Destroy(player);
        }
    }
}
