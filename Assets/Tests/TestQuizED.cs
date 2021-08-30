using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestQuizED
{
    [SetUp]
    public void Setup() => SceneManager.LoadScene("QuizED");

    [UnityTest]
    public IEnumerator TestIfHasButtons()
    {
        var buttons = Object.FindObjectsOfType<Button>();

        Assert.IsNotNull(buttons);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestNumberOfButtons()
    {
        var buttons = Object.FindObjectsOfType<Button>();

        Assert.AreEqual(buttons.Length, 3);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestIfButtonHasGenericText()
    {
        // Butão 1
       var button = GameObject.FindGameObjectsWithTag("A1")[0];

        var value = button.GetComponentInChildren<Text>().text;
        Assert.AreNotEqual(value,"A1");

        // Botão 2
        button = GameObject.FindGameObjectsWithTag("A2")[0];
        value = button.GetComponentInChildren<Text>().text;
        Assert.AreNotEqual(value,"A2");

        // Botão 3
        button = GameObject.FindGameObjectsWithTag("A3")[0];
        value = button.GetComponentInChildren<Text>().text;
        Assert.AreNotEqual(value,"A3");
        
        yield return null;
    }

}
