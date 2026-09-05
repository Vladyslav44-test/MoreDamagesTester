using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDamagesTester
{
    internal class ArrowDamage
    {
        /// <summary>
        /// Константа для множення шкоди під час її вирахування (базовий множник).
        /// </summary>
        private const decimal BASE_MULTIPLIER = 0.35M;
        /// <summary>
        /// Константа для множення шкоди під час її вирахування (магічний множник).
        /// </summary>
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        /// <summary>
        /// Константа для додавання до шкоди під час її вирахування (додаткова шкода від вогняного ефекту).
        /// </summary>
        private const decimal FLAME_DAMAGE = 1.25M;

        private int roll;
        /// <summary>
        /// Видає або задає результат кидку 1D6.
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
        /// Видає або задає вогняний ефект для стріли.
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
        /// Видає або задає магічний ефект для стріли.
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
        /// Видає або задає значення вирахуваної шкоди від стріли.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Вираховує значення шкоди по формулі, використовуючи значення Roll, Magic та Flaming
        /// (Якщо стріла магічна, результат множиться на 2.5; якщо стріла вогняна, до вирахуваної шкоди додаються пошкодження від вогню).
        /// </summary>
        private void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) baseDamage *= MAGIC_MULTIPLIER;
            if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
            else Damage = (int)Math.Ceiling(baseDamage);
        }

        /// <summary>
        /// Задає початкове значення кидка 1D6 властивості Roll та вираховує початкову шкоду від стріли.
        /// </summary>
        /// <param name="roll">Значення кидка 1D6.</param>
        public ArrowDamage(int roll)
        {
            Roll = roll;
            CalculateDamage();
        }
    }
}
