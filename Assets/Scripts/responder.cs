using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

    private int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public string[] perguntas; //armazena perguntas
    public string[] alternativaA; //armazena respostas A
    public string[] alternativaB; //armazena respostas B
    public string[] alternativaC; //armazena respostas C
    public string[] alternativaD; //armazena respostas D
    public string[] alternativaCorreta; //armazena respostas corretas

    private int idPergunta;

    private float acertos; 
    private float qtdQuestoes; //quantidade de questoes
    private float media; //calculo da media de acertos
    private int notaFinal;

    // Use this for initialization
    void Start () {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0; //inicio da primeira pergunta
        qtdQuestoes = perguntas.Length;

        pergunta.text = perguntas[idPergunta]; //leitor das perguntas
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        infoRespostas.text = "Questões: " + (idPergunta + 1).ToString() + "/" + qtdQuestoes.ToString(); //informacao da resposta
    }
	
	public void resposta(string alternativa)
    {
        if (alternativa == "A"){
            if (alternativaA[idPergunta] == alternativaCorreta[idPergunta]){
                acertos += 1;
            }
        }
        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == alternativaCorreta[idPergunta]){
                acertos += 1;
            }
        }
        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == alternativaCorreta[idPergunta]){
                acertos += 1;
            }
        }

        else if (alternativa == "D")
        {
            if (alternativaA[idPergunta] == alternativaCorreta[idPergunta]){
                acertos += 1;
            }
        }

        proximaPergunta(); //chama funcao Proxima Pergunta
	}

    void proximaPergunta() //proxima pergunta
    {
        idPergunta++;

        if (idPergunta <= (qtdQuestoes - 1)) //calcula quantdade de perguntas para sair
        {
            pergunta.text = perguntas[idPergunta]; //leitor das perguntas
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            infoRespostas.text = "Questões: " + (idPergunta + 1).ToString() + "/" + qtdQuestoes.ToString(); //informacao da resposta
        }
        else //termino da fase
        {
            media = 10 * (acertos / qtdQuestoes); //calculo da media da nota
            notaFinal = Mathf.RoundToInt(media); //arredonda a nota p/ inteiro

            if(notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal); //grava nota final do usuario em novo recorde
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos); //grava acertos do usuario (convertendo p/ inteiro)
            }

            PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal); //grava nota final do usuario da partida
            PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos); //grava acertos do usuario (convertendo p/ inteiro)

            Application.LoadLevel("NotaFinal");
        }
    }
}
