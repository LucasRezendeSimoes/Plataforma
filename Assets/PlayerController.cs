using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações do Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 10f;
    public float thresholdNormal = 0.5f; // Define o que é considerado "para cima"

    private Rigidbody2D rb;
    private BoxCollider2D coll;

    // Armazena os colliders que estão em contato como "chão"
    private HashSet<Collider2D> collidersNoChao = new HashSet<Collider2D>();

    // Propriedade para verificar se está no chão
    private bool noChao
    {
        get { return collidersNoChao.Count > 0; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Movimento();
        Pular();
    }

    void Movimento()
{
    float inputMovimento = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(inputMovimento * velocidade, rb.velocity.y);

    // Verifica se o jogador está se movendo para a esquerda ou direita
    if (inputMovimento < 0) // Para a esquerda
    {
        // Rotaciona 180 graus no eixo Y
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    else if (inputMovimento > 0) // Para a direita
    {
        // Restaura a rotação para o valor original
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}


    void Pular()
    {
        if (Input.GetButtonDown("Jump") && noChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
        }
    }

    // Detecta o início de uma colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        VerificaContatos(collision);
    }

    // Atualiza a verificação enquanto a colisão persiste
    void OnCollisionStay2D(Collision2D collision)
    {
        VerificaContatos(collision);
    }

    // Remove o collider da lista quando a colisão termina
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collidersNoChao.Contains(collision.collider))
        {
            collidersNoChao.Remove(collision.collider);
        }
    }

    // Método para verificar os contatos e identificar se são "chão"
    void VerificaContatos(Collision2D collision)
    {
        bool contatoChao = false;
        foreach (ContactPoint2D contato in collision.contacts)
        {
            // Se a normal do contato tiver valor Y maior que o limiar,
            // consideramos que é um contato com o chão.
            if (contato.normal.y >= thresholdNormal)
            {
                contatoChao = true;
                break;
            }
        }

        if (contatoChao)
        {
            collidersNoChao.Add(collision.collider);
        }
        else
        {
            // Se não houver contato "para cima", remove (caso exista)
            if (collidersNoChao.Contains(collision.collider))
            {
                collidersNoChao.Remove(collision.collider);
            }
        }
    }
}