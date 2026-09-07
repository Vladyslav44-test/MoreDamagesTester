using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDamagesTester
{
    internal class WeaponDamage
    {
        private int roll;
        /// <summary>
        /// Видає або задає результат кидку кубиків.
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }
        private bool flaming;
        /// <summary>
        /// Видає або задає вогняний ефект для зброї.
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }
        private bool magic;
        /// <summary>
        /// Видає або задає магічний ефект для зброї.
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }
        /// <summary>
        /// Видає або задає значення вирахуваної шкоди від зброї.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Вираховує значення шкоди по формулі, використовуючи значення Roll, Magic та Flaming.
        /// </summary>
        protected virtual void CalculateDamage()
        {
            /// Перевизначається в субклассах.
        }

        /// <summary>
        /// Задає початкове значення кидка кубиків властивості Roll та вираховує початкову шкоду від зброї.
        /// </summary>
        /// <param name="roll">Значення кидка кубиків.</param>
        public WeaponDamage(int roll)
        {
            Roll = roll;
            CalculateDamage();
        }
    }
}
