using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    // Referência ao objeto alvo (normalmente o jogador)
    public Transform target;
    
    // Velocidade de suavização do movimento da câmera
    public float smoothSpeed = 0.125f;
    
    // Deslocamento opcional em x, caso deseje um offset
    public float offsetX = 0f;

    void LateUpdate()
    {
        // Cria uma posição desejada mantendo a posição y e z atuais da câmera,
        // mas atualizando o x para seguir o alvo
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
        
        // Suaviza a transição da posição atual para a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}