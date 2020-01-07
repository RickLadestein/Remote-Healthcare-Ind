using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor
{
    public class Patient : User
    {
        public string first_name;
        public string sur_name;
        public DateTime birthday;
        public bool gender;
        public int height;
        public int weight;

        public Patient(string first_name, string sur_name, DateTime birthday, bool gender, int height, int weight)
        {
            this.first_name = first_name;
            this.sur_name = sur_name;
            this.birthday = birthday;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
        }

        public int getAge()
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(birthday.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            return age;
        }

        public override string ToString()
        {
            return $"{this.first_name} {this.sur_name}";
        }
    }
}
