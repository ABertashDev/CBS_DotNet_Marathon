﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{
    [Serializable]
    public class Task
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }


        public Task(string name, string description = "", bool isCompleted = false)
        {
            Name = name;
            Description = description;
            IsCompleted = isCompleted;
        }

    }
}
