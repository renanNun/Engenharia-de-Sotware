using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuizQuestion
{
    private string question;
    private List<string> answers;
    private int correctAnswer;

    public QuizQuestion(string question, List<string> answers, int correctAnswer) {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }

    public string getQuestion() {
        return question;
    }

    public List<string> getAnswers() {
        return answers;
    }

    public int getCorrectAnswer() {
        return correctAnswer;
    }

}
