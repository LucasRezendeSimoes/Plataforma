using UnityEngine;

public class Coin : MonoBehaviour
{
    // Valor que essa moeda adiciona à pontuação
    public int valor = 1;
    public Animator anim;

    private void Start(){
        anim.speed = 3.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu é o jogador (certifique-se de que o jogador tenha a tag "Player")
        if (collision.CompareTag("Player"))
        {
            // Procura o GameManager no GameObject chamado "display"
            GameManager gameManager = GameObject.Find("Display").GetComponent<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(valor);
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado no objeto 'display'!");
            }
            
            // Destroi a moeda coletada
            Destroy(gameObject);
        }
    }
}
