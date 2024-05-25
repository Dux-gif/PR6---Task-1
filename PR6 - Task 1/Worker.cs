using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6___Task_1
{
    public struct Worker
    {
        int id;

        string Time;
        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        string Fio;

        /// <summary>
        /// Поле "Должность"
        /// </summary>
        int age;

        /// <summary>
        /// Поле "Отдел"
        /// </summary>
        int height;

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        string birthday;

        string placeBirthday;

        public Worker(int ID, string TIME, string FIO, int AGE, int HEIGHT, string BirthDay, string PlaceBirthday)
        {
            this.id = ID;
            this.Time = TIME;
            this.Fio = FIO;
            this.age = AGE;
            this.height = HEIGHT;
            this.birthday = BirthDay;
            this.placeBirthday = PlaceBirthday;

        }

        public string Print()
        {
            return $"{this.id,15} {this.Time,15} {this.Fio,15} {this.age,15} {this.height,15} {this.birthday,15} {this.placeBirthday,15}";
        }

        public int Id { get { return this.Id; } set { this.Id = value; } }

        public string TIME { get { return this.TIME; } set { this.TIME = value; } }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string FIO { get { return this.FIO; } set { this.FIO = value; } }

        /// <summary>
        /// Должность
        /// </summary>
        public int Age { get { return this.Age; } set { this.Age = value; } }

        /// <summary>
        /// Отдел
        /// </summary>
        public int Height { get { return this.Height; } set { this.Height = value; } }

        /// <summary>
        /// Оплата труда
        /// </summary>
        public string Birthday { get { return this.Birthday; } set { this.Birthday = value; } }

        /// <summary>
        /// Почасовая оплата
        /// </summary>
        public string PlaceBirthday { get { return this.PlaceBirthday; } set { this.PlaceBirthday = value; } }
    }
}
