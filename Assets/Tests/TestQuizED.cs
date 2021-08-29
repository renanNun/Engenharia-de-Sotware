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
        Object[] buttons = Object.FindObjectsOfType<Button>();

        var value;

        // Butão 1
        value = buttons[0].GetComponentInChildren<Text>().text;
        Assert.AreNotEqual(value,"A1");

        // Botão 2
        value = buttons[1].GetComponentInChildren<Text>().text;
        Assert.AreNotEqual(value,"A2");

        // Botão 3
        value = buttons[2].GetComponentInChildren<Text>().text;
        Assert.AreNotEqual(value,"A3");
        
        yield return null;
    }

    [UnityTest]
    public IEnumerable TestCursorMovement()
    {
        var cursor = GameObject.Find("Cursor");
        var initialPos = cursor.transform.position;

        var topButton = Object.FindObjectsOfType<Button>()[0];
        topButton.onClick.Invoke();
        var movedPos = cursor.transform.position;

        Assert.AreNotEqual(initialPos, movedPos);
        yield return null;
    }

}
