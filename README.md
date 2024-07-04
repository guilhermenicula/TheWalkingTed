## The Walking Ted

**Descrição do Jogo:**

The Walking TED é um game de ação e sobrevivência onde um ex escoteiro chamado Ted tenta sobreviver em meio a um caos apocalíptico. O objetivo do jogo é o player usar suas habilidades de movimentação, corrida e dash para correr dos zumbis e sobreviver o máximo que aguentar.

**Instruções para Jogabilidade:**

- **Movimentação:**  Utilizando as teclas W, A, S, D para movimentar Ted pela cidade.
- **Correr:** Segure a tecla Ctrl para aumentar a velocidade de corrida de Ted.
- **Mudar Tempo:** Pressione a tecla Q para alternar entre dia e noite. Isso pode afetar a visibilidade e o comportamento dos zumbis.
- **Dash:** Pressione a tecla Shift para dar um dash para frente e conseguir fugir de uma enrascada.

**Gameplay:**
Vídeo demonstrativo de gameplay do jogo:
- **Link: https://youtu.be/y_3xp551iVw](https://youtu.be/Kl1k8gniJ3M**

**Prints do jogo:**
  
- **Menu do Jogo:**
  
![zoobie](https://github.com/guilhermenicula/TheWalkingTed/assets/61329619/1bda61da-6510-4295-80cc-36a78d2fbf02)

- **Print No centro da cidade a anoite:**
  
![Captura de tela 2024-07-04 193301](https://github.com/guilhermenicula/TheWalkingTed/assets/61329619/0d750606-1c66-46bb-b223-affc085b2294)

- **Print na floresta:**
  
![Captura de tela 2024-07-04 193651](https://github.com/guilhermenicula/TheWalkingTed/assets/61329619/7a62e38c-eba0-46c8-91a3-bb5be774f933)

**Funcionalidades Desenvolvidas:**
- **Correr**
Foi implementado um sistema que permite ao jogador aumentar a velocidade do personagem quando a tecla Ctrl é pressionada, facilitando a fuga dos zumbis.

**Código:**
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float runningMultiplier = 2.0f; // Multiplicador para a corrida
    [SerializeField] private float dashSpeed = 20f; // Velocidade durante o Dash
    [SerializeField] private float dashDuration = 0.2f; // Duração do Dash
    [SerializeField] private float dashCooldown = 1f; // Cooldown do Dash
    private Animator heroi;
    private bool isDashing = false;
    private float dashCooldownTime;

    void Start()
    {
        heroi = GetComponent<Animator>();
    }

    void Update()
    {
        bool isMoving = false;
        float currentSpeed = speed;

        // Verifica se a tecla Control está pressionada para correr
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            currentSpeed *= runningMultiplier; // Dobra a velocidade
        }

        // Verifica se alguma tecla de movimento está pressionada
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }

        // Movimentação para frente e para trás
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * currentSpeed);
        }

        // Rotação para esquerda e direita
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > dashCooldownTime && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // Atualiza as variáveis do Animator
        heroi.SetBool("Correndo", isMoving);
        heroi.SetBool("Parado", !isMoving);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * dashSpeed);
            yield return null;
        }

        isDashing = false;
        dashCooldownTime = Time.time + dashCooldown;
    }
}
```

![Captura de tela 2024-07-04 193445](https://github.com/guilhermenicula/TheWalkingTed/assets/61329619/6aa5c1b4-0b79-4cdc-b61c-ef04db09b887)


- **Dash**
Foi adicionado um sistema que permite ao jogador dashar o personagem para frente no mapa, usando a tecla shift para facilitar a fuga estratégica dos zumbis.

**Código:**
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float runningMultiplier = 2.0f; // Multiplicador para a corrida
    [SerializeField] private float dashSpeed = 20f; // Velocidade durante o Dash
    [SerializeField] private float dashDuration = 0.2f; // Duração do Dash
    [SerializeField] private float dashCooldown = 1f; // Cooldown do Dash
    private Animator heroi;
    private bool isDashing = false;
    private float dashCooldownTime;

    void Start()
    {
        heroi = GetComponent<Animator>();
    }

    void Update()
    {
        bool isMoving = false;
        float currentSpeed = speed;

        // Verifica se a tecla Control está pressionada para correr
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            currentSpeed *= runningMultiplier; // Dobra a velocidade
        }

        // Verifica se alguma tecla de movimento está pressionada
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }

        // Movimentação para frente e para trás
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * currentSpeed);
        }

        // Rotação para esquerda e direita
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > dashCooldownTime && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // Atualiza as variáveis do Animator
        heroi.SetBool("Correndo", isMoving);
        heroi.SetBool("Parado", !isMoving);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * dashSpeed);
            yield return null;
        }

        isDashing = false;
        dashCooldownTime = Time.time + dashCooldown;
    }
}
```

![Captura de tela 2024-07-04 193651](https://github.com/guilhermenicula/TheWalkingTed/assets/61329619/eb726d9c-6b13-4c67-9c12-55b6f9d0b67c)




