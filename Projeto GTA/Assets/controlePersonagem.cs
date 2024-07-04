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
