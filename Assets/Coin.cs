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
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
