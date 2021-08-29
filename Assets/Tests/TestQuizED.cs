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
