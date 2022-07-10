using System;
using System.Collections.Generic;
using System.Text;
using CoffeelockSharp.Models;
using System.ComponentModel;
using ReactiveUI;

namespace CoffeelockSharp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly string[] longRestProperties = new string[]
        {
            "SorceryPoints",
            "Slots1",
            "Slots2",
            "Slots3",
            "Slots4",
            "Slots5",
            "Slots6",
            "Slots7",
            "Slots8",
            "Slots9",
            "PactSlots"
        };

        private readonly Indexer<string> spellProperties = new(new string[]
        {
            "Slots1",
            "Slots2",
            "Slots3",
            "Slots4",
            "Slots5",
            "Slots6",
            "Slots7",
            "Slots8",
            "Slots9"
        });

        #region Method Bindings
        public void HandleLongRest()
        {
            Coffeelock.Instance.LongRest();

            foreach (string property in longRestProperties)
            {
                RaisePropertyChanged(property);
            }
                
        }

        public void HandleShortRest()
        {
            Coffeelock.Instance.ShortRest();

            RaisePropertyChanged("PactSlots");
        }

        public void HandleSpendPoint()
        {
            Coffeelock.Instance.SpendPoint();

            RaisePropertyChanged("SorceryPoints");
        }

        public void HandleCastSpell(int level)
        {
            Coffeelock.Instance.CastSpell(level);

            RaisePropertyChanged(spellProperties[level]);
        }

        public void HandleCastPact()
        {
            Coffeelock.Instance.CastPact();

            RaisePropertyChanged("PactSlots");
        }

        public void HandleCreateSpell(int level)
        {
            Coffeelock.Instance.CreateSpell(level);

            RaisePropertyChanged(spellProperties[level]);
            RaisePropertyChanged("SorceryPoints");
        }

        public void HandleDestroySpell(int level)
        {
            Coffeelock.Instance.DestroySpell(level);

            RaisePropertyChanged(spellProperties[level]);
            RaisePropertyChanged("SorceryPoints");
        }

        public void HandleDestroyPact()
        {
            Coffeelock.Instance.DestroyPact();

            RaisePropertyChanged("PactSlots");
            RaisePropertyChanged("SorceryPoints");
        }
        #endregion

        #region Data Bindings
        public int SorcererLevel
        {
            get => Coffeelock.Instance.SorcererLevel;
            set
            {
                Coffeelock.Instance.SorcererLevel = value;
                HandleLongRest();
            }
        }

        public int WarlockLevel
        {
            get => Coffeelock.Instance.WarlockLevel;
            set
            {
                Coffeelock.Instance.WarlockLevel = value;
                RaisePropertyChanged("LPactLevel");
                HandleLongRest();
            }
        }

        public int SorceryPoints
        {
            get => Coffeelock.Instance.SorceryPoints;
            set => Coffeelock.Instance.SorceryPoints = value;
        }

        public int Slots1
        {
            get => Coffeelock.Instance.SpellSlots[1];
            set => Coffeelock.Instance.SpellSlots[1] = value;
        }

        public int Slots2
        {
            get => Coffeelock.Instance.SpellSlots[2];
            set => Coffeelock.Instance.SpellSlots[2] = value;
        }

        public int Slots3
        {
            get => Coffeelock.Instance.SpellSlots[3];
            set => Coffeelock.Instance.SpellSlots[3] = value;
        }

        public int Slots4
        {
            get => Coffeelock.Instance.SpellSlots[4];
            set => Coffeelock.Instance.SpellSlots[4] = value;
        }

        public int Slots5
        {
            get => Coffeelock.Instance.SpellSlots[5];
            set => Coffeelock.Instance.SpellSlots[5] = value;
        }

        public int Slots6
        {
            get => Coffeelock.Instance.SpellSlots[6];
            set => Coffeelock.Instance.SpellSlots[6] = value;
        }

        public int Slots7
        {
            get => Coffeelock.Instance.SpellSlots[7];
            set => Coffeelock.Instance.SpellSlots[7] = value;
        }

        public int Slots8
        {
            get => Coffeelock.Instance.SpellSlots[8];
            set => Coffeelock.Instance.SpellSlots[8] = value;
        }

        public int Slots9
        {
            get => Coffeelock.Instance.SpellSlots[9];
            set => Coffeelock.Instance.SpellSlots[9] = value;
        }
        public int PactSlots
        {
            get => Coffeelock.Instance.PactSlots;
            set => Coffeelock.Instance.PactSlots = value;
        }
        #endregion

        #region Labels
        public string LSorcererLevel => "Sorcerer Level";
        public string LWarlockLevel => "Warlock Level";

        public string LShortRest => "Short Rest";
        public string LLongRest => "Long Rest";
        public string LSlots1 => Constants.SLOT_LABELS[1];
        public string LSlots2 => Constants.SLOT_LABELS[2];
        public string LSlots3 => Constants.SLOT_LABELS[3];
        public string LSlots4 => Constants.SLOT_LABELS[4];
        public string LSlots5 => Constants.SLOT_LABELS[5];
        public string LSlots6 => Constants.SLOT_LABELS[6];
        public string LSlots7 => Constants.SLOT_LABELS[7];
        public string LSlots8 => Constants.SLOT_LABELS[8];
        public string LSlots9 => Constants.SLOT_LABELS[9];
        public string LCreate => "Create";
        public string LDestroy => "Destroy";
        public string LCast => "Cast";
        public string LSpend => "Spend";
        public string LSorceryPoints => "Sorcery Points";
        public string LSpellSlots => "Spell Slots";
        public string LPactSlots => "Pact Slots";
        public string LPactLevel => Constants.SLOT_LABELS[Coffeelock.Instance.PactSlotLevel];
        #endregion
    }
}
