using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDamagesTester
{
    internal class SwordDamage : WeaponDamage
    {
        /// <summary>
        /// Константа для додавання до шкоди під час її вирахування (базова шкода).
        /// </summary>
        private const int BASE_DAMAGE = 3;
        /// <summary>
        /// Константа для додавання до шкоди під час її вирахування (додаткова шкода від вогняного ефекту).
        /// </summary>
        private const int FLAME_DAMAGE = 2;

        /// <summary>
        /// Вираховує значення шкоди по формулі, використовуючи значення Roll, Magic та Flaming
        /// (Якщо меч магічний, результат кидку множиться на 1.75; якщо меч вогняний, до вирахуваної шкоди додаються пошкодження від вогню).
        /// </summary>
        protected override void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }

        /// <summary>
        /// Задає початкове значення кидка 3D6 властивості Roll та вираховує початкову шкоду від меча.
        /// </summary>
        /// <param name="roll">Значення кидка 3D6.</param>
        public SwordDamage(int roll) : base(roll)
        {
            /// Викликає конструктор базового класу.
        }
    }

    internal class ArrowDamage : WeaponDamage
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

        /// <summary>
        /// Вираховує значення шкоди по формулі, використовуючи значення Roll, Magic та Flaming
        /// (Якщо стріла магічна, результат множиться на 2.5; якщо стріла вогняна, до вирахуваної шкоди додаються пошкодження від вогню).
        /// </summary>
        protected override void CalculateDamage()
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
        public ArrowDamage(int roll) : base(roll)
        {
            /// Викликає конструктор базового класу.
        }
    }
}
