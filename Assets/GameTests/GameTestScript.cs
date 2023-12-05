using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
// using theGame;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void GameTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    
    public void AssetsTestsSimplePasses()
    {
        // testingObj = new Pacman();
        //     
        // Assert.IsNull(testingObj);



    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GameTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
