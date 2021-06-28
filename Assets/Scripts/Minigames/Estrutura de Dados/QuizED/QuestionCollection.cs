using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionCollection
{
    static public List<QuizQuestion> questions;

    static public void LoadQuestions() {

        QuizQuestion question1 = new QuizQuestion("Qual a complexidade da busca binária?",
                                                    new List<string>(){"O(n)", "O(log(n))", "O(n!)"},
                                                    1);

        this.questions = new List<QuizQuestion>(){question1};
    }

    static public QuizQuestion GetQuestion() {
        QuizQuestion question = this.questions.OrderBy(t => UnityEngine.Random.Range(0, int.MaxValue))
                                            .FirstOrDefault();

        return question;
    }

}
