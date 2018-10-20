using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyWPF
{
    class Employee
    {
        public string FName {get; set;}
        public string SName {get; set;}
        public string BirthCity {get; set;}
        public string Hobby {get; set;}

        List<Employee> people = new List<Employee>();
        
        public void Add()
        {
            people.Add(new Employee() { FName = "Антон", SName = "Иванов",
                BirthCity = "Пермь", Hobby = "Шахматы" });
            people.Add(new Employee() { FName = "Мария", SName = "Петрова",
                BirthCity = "Москва", Hobby = "Вязание" });
            people.Add(new Employee() { FName = "Семен", SName = "Сидоров",
                BirthCity = "Москва", Hobby = "Компьютерные игры" });
            people.Add(new Employee() { FName = "Евгений", SName = "Чехов",
                BirthCity = "Санкт-Петербург", Hobby = "Велосипед" });
            people.Add(new Employee() { FName = "Тихон", SName = "Синицин",
                BirthCity = "Воронеж", Hobby = "Бег" });
            people.Add(new Employee() { FName = "Анастасия", SName = "Скворцова",
                BirthCity = "Ростов-на-Дону", Hobby = "Живопись" });
            people.Add(new Employee() { FName = "Елизавета", SName = "Вишневская",
                BirthCity = "Воронеж", Hobby = "Автогонки" });
            people.Add(new Employee() { FName = "Анна", SName = "Селиванова",
                BirthCity = "Москва", Hobby = "Городские квесты" });
            people.Add(new Employee() { FName = "Татьяна", SName = "Горбунова",
                BirthCity = "Нижний Новгород", Hobby = "Танцы" });
        }

        //public void VivodnaEkran()
        //{
        //    foreach (Employee e in people) Console.WriteLine(e.people);
        //}
    }
}
