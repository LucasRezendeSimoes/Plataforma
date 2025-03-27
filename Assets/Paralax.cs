using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Referência ao transform do jogador
    public Transform player;

    // Multiplicador do efeito parallax (valores entre 0 e 1 deixam o fundo se movendo mais devagar que o jogador)
    [Range(0f, 1f)]
    public float parallaxMultiplier = 0.5f;

    // Armazena a posição do jogador no frame anterior
    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (player != null)
            lastPlayerPosition = player.position;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Calcula a mudança na posição do jogador desde o último frame
        Vector3 delta = player.position - lastPlayerPosition;

        // Atualiza a posição do fundo apenas no eixo X (para efeito horizontal)
        transform.position += new Vector3(delta.x * parallaxMultiplier, 0f, 0f);

        // Atualiza a posição do jogador para o próximo cálculo
        lastPlayerPosition = player.position;
    }
}
