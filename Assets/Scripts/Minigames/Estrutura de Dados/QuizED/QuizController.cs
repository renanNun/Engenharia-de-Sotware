using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    private Tuple<int, int> statID = (5, 1).ToTuple();
    private QuizQuestion currentQuestion;
    public UIController uIController;
  

    // Start is called before the first frame update
    void Start()
    {
        testInfoSetup();
        QuestionCollection.LoadQuestions();
        this.currentQuestion = QuestionCollection.GetQuestion();
        ShowQuestion();
    }

    public void ShowQuestion() {
        uIController.SetupUIforQuestion(this.currentQuestion);
    }

    public void AnswerQuestion(int answerNumber) {
        bool isCorrect = answerNumber == this.currentQuestion.getCorrectAnswer();
        if (isCorrect)
        {
            incrementaAcertosSessao();
        }
        else
        {
            incrementaErrosSessao();
        }
        uIController.HandleSubmittedAnswer(isCorrect);
    }

    public void testInfoSetup()
    {
        if (!ControleSessao.instance.infoMinigames.ContainsKey(statID))
        {
            ControleSessao.instance.infoMinigames[statID] = new Dictionary<string, dynamic>();
            ControleSessao.instance.infoMinigamesSave.Add(salvaTaxaDeAcerto);
        }
    }

    public void incrementaAcertosSessao()
    {

        if (ControleSessao.instance.infoMinigames[statID].ContainsKey("acertos"))
        {
            ControleSessao.instance.infoMinigames[statID]["acertos"]++;
        }
        else
        {
            ControleSessao.instance.infoMinigames[statID]["acertos"] = 1;
        }
    }

    public void incrementaErrosSessao()
    {


        if (ControleSessao.instance.infoMinigames[statID].ContainsKey("erros"))
        {
            ControleSessao.instance.infoMinigames[statID]["erros"]++;
        }
        else
        {
            ControleSessao.instance.infoMinigames[statID]["erros"] = 1;
        }
    }

    public void salvaTaxaDeAcerto()
    {
        int acertos = ControleSessao.instance.infoMinigames[statID].ContainsKey("acertos") ?
            ControleSessao.instance.infoMinigames[statID]["acertos"] : 0;
        int erros = ControleSessao.instance.infoMinigames[statID].ContainsKey("erros") ?
            ControleSessao.instance.infoMinigames[statID]["erros"] : 0;
        float total = (float) (acertos + erros);
        ControleSessao.instance.appendEstatistica(5, 1, "Taxa de acertos nas ultimas partidas", acertos / total);

        ControleSessao.instance.infoMinigames[statID] = new Dictionary<string, dynamic>();
    }
    
}
