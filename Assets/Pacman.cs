using UnityEngine;

namespace theGame
{
    public class Pacman : MonoBehaviour
    {
        public GameObject player;

        public int calculate(int a, int b)
        {
            var c = a * b;//+ power(a+1);
            return c;
        }

        private int power(int a)
        {
            return a * a;
        }
    }
    
    
}