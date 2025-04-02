using UnityEngine;

public class InimigoRolando : MonoBehaviour
{
    public float velocidade = 3f; // Velocidade do inimigo
    public float tempoParaVirar = 2f; // Tempo que o inimigo vai andar para um lado antes de virar
    public float raio = 0.5f; // Raio do inimigo (simulando um objeto que rola)

    private float tempoPassado = 0f; // Controla o tempo que o inimigo passou se movendo
    private bool movendoParaDireita = true; // Controla a direção do movimento
    private float distanciaPercorrida = 0f; // Distância percorrida pelo inimigo

    private Rigidbody2D rb; // Referência ao Rigidbody2D para garantir que o inimigo não seja afetado pela gravidade

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D
        rb.gravityScale = 0f; // Desativa a gravidade para o inimigo
    }

    void Update()
    {
        MoverInimigo();
        RolagemInimigo();
    }

    private void MoverInimigo()
    {
        // Controle de movimento, alternando entre direita e esquerda
        tempoPassado += Time.deltaTime;

        if (tempoPassado >= tempoParaVirar)
        {
            // Alterna a direção
            movendoParaDireita = !movendoParaDireita;
            tempoPassado = 0f; // Reinicia o contador de tempo
        }

        // Aplica o movimento dependendo da direção
        float direcao = movendoParaDireita ? 1f : -1f;
        rb.velocity = new Vector2(direcao * velocidade, rb.velocity.y);

        // Atualiza a distância percorrida para ajustar a rotação
        distanciaPercorrida += Mathf.Abs(rb.velocity.x) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
        }
    }

    private void RolagemInimigo()
    {
        // A rotação será proporcional à distância percorrida, como se fosse um objeto rolando
        float rotaçõesPorMetro = 2f * Mathf.PI / (2 * raio); // Número de rotações por metro (circunferência dividida por 1 metro)
        float rotacao = distanciaPercorrida * rotaçõesPorMetro;

        // Se movendo para a direita, rotação horária, senão anti-horária
        if (!movendoParaDireita)
        {
            rotacao = -rotacao; // Inverte a rotação se movendo para a esquerda
        }

        // Aplica a rotação no eixo Z
        transform.rotation = Quaternion.Euler(0, 0, rotacao);
    }
}
