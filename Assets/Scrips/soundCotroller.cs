using System.Collections;//
using System.Collections.Generic;
using UnityEngine;

public class soundCotroller : MonoBehaviour
{
    public AudioSource audioMusic , audioFX;
    public AudioClip somAcerto, somErro, somBotao,vinhetaTresEstrelas;
    public AudioClip[] musicas;

     void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        carregarPreferencias();
        audioMusic.clip = musicas[0];
        audioMusic.Play();
    }


    public void playAcerto()
    {
        audioFX.PlayOneShot(somAcerto);
    }

    public void playErro()
    {
        audioFX.PlayOneShot(somErro );

    }

    public void playButton()
    {
        audioFX.PlayOneShot(somBotao);
    }

    void carregarPreferencias()
    {
        //verifica de ha registro dos valores iniciais de configuracai, se não  houver, grava valores uniciais
        if(PlayerPrefs.GetInt("valoresDefault") == 0)
        { 
            PlayerPrefs.SetInt("valoresDefault", 1);
            PlayerPrefs.SetInt("onOffMusica", 1);
            PlayerPrefs.SetInt("onOffEfeitos", 1);
            PlayerPrefs.SetFloat("volumeMusica", 1);
            PlayerPrefs.SetFloat("volumeEfeitos", 1);
        }

        //carrega os valores de configuracao de sons e musioca
        int onOffMusica = PlayerPrefs.GetInt("onOffMusica");
        int onOffEfeito = PlayerPrefs.GetInt("onOffEfeitos");
        float volumeMusica = PlayerPrefs.GetFloat("volumeMusica");
        float volumeEfeito = PlayerPrefs.GetFloat("volumeEfeitos");

        bool tocarMusica = false;
        bool tocarEfeitos = false;

        if(onOffMusica ==  1) { tocarMusica = true; }
        if(onOffEfeito ==  1) { tocarEfeitos = true; }

        audioMusic.mute = !tocarMusica;
        audioFX.mute = !tocarEfeitos;

        audioMusic.volume = volumeMusica;
        audioFX.volume = volumeEfeito;
    }

}
