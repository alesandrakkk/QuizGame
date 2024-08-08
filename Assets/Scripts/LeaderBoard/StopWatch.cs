using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeaderBoard
{
    public class StopWatch
    {
        private float startTime;

        public void Start()
        {
            startTime = Time.time;
        }

        public float Stop()
        {
            var delta = Time.time - startTime;
            startTime = 0;
            return delta;
        }
    }
}
