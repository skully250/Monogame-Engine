﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaeForest.Entity
{
    class EntityStateEngine
    {
        private Dictionary<String, bool> states;

        public EntityStateEngine()
        {
            states = new Dictionary<String, bool>();
        }

        public bool checkState(String name)
        {
            bool ret = states.TryGetValue(name, out ret);
            return ret;
        }

        public void AddState(String name)
        {
            states.Add(name, false);
        }

        public void RemoveState(String name)
        {
            states.Remove(name);
        }
    }
}