using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using System.Collections;
using NUnit.Framework;

using System;using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TheGame;
using UnityEngine;
using UnityEngine.TestTools;


    public class PacmanTests
    {

        public Pacman testingObj;
        [Test]
        public void AssetsTestsSimplePasses()
        {
            testingObj = new Pacman();
            
            Assert.IsNull(testingObj);



        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [Test]
        public void AssetsTestsWithEnumeratorPasses()
        {
            testingObj = new Pacman();
            var x = testingObj.calculate(2, 2);
            Assert.AreEqual(13,x);
        }
        
        [Test]
        public void powerTest()
        {
            testingObj = new Pacman();
            var x = testingObj.calculate(2, 2);
            Assert.AreEqual(4,x);

        }
        
    }
