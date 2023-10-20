using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Warrior.Characters.Monsters
{
    internal class Abyssal_Shadow : Monster
    {
        public Abyssal_Shadow()
        {
            _name = "Abyssal Shadow";
            _level = 1;
            _maxHP = 25;
            _currentHP = _maxHP;
            _attack = 15;
            _defence = 0;
            _xpDrop = 20;
            _description = $"A nightmarish entity emerges from the inky blackness of the labyrinth's depths, " +
                $"\nits form shrouded in the deepest darkness. It stares at you with blood-red eyes.";

            _deathDescriptions = new string[]
            {
               "In an uncanny spectacle, the Abyssal Shadow unravels, its malevolence dispersing into thin air. " +
               "A fading whisper of the supernatural heralds its final act, as it fades away into the abyss.",

               "With a sibilant sigh, the Abyssal Shadow ebbs away, its dark presence waning until only a spectral echo remains, " +
               "dissolving into the void.",

               "The Abyssal Shadow yields to the inexorable pull of the void. Its formidable presence crumbles into spectral wisps, " +
               "surrendering to the unseen forces of the abyss.",

               "Like dissipating smoke, the Abyssal Shadow scatters into nothingness, relinquishing its grip on the world to " +
               "\nbecome but a memory, " +
               "slowly fading into obscurity.",

               "The Abyssal Shadow's spectral form ebbs away, its once-menacing silhouette giving way to an ethereal resonance before " +
               "\nvanishing, " +
               "leaving only a lingering spectral echo."
            };

        }
        

        public override void AttackDescription()
        {
            string attack = $"The {_name} lunges at you, its razor-sharp claws slashing through the air.";
            MapMethods.SlowText(attack);
        }
    }
}
