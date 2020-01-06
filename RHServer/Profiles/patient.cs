using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    class Patient : User
    {
        public string first_name;
        public string sur_name;
        public int age;
        public int height;
        public int weight;

        public Patient(string first_name, string sur_name, int age, int height, int weight)
        {
            this.first_name = first_name;
            this.sur_name = sur_name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }
    }
}
