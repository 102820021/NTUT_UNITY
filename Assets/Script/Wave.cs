using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public class Wave
    {
        public List<int> _enemyFormation;
        public bool _isRandom;
        public bool _canMove;

        public Wave()
        {
            _enemyFormation = new List<int>();
        }

    }
}
