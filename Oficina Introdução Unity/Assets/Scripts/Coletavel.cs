﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [Tooltip("Ponha aqui a referência ao GameObject que tenha o script de pontuação")]
    [SerializeField] private Pontuacao scriptPontuacao;

    [Tooltip("O Scriptable Object com as informações do coletável")]
    [SerializeField] private InfoColetavel scriptableObjectDoColetavel;

    private AudioSource som;
    private ParticleSystem particula;

    // Start is called before the first frame update
    void Start()
    {
        if (scriptPontuacao == null)
        {
            FindObjectOfType<Pontuacao>();
        }

        if(scriptableObjectDoColetavel.somATocar != null)
        {
            //som.
        }

        particula = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        TratarColisao();
    }

    private void OnTriggerEnter(Collider other)
    {
        TratarColisao();
    }

    // Faz tudo o que é necessário para cada colisão
    private void TratarColisao()
    {
        if (scriptableObjectDoColetavel.destruirColetavel)
            Destroy(this);

        if(audioATocar != null)
            audioATocar.Play();

        if (particula != null)
            particula.Play();

        scriptPontuacao.AumentarPontuacao()
    }
}
