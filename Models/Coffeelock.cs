using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace CoffeelockSharp.Models
{
    internal class Coffeelock
    {
        #region Fields
        private int _warlockLevel;
        private int _sorcererLevel;
        private int _pactSlots;
        private int _sorceryPoints;
        #endregion

        #region Properties
        public int SorcererLevel
        {
            get => _sorcererLevel;
            set
            {
                if (WarlockLevel + value <= 20)
                {
                    _sorcererLevel = value;
                    UpdateStructureFromLevels();
                }
            }
        }
        
        public int WarlockLevel
        {
            get => _warlockLevel;
            set
            {
                if (SorcererLevel + value <= 20)
                {
                    _warlockLevel = value;
                    UpdateStructureFromLevels();
                }
            }
        }

        public int PactSlots
        {
            get => _pactSlots;
            set
            {
                if(value > MaxPactSlots)
                {
                    _pactSlots = MaxPactSlots;
                }
                else if(value < 0)
                {
                    _pactSlots = 0;
                }
                else
                {
                    _pactSlots = value;
                }
            }
        }
        public int MaxPactSlots { get; private set; }

        public int PactSlotLevel { get; private set; }

        public int SorceryPoints
        {
            get => _sorceryPoints;
            set
            {
                if(value > MaxSorceryPoints)
                {
                    _sorceryPoints = MaxSorceryPoints;
                }
                else if(value < 0)
                {
                    _sorceryPoints = 0;
                }
                else
                {
                    _sorceryPoints = value;
                }
            }
        }
        public int MaxSorceryPoints { get; private set; }

        public Indexer<int> SpellSlots { get; private set; }
        public Indexer<int> MaxSpellSlots { get; private set; }
        #endregion

        public Coffeelock() :
            this(2, 1)
        { }

        public Coffeelock(int sorcererLevel, int warlockLevel)
        {
            _sorcererLevel = sorcererLevel;
            _warlockLevel = warlockLevel;

            UpdateStructureFromLevels();
        }

        #region Methods
        public void ShortRest()
        {
            PactSlots = MaxPactSlots;
        }

        public void LongRest()
        {
            ShortRest();

            for(int i = 1; i <= MaxSpellSlots.Count(); ++i)
            {
                SpellSlots[i] = MaxSpellSlots[i];
            }

            SorceryPoints = MaxSorceryPoints;
        }

        public void CastSpell(int level)
        {
            if (SpellSlots[level] > 0)
            {
                SpellSlots[level] -= 1;
            }
        }

        public void SpendPoint()
        {
            SorceryPoints -= 1;
        }

        public void CastPact()
        {
            PactSlots -= 1;
        }

        public void CreateSpell(int level)
        {
            if (SorceryPoints >= Constants.SLOT_POINT_COST[level])
            {
                SorceryPoints -= Constants.SLOT_POINT_COST[level];
                SpellSlots[level] += 1;
            }
        }

        public void DestroySpell(int level)
        {
            if (SpellSlots[level] >= 1)
            {
                SpellSlots[level] -= 1;
                SorceryPoints += Constants.POINTS_PER_SLOT[level];
            }
        }

        public void DestroyPact()
        {
            if (PactSlots >= 1)
            {
                PactSlots -= 1;
                SorceryPoints += Constants.POINTS_PER_SLOT[PactSlotLevel];
            }
        }
        #endregion

        [MemberNotNull(nameof(MaxSpellSlots),nameof(MaxPactSlots),nameof(SpellSlots))]
        private void UpdateStructureFromLevels()
        {
            MaxSpellSlots = Constants.SLOTS_PER_SORCERER_LEVEL[SorcererLevel];
            SpellSlots = new Indexer<int>(MaxSpellSlots);

            MaxPactSlots = Constants.PACT_SLOTS_PER_WARLOCK_LEVEL[WarlockLevel];
            PactSlots = MaxPactSlots;

            PactSlotLevel = Constants.PACT_LEVELS_PER_WARLOCK_LEVEL[WarlockLevel];

            MaxSorceryPoints = Constants.POINTS_PER_SORCERER_LEVEL[SorcererLevel];
            SorceryPoints = MaxSorceryPoints;
        }

        #region Singleton
        private static Coffeelock _instance = new();

        public static Coffeelock Instance
        {
            get => _instance;
        }
        #endregion
    }
}
