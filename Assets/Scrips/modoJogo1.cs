using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.EventSystems;

public class modoJogo1 : MonoBehaviour
{
    [Header("Config Textos")]
    public Text nomeTemaTxt;
    public Text perguntaTxt;
    public Image perguntaImg;
    public Text infoRespostaxt;
    public Text notaFinalTxt;
    public Text msg1Txt;
    public Text msg2Txt;

    [Header("Config dos Texto Alternativas")]
    public Text altAtxt;
    public Text altBtxt;
    public Text altCtxt;
    public Text altDtxt;

    [Header("Config dos Imagens Alternativas")]
    public Image altAImg;
    public Image altBImg;
    public Image altCImg;
    public Image altDImg;

    [Header("Config Barras")]
    public GameObject barraProgresso;
    public GameObject barraTempo;

    [Header("Config Botoes")]
    public Button[] botoes;
    public Color corAcerto, corErro;

    [Header("Config Perguntas")]
    public Sprite[] perguntasIMG;
    public string[] perguntas;
    public string[] correta;
    public int qtdPeguntas;
    public List<int> listaPerguntas;

    [Header("Config Alternativas")]

    public string[] alternativasA;
    public string[] alternativasB;
    public string[] alternativasC;
    public string[] alternativasD;

    [Header("Config Alternativas IMG")]

    public Sprite[] alternativasAimg;
    public Sprite[] alternativasBimg;
    public Sprite[] alternativasCimg;
    public Sprite[] alternativasDimg;


    [Header("Config Modo de Jogo")]
    public bool perguntasComIMG;
    public bool perguntasAleatorias;
    public bool utilizarAlternaticas;
    public bool utilizarAlternaticasIMG;
    public bool jogarComTempo;
    public float tempoResponder;
    public bool mostrarCorreta;
    public int qtdPiscar;
    public bool exibindoCorreta;

    [Header("Config dos Paineis")]
    public GameObject[] paineis;
    public GameObject[] estrela;


    [Header("Config das Mensagens")]
    public string[] mensagens1;
    public string[] mensagens2;

    //----------------

    private int idResponder, qtdAcertos, notaMin1Estrela, notaMin2Estrela, nEstrelas, idTema, idBtnCorreto;
    private float percProgresso, percTempo, qtdRespondidas, notaFinal, valorQuestao, tempTime;

    private soundCotroller soundCotroller;

    // Start is called before the first frame update
    void Start()
    {
        soundCotroller = FindObjectOfType(typeof(soundCotroller)) as soundCotroller;

        idTema = PlayerPrefs.GetInt("idTema");
        notaMin1Estrela = PlayerPrefs.GetInt("notaMin1Estrela");
        notaMin2Estrela = PlayerPrefs.GetInt("notaMin2Estrela");

        nomeTemaTxt.text = PlayerPrefs.GetString("nomeTema");


        barraTempo.SetActive(false);


        if(perguntasComIMG == true)
        {
            montarListaPerguntasIMG();
        }
        else
        {
         montarListaPerguntas();
        }

        progressaoBarra();
        controleBarraTempo();     

        paineis[0].SetActive(true);
        paineis[1].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (jogarComTempo == true && exibindoCorreta == false)
        {
            tempTime += Time.deltaTime;
            controleBarraTempo();

            if (tempTime >= tempoResponder) { proximaPergunta(); }
        }
    }


    //Montar lista de Perguntas com Textos.
    public void montarListaPerguntas()
    {
        if (qtdPeguntas > perguntas.Length) { qtdPeguntas = perguntas.Length; }
        valorQuestao = 10 / (float)qtdPeguntas;


        if (perguntasAleatorias == true)
        {
            bool addPerguntas = true;




            while (listaPerguntas.Count < qtdPeguntas)
            {
                addPerguntas = true;
                int rand = Random.Range(0, perguntas.Length);


                foreach (int idP in listaPerguntas)
                {
                    if (idP == rand)
                    {
                        addPerguntas = false;
                    }
                }

                if (addPerguntas == true) { listaPerguntas.Add(rand); }
            }

        }
        else
        {

            for (int i = 0; i < qtdPeguntas; i++)
            {
                listaPerguntas.Add(i);
            }


        }

        perguntaTxt.text = perguntas[listaPerguntas[idResponder]];


        if (utilizarAlternaticas == true && utilizarAlternaticasIMG == false)
        {
            altAtxt.text = alternativasA[listaPerguntas[idResponder]];
            altBtxt.text = alternativasB[listaPerguntas[idResponder]];
            altCtxt.text = alternativasC[listaPerguntas[idResponder]];
            altDtxt.text = alternativasD[listaPerguntas[idResponder]];
        }
        else if (utilizarAlternaticas == true && utilizarAlternaticasIMG == true)
        {
            altAImg.sprite = alternativasAimg[listaPerguntas[idResponder]];
            altBImg.sprite = alternativasBimg[listaPerguntas[idResponder]];
            altCImg.sprite = alternativasCimg[listaPerguntas[idResponder]];
            altDImg.sprite = alternativasDimg[listaPerguntas[idResponder]]; 
        }
    }

    //Montar lista de Perguntas com Imagens.
    public void montarListaPerguntasIMG()
    {
        if (qtdPeguntas > perguntasIMG.Length) { qtdPeguntas = perguntasIMG.Length; }
        valorQuestao = 10 / (float)qtdPeguntas;

        if (perguntasAleatorias == true)
        {
            bool addPerguntas = true;
            

            while (listaPerguntas.Count < qtdPeguntas)
            {
                addPerguntas = true;
                int rand = Random.Range(0, perguntasIMG.Length);

                foreach (int idP in listaPerguntas)
                {
                    if (idP == rand)
                    {
                        addPerguntas = false;
                    }
                }

                if (addPerguntas == true) { listaPerguntas.Add(rand); }
            }

        }
        else
        {

            for (int i = 0; i < qtdPeguntas; i++)
            {
                listaPerguntas.Add(i);
            }

        }

        perguntaImg.sprite = perguntasIMG[listaPerguntas[idResponder]];


        if (utilizarAlternaticas == true && utilizarAlternaticasIMG == false)
        {
            altAtxt.text = alternativasA[listaPerguntas[idResponder]];
            altBtxt.text = alternativasB[listaPerguntas[idResponder]];
            altCtxt.text = alternativasC[listaPerguntas[idResponder]];
            altDtxt.text = alternativasD[listaPerguntas[idResponder]];
        }
        else if (utilizarAlternaticas == true && utilizarAlternaticasIMG == true)
        {
            altAImg.sprite = alternativasAimg[listaPerguntas[idResponder]];
            altBImg.sprite = alternativasBimg[listaPerguntas[idResponder]];
            altCImg.sprite = alternativasCimg[listaPerguntas[idResponder]];
            altDImg.sprite = alternativasDimg[listaPerguntas[idResponder]];
        }
    }

    //Função responsavel por processar a resposta dada pelo jogador.
    public void responder(string alternativa)
    {
        //verifica se o modo de jogo esta setado para exibir as alternaticas corretas.
        if (exibindoCorreta == true) { return; }

        qtdRespondidas += 1;
        progressaoBarra();

        //verifica de a resposta esta correta e incrementa 1 na quantidade de acertos.
        if (correta[listaPerguntas[idResponder]] == alternativa)
        {
            qtdAcertos += 1;
            soundCotroller.playAcerto();
        }
        else
        {
            soundCotroller.playErro();
        }

        switch (correta[listaPerguntas[idResponder]])
        {
            case "A":
                idBtnCorreto = 0;
                break;
            case "B":
                idBtnCorreto = 1;
                break;
            case "C":
                idBtnCorreto = 2;
                break;
            case "D":
                idBtnCorreto = 3;
                break;
        }


        //Altera a cor dos botões 
        if (mostrarCorreta == true)
        {
            foreach (Button b in botoes)
            {
                b.image.color = corErro;
            }
            exibindoCorreta = true;
            botoes[idBtnCorreto].image.color = corAcerto;
            StartCoroutine("mostrarAlternaticaCorreta");
        }
        else
        {
            StartCoroutine("aguardarProxima");
        }


    }

    public void proximaPergunta()
    {
        idResponder += 1;
        tempTime = 0;

        EventSystem.current.SetSelectedGameObject(null);
    
        if (idResponder < listaPerguntas.Count)
        {
            if (perguntasComIMG == true)
            {
                perguntaImg.sprite = perguntasIMG[listaPerguntas[idResponder]];
            }
            else
            {
                perguntaTxt.text = perguntas[listaPerguntas[idResponder]];
            }

            if (utilizarAlternaticas == true && utilizarAlternaticasIMG == false)
            {
                altAtxt.text = alternativasA[listaPerguntas[idResponder]];
                altBtxt.text = alternativasB[listaPerguntas[idResponder]];
                altCtxt.text = alternativasC[listaPerguntas[idResponder]];
                altDtxt.text = alternativasD[listaPerguntas[idResponder]];
            }
            else if (utilizarAlternaticas == true && utilizarAlternaticasIMG == true)
            {
                altAImg.sprite = alternativasAimg[listaPerguntas[idResponder]];
                altBImg.sprite = alternativasBimg[listaPerguntas[idResponder]];
                altCImg.sprite = alternativasCimg[listaPerguntas[idResponder]];
                altDImg.sprite = alternativasDimg[listaPerguntas[idResponder]];
            }

        }
        else
        {
            calcularNotaFinal();
        }
    }

    void progressaoBarra()
    {
        infoRespostaxt.text = "Respondeu " + qtdRespondidas + " de " + listaPerguntas.Count + " perguntas";
        percProgresso = qtdRespondidas / listaPerguntas.Count;
        barraProgresso.transform.localScale = new Vector3(percProgresso, 1, 1);

    }

    void controleBarraTempo()
    {
        if (jogarComTempo == true) { barraTempo.SetActive(true); }
        percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;
        if (percTempo < 0) { percTempo = 0; }
        barraTempo.transform.localScale = new Vector3(percTempo, 1, 1);
    }

    void calcularNotaFinal()
    {
        notaFinal = Mathf.RoundToInt(valorQuestao * qtdAcertos);

        if (notaFinal > PlayerPrefs.GetInt("notaFinal_" + idTema.ToString()))
        {
            PlayerPrefs.SetInt("notaFinal_" + idTema.ToString(), (int)notaFinal);
        }

        notaFinalTxt.text = notaFinal.ToString();

        if (notaFinal == 10) { nEstrelas = 3; }
        else if (notaFinal >= notaMin2Estrela) { nEstrelas = 2; }
        else if (notaFinal >= notaMin1Estrela) { nEstrelas = 1; }

        msg1Txt.text = mensagens1[nEstrelas];
        msg2Txt.text = mensagens2[nEstrelas];

        foreach (GameObject e in estrela)
        {
            e.SetActive(false);
        }

        for (int i = 0; i < nEstrelas; i++)
        {
            estrela[i].SetActive(true);
        }



        paineis[0].SetActive(false);
        paineis[1].SetActive(true);
    }

    IEnumerator aguardarProxima()
    {
        yield return new WaitForSeconds(1);
        exibindoCorreta = false;
        proximaPergunta();
    }


    IEnumerator mostrarAlternaticaCorreta()
    {
        for (int i = 0; i < qtdPiscar; i++)
        {
            botoes[idBtnCorreto].image.color = corAcerto;
            yield return new WaitForSeconds(0.2f);
            botoes[idBtnCorreto].image.color = Color.white;
            yield return new WaitForSeconds(0.2f);

        }

        foreach (Button b in botoes)
        {
            b.image.color = Color.white;
        }

        exibindoCorreta = false;
        proximaPergunta();
    }

}
