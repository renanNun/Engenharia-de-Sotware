using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestMainPage
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("BinarySearchTree");
    }
    
}
